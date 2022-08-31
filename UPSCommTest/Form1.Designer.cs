namespace UPSCommTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bListAllDev = new System.Windows.Forms.Button();
            this.bFindUPS = new System.Windows.Forms.Button();
            this.bFindHid = new System.Windows.Forms.Button();
            this.bTest1 = new System.Windows.Forms.Button();
            this.bCmdQS = new System.Windows.Forms.Button();
            this.eLog = new System.Windows.Forms.TextBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.eCMD = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bCmdF = new System.Windows.Forms.Button();
            this.bCmdQI = new System.Windows.Forms.Button();
            this.bCmdT = new System.Windows.Forms.Button();
            this.bCmdQ = new System.Windows.Forms.Button();
            this.bCmdM = new System.Windows.Forms.Button();
            this.bCmdC = new System.Windows.Forms.Button();
            this.bSendCMD = new System.Windows.Forms.Button();
            this.cbHexDumps = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bCmdSdot3R0001 = new System.Windows.Forms.Button();
            this.bCmdS01R0001 = new System.Windows.Forms.Button();
            this.bCmdSdot3R0000 = new System.Windows.Forms.Button();
            this.bCmdS00R0000 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bListAllDev
            // 
            this.bListAllDev.Location = new System.Drawing.Point(3, 3);
            this.bListAllDev.Name = "bListAllDev";
            this.bListAllDev.Size = new System.Drawing.Size(100, 23);
            this.bListAllDev.TabIndex = 0;
            this.bListAllDev.Text = "List All USB";
            this.toolTip1.SetToolTip(this.bListAllDev, "List all USB Devices connected to host");
            this.bListAllDev.UseVisualStyleBackColor = true;
            this.bListAllDev.Click += new System.EventHandler(this.bListAllDev_Click);
            // 
            // bFindUPS
            // 
            this.bFindUPS.Location = new System.Drawing.Point(190, 3);
            this.bFindUPS.Name = "bFindUPS";
            this.bFindUPS.Size = new System.Drawing.Size(109, 23);
            this.bFindUPS.TabIndex = 1;
            this.bFindUPS.Text = "Find UPS";
            this.toolTip1.SetToolTip(this.bFindUPS, "Find UPS using VID_0665 && PID_5161");
            this.bFindUPS.UseVisualStyleBackColor = true;
            this.bFindUPS.Click += new System.EventHandler(this.bFindUPS_Click);
            // 
            // bFindHid
            // 
            this.bFindHid.Location = new System.Drawing.Point(109, 3);
            this.bFindHid.Name = "bFindHid";
            this.bFindHid.Size = new System.Drawing.Size(75, 23);
            this.bFindHid.TabIndex = 2;
            this.bFindHid.Text = "Find HIDs";
            this.toolTip1.SetToolTip(this.bFindHid, "List all HID devices only");
            this.bFindHid.UseVisualStyleBackColor = true;
            this.bFindHid.Click += new System.EventHandler(this.bFindHid_Click);
            // 
            // bTest1
            // 
            this.bTest1.Location = new System.Drawing.Point(305, 3);
            this.bTest1.Name = "bTest1";
            this.bTest1.Size = new System.Drawing.Size(90, 23);
            this.bTest1.TabIndex = 3;
            this.bTest1.Text = "Dump Descr.";
            this.toolTip1.SetToolTip(this.bTest1, "Dum some Descriptor info of selected UPS");
            this.bTest1.UseVisualStyleBackColor = true;
            this.bTest1.Click += new System.EventHandler(this.bdumpDescr_Click);
            // 
            // bCmdQS
            // 
            this.bCmdQS.Location = new System.Drawing.Point(401, 3);
            this.bCmdQS.Name = "bCmdQS";
            this.bCmdQS.Size = new System.Drawing.Size(75, 23);
            this.bCmdQS.TabIndex = 4;
            this.bCmdQS.Text = "CMD: QS";
            this.toolTip1.SetToolTip(this.bCmdQS, "Send CommandQS - Query status");
            this.bCmdQS.UseVisualStyleBackColor = true;
            this.bCmdQS.Click += new System.EventHandler(this.button5QS_Click);
            // 
            // eLog
            // 
            this.eLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eLog.Location = new System.Drawing.Point(12, 129);
            this.eLog.Multiline = true;
            this.eLog.Name = "eLog";
            this.eLog.ReadOnly = true;
            this.eLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eLog.Size = new System.Drawing.Size(735, 325);
            this.eLog.TabIndex = 6;
            this.eLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eLog_KeyDown);
            // 
            // cbDevices
            // 
            this.cbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(12, 76);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(734, 21);
            this.cbDevices.TabIndex = 7;
            // 
            // eCMD
            // 
            this.eCMD.Location = new System.Drawing.Point(12, 103);
            this.eCMD.Name = "eCMD";
            this.eCMD.Size = new System.Drawing.Size(225, 20);
            this.eCMD.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.bListAllDev);
            this.flowLayoutPanel1.Controls.Add(this.bFindHid);
            this.flowLayoutPanel1.Controls.Add(this.bFindUPS);
            this.flowLayoutPanel1.Controls.Add(this.bTest1);
            this.flowLayoutPanel1.Controls.Add(this.bCmdQS);
            this.flowLayoutPanel1.Controls.Add(this.bCmdF);
            this.flowLayoutPanel1.Controls.Add(this.bCmdQI);
            this.flowLayoutPanel1.Controls.Add(this.bCmdT);
            this.flowLayoutPanel1.Controls.Add(this.bCmdQ);
            this.flowLayoutPanel1.Controls.Add(this.bCmdM);
            this.flowLayoutPanel1.Controls.Add(this.bCmdC);
            this.flowLayoutPanel1.Controls.Add(this.bCmdSdot3R0001);
            this.flowLayoutPanel1.Controls.Add(this.bCmdS01R0001);
            this.flowLayoutPanel1.Controls.Add(this.bCmdSdot3R0000);
            this.flowLayoutPanel1.Controls.Add(this.bCmdS00R0000);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(735, 64);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // bCmdF
            // 
            this.bCmdF.Location = new System.Drawing.Point(482, 3);
            this.bCmdF.Name = "bCmdF";
            this.bCmdF.Size = new System.Drawing.Size(75, 23);
            this.bCmdF.TabIndex = 5;
            this.bCmdF.Text = "CMD: F";
            this.toolTip1.SetToolTip(this.bCmdF, "F - query ratings");
            this.bCmdF.UseVisualStyleBackColor = true;
            this.bCmdF.Click += new System.EventHandler(this.bCommandF_Click);
            // 
            // bCmdQI
            // 
            this.bCmdQI.Location = new System.Drawing.Point(563, 3);
            this.bCmdQI.Name = "bCmdQI";
            this.bCmdQI.Size = new System.Drawing.Size(75, 23);
            this.bCmdQI.TabIndex = 6;
            this.bCmdQI.Text = "CMD: QI";
            this.toolTip1.SetToolTip(this.bCmdQI, "QI - Query for what? (some internal data?)");
            this.bCmdQI.UseVisualStyleBackColor = true;
            this.bCmdQI.Click += new System.EventHandler(this.bCmdQI_Click);
            // 
            // bCmdT
            // 
            this.bCmdT.Location = new System.Drawing.Point(644, 3);
            this.bCmdT.Name = "bCmdT";
            this.bCmdT.Size = new System.Drawing.Size(75, 23);
            this.bCmdT.TabIndex = 7;
            this.bCmdT.Text = "CMD: T";
            this.toolTip1.SetToolTip(this.bCmdT, "T - test 10sec command\r\n(Nothing is returned)");
            this.bCmdT.UseVisualStyleBackColor = true;
            this.bCmdT.Click += new System.EventHandler(this.bCmdT_Click);
            // 
            // bCmdQ
            // 
            this.bCmdQ.Location = new System.Drawing.Point(3, 32);
            this.bCmdQ.Name = "bCmdQ";
            this.bCmdQ.Size = new System.Drawing.Size(75, 23);
            this.bCmdQ.TabIndex = 8;
            this.bCmdQ.Text = "CMD: Q";
            this.toolTip1.SetToolTip(this.bCmdQ, "Q - toggle beeper (check last bit of QS).\r\nNothing is returned.");
            this.bCmdQ.UseVisualStyleBackColor = true;
            this.bCmdQ.Click += new System.EventHandler(this.bCmdQ_Click);
            // 
            // bCmdM
            // 
            this.bCmdM.Location = new System.Drawing.Point(84, 32);
            this.bCmdM.Name = "bCmdM";
            this.bCmdM.Size = new System.Drawing.Size(75, 23);
            this.bCmdM.TabIndex = 9;
            this.bCmdM.Text = "CMD: M";
            this.toolTip1.SetToolTip(this.bCmdM, "M - query for protocol.");
            this.bCmdM.UseVisualStyleBackColor = true;
            this.bCmdM.Click += new System.EventHandler(this.bCmdM_Click);
            // 
            // bCmdC
            // 
            this.bCmdC.Location = new System.Drawing.Point(165, 32);
            this.bCmdC.Name = "bCmdC";
            this.bCmdC.Size = new System.Drawing.Size(75, 23);
            this.bCmdC.TabIndex = 10;
            this.bCmdC.Text = "CMD: C";
            this.toolTip1.SetToolTip(this.bCmdC, "C - Cancel shutdown");
            this.bCmdC.UseVisualStyleBackColor = true;
            this.bCmdC.Click += new System.EventHandler(this.bCmdC_Click);
            // 
            // bSendCMD
            // 
            this.bSendCMD.Location = new System.Drawing.Point(243, 103);
            this.bSendCMD.Name = "bSendCMD";
            this.bSendCMD.Size = new System.Drawing.Size(47, 20);
            this.bSendCMD.TabIndex = 5;
            this.bSendCMD.Text = "Send";
            this.bSendCMD.UseVisualStyleBackColor = true;
            this.bSendCMD.Click += new System.EventHandler(this.bSendCMD_Click);
            // 
            // cbHexDumps
            // 
            this.cbHexDumps.AutoSize = true;
            this.cbHexDumps.Location = new System.Drawing.Point(296, 105);
            this.cbHexDumps.Name = "cbHexDumps";
            this.cbHexDumps.Size = new System.Drawing.Size(90, 17);
            this.cbHexDumps.TabIndex = 10;
            this.cbHexDumps.Text = "HEX-DUMPS";
            this.cbHexDumps.UseVisualStyleBackColor = true;
            // 
            // bCmdSdot3R0001
            // 
            this.bCmdSdot3R0001.Location = new System.Drawing.Point(246, 32);
            this.bCmdSdot3R0001.Name = "bCmdSdot3R0001";
            this.bCmdSdot3R0001.Size = new System.Drawing.Size(100, 23);
            this.bCmdSdot3R0001.TabIndex = 11;
            this.bCmdSdot3R0001.Text = "CMD: S.3R0001";
            this.toolTip1.SetToolTip(this.bCmdSdot3R0001, "Shutdown after 18sec (0.3*1min=18sec), \r\nand restore power after 1min");
            this.bCmdSdot3R0001.UseVisualStyleBackColor = true;
            this.bCmdSdot3R0001.Click += new System.EventHandler(this.bCmdSdot3R0001_Click);
            // 
            // bCmdS01R0001
            // 
            this.bCmdS01R0001.Location = new System.Drawing.Point(352, 32);
            this.bCmdS01R0001.Name = "bCmdS01R0001";
            this.bCmdS01R0001.Size = new System.Drawing.Size(100, 23);
            this.bCmdS01R0001.TabIndex = 12;
            this.bCmdS01R0001.Text = "CMD: S01R0001";
            this.toolTip1.SetToolTip(this.bCmdS01R0001, "Shutdown after 1min, \r\nand restore power after 1min");
            this.bCmdS01R0001.UseVisualStyleBackColor = true;
            this.bCmdS01R0001.Click += new System.EventHandler(this.bCmdS01R0001_Click);
            // 
            // bCmdSdot3R0000
            // 
            this.bCmdSdot3R0000.Location = new System.Drawing.Point(458, 32);
            this.bCmdSdot3R0000.Name = "bCmdSdot3R0000";
            this.bCmdSdot3R0000.Size = new System.Drawing.Size(100, 23);
            this.bCmdSdot3R0000.TabIndex = 13;
            this.bCmdSdot3R0000.Text = "CMD: S.3R0000";
            this.toolTip1.SetToolTip(this.bCmdSdot3R0000, "Shutdown after 18sec (0,3*1min=18sec).\r\nNo restore power.\r\n(Use C-Cancel to resto" +
        "re power)");
            this.bCmdSdot3R0000.UseVisualStyleBackColor = true;
            this.bCmdSdot3R0000.Click += new System.EventHandler(this.bCmdSdot3R0000_Click);
            // 
            // bCmdS00R0000
            // 
            this.bCmdS00R0000.Location = new System.Drawing.Point(564, 32);
            this.bCmdS00R0000.Name = "bCmdS00R0000";
            this.bCmdS00R0000.Size = new System.Drawing.Size(100, 23);
            this.bCmdS00R0000.TabIndex = 14;
            this.bCmdS00R0000.Text = "CMD: S00R0000";
            this.toolTip1.SetToolTip(this.bCmdS00R0000, "Instant shutdown output power.\r\nNo restore power.\r\n(Use C-Cancel to restore power" +
        ")");
            this.bCmdS00R0000.UseVisualStyleBackColor = true;
            this.bCmdS00R0000.Click += new System.EventHandler(this.bCmdS00R0000_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 466);
            this.Controls.Add(this.cbHexDumps);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.eCMD);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.eLog);
            this.Controls.Add(this.bSendCMD);
            this.Name = "Form1";
            this.Text = "HidSharp Test (UPS Comm)";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bListAllDev;
        private System.Windows.Forms.Button bFindUPS;
        private System.Windows.Forms.Button bFindHid;
        private System.Windows.Forms.Button bTest1;
        private System.Windows.Forms.Button bCmdQS;
        private System.Windows.Forms.TextBox eLog;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.TextBox eCMD;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bSendCMD;
        private System.Windows.Forms.Button bCmdF;
        private System.Windows.Forms.CheckBox cbHexDumps;
        private System.Windows.Forms.Button bCmdQI;
        private System.Windows.Forms.Button bCmdT;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bCmdQ;
        private System.Windows.Forms.Button bCmdM;
        private System.Windows.Forms.Button bCmdC;
        private System.Windows.Forms.Button bCmdSdot3R0001;
        private System.Windows.Forms.Button bCmdS01R0001;
        private System.Windows.Forms.Button bCmdSdot3R0000;
        private System.Windows.Forms.Button bCmdS00R0000;
    }
}

