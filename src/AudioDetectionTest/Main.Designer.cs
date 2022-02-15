namespace AudioDetectionTest
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.BtnSetRefreshInterval = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TbRefreshInterval = new System.Windows.Forms.TextBox();
            this.TbPeakVolume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbDefaultDeviceState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbDefaultDevice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TbMasterVolume = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LvSessions = new System.Windows.Forms.ListView();
            this.ClmApplication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmMasterVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmPeakVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmMuted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlInfo
            // 
            this.PnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlInfo.Controls.Add(this.LvSessions);
            this.PnlInfo.Controls.Add(this.TbMasterVolume);
            this.PnlInfo.Controls.Add(this.label5);
            this.PnlInfo.Controls.Add(this.BtnSetRefreshInterval);
            this.PnlInfo.Controls.Add(this.label4);
            this.PnlInfo.Controls.Add(this.TbRefreshInterval);
            this.PnlInfo.Controls.Add(this.TbPeakVolume);
            this.PnlInfo.Controls.Add(this.label3);
            this.PnlInfo.Controls.Add(this.TbDefaultDeviceState);
            this.PnlInfo.Controls.Add(this.label2);
            this.PnlInfo.Controls.Add(this.TbDefaultDevice);
            this.PnlInfo.Controls.Add(this.label1);
            this.PnlInfo.Location = new System.Drawing.Point(12, 12);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(829, 277);
            this.PnlInfo.TabIndex = 0;
            // 
            // BtnSetRefreshInterval
            // 
            this.BtnSetRefreshInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetRefreshInterval.Location = new System.Drawing.Point(100, 231);
            this.BtnSetRefreshInterval.Name = "BtnSetRefreshInterval";
            this.BtnSetRefreshInterval.Size = new System.Drawing.Size(75, 26);
            this.BtnSetRefreshInterval.TabIndex = 10;
            this.BtnSetRefreshInterval.Text = "set";
            this.BtnSetRefreshInterval.UseVisualStyleBackColor = true;
            this.BtnSetRefreshInterval.Click += new System.EventHandler(this.BtnSetRefreshInterval_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "refresh interval (seconds)";
            // 
            // TbRefreshInterval
            // 
            this.TbRefreshInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbRefreshInterval.Location = new System.Drawing.Point(15, 232);
            this.TbRefreshInterval.Name = "TbRefreshInterval";
            this.TbRefreshInterval.Size = new System.Drawing.Size(79, 25);
            this.TbRefreshInterval.TabIndex = 6;
            this.TbRefreshInterval.Text = "5";
            // 
            // TbPeakVolume
            // 
            this.TbPeakVolume.BackColor = System.Drawing.Color.White;
            this.TbPeakVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPeakVolume.ForeColor = System.Drawing.Color.Black;
            this.TbPeakVolume.Location = new System.Drawing.Point(207, 156);
            this.TbPeakVolume.Name = "TbPeakVolume";
            this.TbPeakVolume.ReadOnly = true;
            this.TbPeakVolume.Size = new System.Drawing.Size(112, 25);
            this.TbPeakVolume.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "peak volume";
            // 
            // TbDefaultDeviceState
            // 
            this.TbDefaultDeviceState.BackColor = System.Drawing.Color.White;
            this.TbDefaultDeviceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDefaultDeviceState.ForeColor = System.Drawing.Color.Black;
            this.TbDefaultDeviceState.Location = new System.Drawing.Point(15, 94);
            this.TbDefaultDeviceState.Name = "TbDefaultDeviceState";
            this.TbDefaultDeviceState.ReadOnly = true;
            this.TbDefaultDeviceState.Size = new System.Drawing.Size(304, 25);
            this.TbDefaultDeviceState.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "state";
            // 
            // TbDefaultDevice
            // 
            this.TbDefaultDevice.BackColor = System.Drawing.Color.White;
            this.TbDefaultDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDefaultDevice.ForeColor = System.Drawing.Color.Black;
            this.TbDefaultDevice.Location = new System.Drawing.Point(15, 32);
            this.TbDefaultDevice.Name = "TbDefaultDevice";
            this.TbDefaultDevice.ReadOnly = true;
            this.TbDefaultDevice.Size = new System.Drawing.Size(304, 25);
            this.TbDefaultDevice.TabIndex = 1;
            this.TbDefaultDevice.Text = " loading ..";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "default device";
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(162)))));
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.BtnExit.Location = new System.Drawing.Point(0, 320);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(853, 30);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.Location = new System.Drawing.Point(12, 292);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(11, 13);
            this.LblVersion.TabIndex = 4;
            this.LblVersion.Text = "-";
            // 
            // TbMasterVolume
            // 
            this.TbMasterVolume.BackColor = System.Drawing.Color.White;
            this.TbMasterVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMasterVolume.ForeColor = System.Drawing.Color.Black;
            this.TbMasterVolume.Location = new System.Drawing.Point(15, 156);
            this.TbMasterVolume.Name = "TbMasterVolume";
            this.TbMasterVolume.ReadOnly = true;
            this.TbMasterVolume.Size = new System.Drawing.Size(112, 25);
            this.TbMasterVolume.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "master volume";
            // 
            // LvSessions
            // 
            this.LvSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmApplication,
            this.ClmMuted,
            this.ClmMasterVolume,
            this.ClmPeakVolume});
            this.LvSessions.HideSelection = false;
            this.LvSessions.Location = new System.Drawing.Point(364, 12);
            this.LvSessions.Name = "LvSessions";
            this.LvSessions.Size = new System.Drawing.Size(449, 245);
            this.LvSessions.TabIndex = 13;
            this.LvSessions.UseCompatibleStateImageBehavior = false;
            this.LvSessions.View = System.Windows.Forms.View.Details;
            // 
            // ClmApplication
            // 
            this.ClmApplication.Text = "application";
            this.ClmApplication.Width = 182;
            // 
            // ClmMasterVolume
            // 
            this.ClmMasterVolume.Text = "master vol";
            this.ClmMasterVolume.Width = 84;
            // 
            // ClmPeakVolume
            // 
            this.ClmPeakVolume.Text = "peak vol";
            this.ClmPeakVolume.Width = 84;
            // 
            // ClmMuted
            // 
            this.ClmMuted.Text = "muted";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 350);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.PnlInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Detection Test | LAB02 Research";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.TextBox TbDefaultDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbDefaultDeviceState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbPeakVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbRefreshInterval;
        private System.Windows.Forms.Button BtnSetRefreshInterval;
        private System.Windows.Forms.TextBox TbMasterVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView LvSessions;
        private System.Windows.Forms.ColumnHeader ClmApplication;
        private System.Windows.Forms.ColumnHeader ClmMasterVolume;
        private System.Windows.Forms.ColumnHeader ClmPeakVolume;
        private System.Windows.Forms.ColumnHeader ClmMuted;
    }
}

