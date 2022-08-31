using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HidSharp;

namespace UPSCommTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void alog(string text, bool noNewLine=false)
        {
            eLog.AppendText(text + (noNewLine ? "" : Environment.NewLine));
        }

        private void bListAllDev_Click(object sender, EventArgs e)
        {
            DeviceList deviceList = DeviceList.Local;

            List<Device> dlist = deviceList.GetAllDevices().ToList();
            alog("Found devices: " + dlist.Count.ToString());
            foreach (Device dv in dlist)
            {
                alog(" - " + dv.GetFriendlyName() + " : " + dv.DevicePath);
            }
            alog("------------------------------------------");
        }

        private void bFindUPS_Click(object sender, EventArgs e)
        {
            DeviceList deviceList = DeviceList.Local;
            int vid = 0x0665;
            int pid = 0x5161;

            List<HidDevice> dlist = deviceList.GetHidDevices(vendorID: vid, productID: pid).ToList();
            alog("Found UPS(" + vid.ToString("x4") + ":" + pid.ToString("x4") + ") HID devices: " + dlist.Count.ToString());
            cbDevices.Items.Clear();
            foreach (HidDevice dv in dlist)
            {
                alog(" - `" + dv.GetFriendlyName() + "` V=" + dv.VendorID.ToString("X4") + " P=" + dv.ProductID.ToString("X4") + " : " + dv.DevicePath);
                cbDevices.Items.Add(dv.DevicePath);
            }
            if (cbDevices.Items.Count > 0)
            {

                if (cbDevices.Items.Count > 1)
                {
                    // if there is more than one UPS then look for first MI_00 (endpoint 0 (or 1 or 0x81))
                    bool found = false;
                    for(int i = 0; i < cbDevices.Items.Count; i++)
                    {
                        string s = cbDevices.Items[i].ToString().ToLower();
                        if (s.Contains("&mi_00#"))
                        {
                            cbDevices.SelectedIndex = i;
                            found = true;
                            break;
                        }
                    }
                    if (!found) cbDevices.SelectedIndex = 0;
                }
                else
                {
                    // if there is only one UPS found, select it
                    cbDevices.SelectedIndex = 0;
                }
            }
            alog("------------------------------------------");
        }

        private void bFindHid_Click(object sender, EventArgs e)
        {
            DeviceList deviceList = DeviceList.Local;

            List<HidDevice> dlist = deviceList.GetHidDevices().ToList();
            alog("Found HID devices: " + dlist.Count.ToString());
            foreach (HidDevice dv in dlist)
            {
                alog(" - `" + dv.GetFriendlyName() + "` V=" + dv.VendorID.ToString("X4") + " P=" + dv.ProductID.ToString("X4") + " : " + dv.DevicePath);
            }
            alog("------------------------------------------");
        }

        private void bdumpDescr_Click(object sender, EventArgs e)
        {
            HidDevice dev = null;

            DeviceList deviceList = DeviceList.Local;

            List<HidDevice> dlist = deviceList.GetHidDevices().ToList();
            foreach (HidDevice dv in dlist)
            {
                //alog(" - `" + dv.GetFriendlyName() + "` V=" + dv.VendorID.ToString("X4") + " P=" + dv.ProductID.ToString("X4") + " : " + dv.DevicePath);
                if (dv.DevicePath == cbDevices.Text)
                {
                    dev = dv;
                    break;
                }
            }

            if (dev == null) return;
            alog("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            alog("Selected device: "+dev.DevicePath);
            alog("manufacturer: " + dev.GetManufacturer());
            alog("Product name:" + dev.GetProductName());
            alog("S/N: " + dev.GetSerialNumber());
            alog("Max feature report length: " + dev.GetMaxFeatureReportLength().ToString());
            alog("Max input report length: " + dev.GetMaxInputReportLength().ToString());
            alog("Max output report length: " + dev.GetMaxOutputReportLength().ToString());

            int indt = 0;
            var rawrDesc = dev.GetRawReportDescriptor();
            List<HidSharp.Reports.Encodings.EncodedItem> itms = HidSharp.Reports.Encodings.EncodedItem.DecodeItems(rawrDesc, 0, rawrDesc.Length).ToList();
            alog("Report descriptor: (length=" + rawrDesc.Length.ToString() + " items=" + itms.Count.ToString() + ")");
            foreach(HidSharp.Reports.Encodings.EncodedItem it in itms)
            {
                if (it.ItemType == HidSharp.Reports.Encodings.ItemType.Main && it.TagForMain == HidSharp.Reports.Encodings.MainItemTag.EndCollection) indt -= 2;
                alog(String.Format("  {0} {1}", new String(' ', indt), it.ToString()));
                if (it.ItemType == HidSharp.Reports.Encodings.ItemType.Main && it.TagForMain == HidSharp.Reports.Encodings.MainItemTag.Collection) indt += 2;
            }

            HidSharp.Reports.ReportDescriptor rpDesc = dev.GetReportDescriptor();

            foreach(HidSharp.Reports.DeviceItem di in rpDesc.DeviceItems)
            {
                alog("Usages:");
                foreach(uint us in di.Usages.GetAllValues())
                {
                    alog(String.Format("  - {0:X4} : {1}", us, (HidSharp.Reports.Usage)us));
                }
                alog("IN Reports:");
                foreach(HidSharp.Reports.Report rp in di.Reports)
                {
                    alog(string.Format("  - {0}: rID={1}  Len={2}  Items={3}", rp.ReportType, rp.ReportID, rp.Length, rp.DataItems.Count));
                    foreach(HidSharp.Reports.DataItem d in rp.DataItems)
                    {
                        alog(string.Format(
                             "    + Count {0} elements by {1} bits, units: {2}, expected usage type: {3}, flags: {4}, usages: {5}"
                            , d.ElementCount
                            , d.ElementBits
                            , d.Unit.System
                            , d.ExpectedUsageType
                            , d.Flags
                            , string.Join(", ", d.Usages.GetAllValues().Select(u => u.ToString("X4") + ":" + ((HidSharp.Reports.Usage)u).ToString()))
                            ));
                    }
                }
                alog("OUT Reports:");
                foreach (HidSharp.Reports.Report rp in di.OutputReports)
                {
                    alog(string.Format("  - {0}: rID={1}  Len={2}  Items={3}", rp.ReportType, rp.ReportID, rp.Length, rp.DataItems.Count));
                    foreach (HidSharp.Reports.DataItem d in rp.DataItems)
                    {
                        alog(string.Format(
                             "    + Count {0} elements by {1} bits, units: {2}, expected usage type: {3}, flags: {4}, usages: {5}"
                            , d.ElementCount
                            , d.ElementBits
                            , d.Unit.System
                            , d.ExpectedUsageType
                            , d.Flags
                            , string.Join(", ", d.Usages.GetAllValues().Select(u => u.ToString("X4") + ":" + ((HidSharp.Reports.Usage)u).ToString()))
                            ));
                    }
                }
            }

            

            HidStream hs;
            if (dev.TryOpen(out hs))
            {
                alog("We can open it!");
                using(hs)
                {
                    //byte[] inRepBuff = new byte[dev.GetMaxInputReportLength()];
                    //var inpRecv = rpDesc.CreateHidDeviceInputReceiver();
                    //var inpParser = 
                }
            }
            
        }

        private void bSendCMD_Click(object sender, EventArgs e)
        {
            string cmd = eCMD.Text.Trim();

            string re = QueryUPS(cmd);
            alog(">> " + cmd + " << «" + re + "»");
        }

        string ByteArrrayDump(byte[] ar, bool ascii=true, bool noNewLine=false)
        {
            if (ar == null) return "<!NULL!>";
            if (ar.Length < 1) return "<LENGTH=0>";

            string sout = "";
            string asciiline = "";
            string hexline = "";
            for(int i=0;i<ar.Length;i++)
            {
                hexline += ar[i].ToString("X2") + " ";
                if (ar[i] >= 0x20 && ar[i] <= 0x7e)
                {
                    asciiline += (char)(ar[i]);
                } else
                {
                    asciiline += "·";
                }

                if (((i%16)==0) && (i>0))
                {
                    sout += hexline + (ascii ? (": " + asciiline) : "") + (noNewLine ? " | " : Environment.NewLine);
                    hexline = "";
                    asciiline = "";
                }
            }

            if (hexline.Length>2)
            {
                sout += hexline + (ascii ? ": " + asciiline : "");
            }

            return sout;
        }

        /// <summary>
        /// Convert byte array to string while replacing non-printable characters with dot.
        /// Can remove zeros and/or control characters too.
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="ZeroRemove"></param>
        /// <param name="ControlRemove"></param>
        /// <returns></returns>
        string ByteArrayToString(byte[] ar, bool ZeroRemove = true, bool ControlRemove=false)
        {
            string re = "";
            if (ar == null) return "";
            if (ar.Length < 1) return "";

            for (int i = 0; i < ar.Length; i++)
            {
                byte b = ar[i];
                if ((b >= 0x20) && (b <= 0x7e))
                {
                    re += (char)b;
                }
                else
                {
                    if (ZeroRemove)
                    {
                        if ((b != 0) && (!ControlRemove)) re += "·";
                    }
                    else
                    {
                        if (!ControlRemove) re += "·";
                    }
                }
            }

            return re;
        }

        string QueryUPS(string cmd)
        {
            HidDevice dev = null;
            string replay = "";
            byte[] cmdbyte;

            /*if (cmd.Length > 7)
            {
                alog("Command: `" + cmd + "` too long(" + cmd.Length.ToString() + ")!");
                return "";
            }*/

            cmd = cmd.Trim();
            cmd += "\x0d";

            cmdbyte = Encoding.ASCII.GetBytes(cmd);// new byte[cmd.Length + 1];

            
            if (cbHexDumps.Checked) alog("QueryUPS: «" + cmd + "» : " + ByteArrrayDump(cmdbyte));
                else alog("QueryUPS: «" + cmd + "» ...");

            DeviceList deviceList = DeviceList.Local;

            List<HidDevice> dlist = deviceList.GetHidDevices().ToList();
            foreach (HidDevice dv in dlist)
            {
                //alog(" - `" + dv.GetFriendlyName() + "` V=" + dv.VendorID.ToString("X4") + " P=" + dv.ProductID.ToString("X4") + " : " + dv.DevicePath);
                if (dv.DevicePath == cbDevices.Text)
                {
                    dev = dv;
                    break;
                }
            }

            if (dev == null) return "";
            // now we got right dev, print some info and let's try to send some query to UPS...
            // at work UPS I got here thrown exception, so I'm dumping it into try-catch
            try
            {
                if (cbHexDumps.Checked) alog("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                if (cbHexDumps.Checked) alog("Selected device: " + dev.DevicePath);
                if (cbHexDumps.Checked) alog("Manufacturer: " + dev.GetManufacturer());
                if (cbHexDumps.Checked) alog("Product name:" + dev.GetProductName());
                if (cbHexDumps.Checked) alog("S/N: " + dev.GetSerialNumber());
            } catch(Exception ee)
            {
                alog("ERR getting some info about device. Error: " + ee.Message);
            }
            HidSharp.Reports.ReportDescriptor rpDesc = dev.GetReportDescriptor();

            if (rpDesc.DeviceItems.Count > 0)
            {
                HidSharp.Reports.DeviceItem devit = rpDesc.DeviceItems[0];

                HidStream hs;
                if (dev.TryOpen(out hs))
                {
                    if (cbHexDumps.Checked) alog("Opened!");
                    using (hs)
                    {
                        byte[] inRepBuff = new byte[dev.GetMaxInputReportLength()];
                        var inpRecv = rpDesc.CreateHidDeviceInputReceiver();
                        var inpParser = devit.CreateDeviceItemInputParser();
                        byte[] outRepBuff = new byte[dev.GetMaxOutputReportLength()];


                        //byte[] cmdar = Encoding.ASCII.GetBytes(cmd);
                        //if (cmdar.Length > (outRepBuff.Length-2))
                        //{
                        //    alog("Command too long(" + cmdar.Length.ToString() + "), won't fit into buffer(" + outRepBuff.Length.ToString() + "-2)!");
                        //    return "";
                        //}

                        outRepBuff[0] = 0x00;
                        int i = 0, j = 0;
                        for (j = 0,i=1; j < cmdbyte.Length; j++,i++)
                        {
                            
                            outRepBuff[i] = cmdbyte[j]; // from byte1
                            if (i >= (outRepBuff.Length-1))
                            {
                                // send
                                //outRepBuff[++j] = 0x0d;
                                if (cbHexDumps.Checked) alog("Sending data chunk["+(i-(outRepBuff.Length-1)).ToString()+".." + i.ToString()+"]: " + ByteArrrayDump(outRepBuff));

                                // DEBUG: no send.
                                hs.Write(outRepBuff, 0, outRepBuff.Length);
                                if (cbHexDumps.Checked) alog("Sent.");
                                // zero buffer
                                for (int k = 0; k < outRepBuff.Length; k++) outRepBuff[k] = 0;
                                i = 0; // reset i to 1, going throught "for" will i++ .
                            }
                        }
                        //outRepBuff[++j] = 0x0d;
                        if (i > 1)
                        {
                            if (cbHexDumps.Checked) alog("Sending data: " + ByteArrrayDump(outRepBuff));

                            //DEBUG: no send.
                            hs.Write(outRepBuff, 0, outRepBuff.Length);
                            if (cbHexDumps.Checked) alog("Sent.");
                        }
                        inpRecv.Start(hs);

                        List<HidSharp.Reports.Report> respRep = new List<HidSharp.Reports.Report>();

                        int start = Environment.TickCount;
                        while (true)
                        {
                            //alog("LOOP...");
                            if (inpRecv.WaitHandle.WaitOne(300))
                            {
                                //alog("LOOP:WAINT-ONE...");
                                if (!inpRecv.IsRunning) break;

                                //alog("LOOP:IS-RUNNING...");
                                HidSharp.Reports.Report rep;
                                while (inpRecv.TryRead(inRepBuff, 0, out rep))
                                {
                                    if (cbHexDumps.Checked) alog("Got report: " + ByteArrrayDump(inRepBuff));

                                    replay += ByteArrayToString(inRepBuff,ControlRemove: true);
                                    //respRep.Add(rep);
                                }
                            }

                            uint etime = (uint)(Environment.TickCount - start);
                            if (etime > 1000) { break; }
                        }

                        //foreach(HidSharp.Reports.Report r in respRep)
                        //{
                        //r.Write()
                        //alog("Report len=" + r.Length.ToString());
                        //}

                    }
                }
            }
            else
            {
                alog("Nope to open. :/");
            }
            replay = replay.Replace("\r", "");
            replay = replay.Replace("\n", "");
            replay = replay.Replace("\a", "");
            return replay;
        }

        private void button5QS_Click(object sender, EventArgs e)
        {
            string cmd = "QS";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCommandF_Click(object sender, EventArgs e)
        {
            string cmd = "F";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdQI_Click(object sender, EventArgs e)
        {
            string cmd = "QI";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdT_Click(object sender, EventArgs e)
        {
            string cmd = "T";
            alog("Testing UPS (10sec test)...");
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdQ_Click(object sender, EventArgs e)
        {
            string cmd = "Q";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdM_Click(object sender, EventArgs e)
        {
            string cmd = "M";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdC_Click(object sender, EventArgs e)
        {
            string cmd = "C";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void eLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                eLog.Clear();
            }
        }

        private void bCmdSdot3R0001_Click(object sender, EventArgs e)
        {
            string cmd = "S.3R0001";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdS01R0001_Click(object sender, EventArgs e)
        {
            string cmd = "S01R0001";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdSdot3R0000_Click(object sender, EventArgs e)
        {
            string cmd = "S01R0000";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }

        private void bCmdS00R0000_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This command will instantly KILL power on UPS OUTPUT, are you sure?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            string cmd = "S00R0000";
            string re = QueryUPS(cmd);
            alog("CMD:>> " + cmd + " << RE:«" + re + "»");
        }
    }
}
