namespace AddressManager
{
    partial class AddressManagerForm
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkShowDeleted = new System.Windows.Forms.CheckBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripStatus = new System.Windows.Forms.ToolStrip();
            this.grpAccountType = new System.Windows.Forms.GroupBox();
            this.chkCommon = new System.Windows.Forms.CheckBox();
            this.chkShipping = new System.Windows.Forms.CheckBox();
            this.chkPrimaryBilling = new System.Windows.Forms.CheckBox();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripStatus.SuspendLayout();
            this.grpAccountType.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(6, 498);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 30);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(109, 498);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkShowDeleted
            // 
            this.chkShowDeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDeleted.AutoSize = true;
            this.chkShowDeleted.Location = new System.Drawing.Point(671, 258);
            this.chkShowDeleted.Name = "chkShowDeleted";
            this.chkShowDeleted.Size = new System.Drawing.Size(93, 17);
            this.chkShowDeleted.TabIndex = 15;
            this.chkShowDeleted.Text = "Show Deleted";
            this.chkShowDeleted.UseVisualStyleBackColor = true;
            this.chkShowDeleted.CheckedChanged += new System.EventHandler(this.chkDeleted_CheckedChanged);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.Color.Green;
            this.lblAccount.Location = new System.Drawing.Point(265, 7);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(108, 13);
            this.lblAccount.TabIndex = 16;
            this.lblAccount.Text = "{{ Account Info }}";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(663, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelAddress
            // 
            this.panelAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAddress.Location = new System.Drawing.Point(1, 256);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(293, 236);
            this.panelAddress.TabIndex = 25;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(170, 22);
            this.statusLabel.Text = "{{ Address Validation Status }}";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.toolStripStatus.Location = new System.Drawing.Point(0, 536);
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(769, 25);
            this.toolStripStatus.TabIndex = 20;
            this.toolStripStatus.Text = "toolStrip1";
            // 
            // grpAccountType
            // 
            this.grpAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAccountType.Controls.Add(this.chkCommon);
            this.grpAccountType.Controls.Add(this.chkShipping);
            this.grpAccountType.Controls.Add(this.chkPrimaryBilling);
            this.grpAccountType.Location = new System.Drawing.Point(276, 261);
            this.grpAccountType.Name = "grpAccountType";
            this.grpAccountType.Size = new System.Drawing.Size(125, 100);
            this.grpAccountType.TabIndex = 29;
            this.grpAccountType.TabStop = false;
            this.grpAccountType.Text = "Address Type";
            // 
            // chkCommon
            // 
            this.chkCommon.AutoSize = true;
            this.chkCommon.Location = new System.Drawing.Point(13, 72);
            this.chkCommon.Name = "chkCommon";
            this.chkCommon.Size = new System.Drawing.Size(111, 17);
            this.chkCommon.TabIndex = 2;
            this.chkCommon.Text = "Common Shipping";
            this.chkCommon.UseVisualStyleBackColor = true;
            this.chkCommon.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkShipping
            // 
            this.chkShipping.AutoSize = true;
            this.chkShipping.Location = new System.Drawing.Point(13, 46);
            this.chkShipping.Name = "chkShipping";
            this.chkShipping.Size = new System.Drawing.Size(104, 17);
            this.chkShipping.TabIndex = 1;
            this.chkShipping.Text = "Default Shipping";
            this.chkShipping.UseVisualStyleBackColor = true;
            this.chkShipping.CheckedChanged += new System.EventHandler(this.chkShipping_CheckedChanged);
            // 
            // chkPrimaryBilling
            // 
            this.chkPrimaryBilling.AutoSize = true;
            this.chkPrimaryBilling.Location = new System.Drawing.Point(13, 20);
            this.chkPrimaryBilling.Name = "chkPrimaryBilling";
            this.chkPrimaryBilling.Size = new System.Drawing.Size(90, 17);
            this.chkPrimaryBilling.TabIndex = 0;
            this.chkPrimaryBilling.Text = "Primary Billing";
            this.chkPrimaryBilling.UseVisualStyleBackColor = true;
            this.chkPrimaryBilling.CheckedChanged += new System.EventHandler(this.chkPrimaryBilling_CheckedChanged);
            // 
            // panelDGV
            // 
            this.panelDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDGV.Location = new System.Drawing.Point(9, 25);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Size = new System.Drawing.Size(751, 228);
            this.panelDGV.TabIndex = 26;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Location = new System.Drawing.Point(13, 23);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 0;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "&Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            this.rdoActive.CheckedChanged += new System.EventHandler(this.rdoActive_CheckedChanged);
            this.rdoActive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoActive_KeyUp);
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Location = new System.Drawing.Point(13, 46);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(62, 17);
            this.rdoDeleted.TabIndex = 30;
            this.rdoDeleted.TabStop = true;
            this.rdoDeleted.Text = "&Deleted";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            this.rdoDeleted.CheckedChanged += new System.EventHandler(this.rdoDeleted_CheckedChanged);
            this.rdoDeleted.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoDeleted_KeyUp);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(702, 8);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 32;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.rdoActive);
            this.grpStatus.Controls.Add(this.rdoDeleted);
            this.grpStatus.Location = new System.Drawing.Point(275, 366);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(126, 82);
            this.grpStatus.TabIndex = 33;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(328, 472);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.ReadOnly = true;
            this.txtTaxRate.Size = new System.Drawing.Size(73, 20);
            this.txtTaxRate.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tax Rate";
            // 
            // AddressManagerForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(769, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.grpAccountType);
            this.Controls.Add(this.toolStripStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.chkShowDeleted);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.panelAddress);
            this.MinimumSize = new System.Drawing.Size(16, 500);
            this.Name = "AddressManagerForm";
            this.Text = "Address Manager";
            this.Load += new System.EventHandler(this.AddressManagerForm_Load);
            this.toolStripStatus.ResumeLayout(false);
            this.toolStripStatus.PerformLayout();
            this.grpAccountType.ResumeLayout(false);
            this.grpAccountType.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkShowDeleted;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelAddress;
        private System.Windows.Forms.ToolStripLabel statusLabel;
        private System.Windows.Forms.ToolStrip toolStripStatus;
        private System.Windows.Forms.GroupBox grpAccountType;
        private System.Windows.Forms.CheckBox chkCommon;
        private System.Windows.Forms.CheckBox chkShipping;
        private System.Windows.Forms.CheckBox chkPrimaryBilling;
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Label label2;
    }
}

