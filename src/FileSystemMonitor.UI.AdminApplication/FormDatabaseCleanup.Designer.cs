namespace FileSystemMonitor.UI.AdminApplication
{
    partial class FormDatabaseCleanup
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDeleteRecordsOlderThan = new System.Windows.Forms.Label();
            this.udUnitCount = new System.Windows.Forms.NumericUpDown();
            this.cbUnitType = new System.Windows.Forms.ComboBox();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udUnitCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.cbUnitType);
            this.gbMain.Controls.Add(this.udUnitCount);
            this.gbMain.Controls.Add(this.lblDeleteRecordsOlderThan);
            this.gbMain.Location = new System.Drawing.Point(12, 12);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(319, 55);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = " Shrink database ";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(256, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(175, 73);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblDeleteRecordsOlderThan
            // 
            this.lblDeleteRecordsOlderThan.AutoSize = true;
            this.lblDeleteRecordsOlderThan.Location = new System.Drawing.Point(9, 22);
            this.lblDeleteRecordsOlderThan.Name = "lblDeleteRecordsOlderThan";
            this.lblDeleteRecordsOlderThan.Size = new System.Drawing.Size(129, 13);
            this.lblDeleteRecordsOlderThan.TabIndex = 0;
            this.lblDeleteRecordsOlderThan.Text = "Delete records older than";
            // 
            // udUnitCount
            // 
            this.udUnitCount.Location = new System.Drawing.Point(144, 20);
            this.udUnitCount.Name = "udUnitCount";
            this.udUnitCount.Size = new System.Drawing.Size(62, 21);
            this.udUnitCount.TabIndex = 1;
            this.udUnitCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbUnitType
            // 
            this.cbUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitType.FormattingEnabled = true;
            this.cbUnitType.Items.AddRange(new object[] {
            "years",
            "months",
            "days",
            "hours",
            "minutes",
            "seconds"});
            this.cbUnitType.Location = new System.Drawing.Point(212, 20);
            this.cbUnitType.Name = "cbUnitType";
            this.cbUnitType.Size = new System.Drawing.Size(91, 21);
            this.cbUnitType.TabIndex = 2;
            // 
            // FormDatabaseCleanup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 109);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormDatabaseCleanup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database cleanup";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udUnitCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label lblDeleteRecordsOlderThan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbUnitType;
        private System.Windows.Forms.NumericUpDown udUnitCount;
    }
}