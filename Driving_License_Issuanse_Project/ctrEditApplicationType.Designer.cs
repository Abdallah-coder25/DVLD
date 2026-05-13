namespace Driving_License_Issuanse_Project
{
    partial class ctrEditApplicationType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbvalue = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txFees = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txType = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbvalue
            // 
            this.lbvalue.AutoSize = true;
            this.lbvalue.BackColor = System.Drawing.Color.White;
            this.lbvalue.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbvalue.ForeColor = System.Drawing.Color.Black;
            this.lbvalue.Location = new System.Drawing.Point(189, 76);
            this.lbvalue.Name = "lbvalue";
            this.lbvalue.Size = new System.Drawing.Size(36, 27);
            this.lbvalue.TabIndex = 17;
            this.lbvalue.Text = "??";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.BackColor = System.Drawing.Color.White;
            this.lbFees.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbFees.ForeColor = System.Drawing.Color.Black;
            this.lbFees.Location = new System.Drawing.Point(94, 205);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(60, 27);
            this.lbFees.TabIndex = 16;
            this.lbFees.Text = "Fees";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.BackColor = System.Drawing.Color.White;
            this.lbID.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbID.ForeColor = System.Drawing.Color.Black;
            this.lbID.Location = new System.Drawing.Point(118, 76);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(36, 27);
            this.lbID.TabIndex = 15;
            this.lbID.Text = "ID";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.BackColor = System.Drawing.Color.White;
            this.lbType.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbType.ForeColor = System.Drawing.Color.Black;
            this.lbType.Location = new System.Drawing.Point(82, 137);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(72, 27);
            this.lbType.TabIndex = 14;
            this.lbType.Text = "Title";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(280, 283);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 35);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Reset";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txFees
            // 
            this.txFees.Location = new System.Drawing.Point(194, 205);
            this.txFees.Name = "txFees";
            this.txFees.Size = new System.Drawing.Size(194, 27);
            this.txFees.TabIndex = 12;
            this.txFees.Validating += new System.ComponentModel.CancelEventHandler(this.txFees_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(420, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 35);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txType
            // 
            this.txType.Location = new System.Drawing.Point(194, 140);
            this.txType.Name = "txType";
            this.txType.Size = new System.Drawing.Size(322, 27);
            this.txType.TabIndex = 10;
            this.txType.Validating += new System.ComponentModel.CancelEventHandler(this.txType_Validating);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(15, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(288, 27);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "Update Application Type";
            // 
            // ctrEditApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbvalue);
            this.Controls.Add(this.lbFees);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txFees);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txType);
            this.Controls.Add(this.lbTitle);
            this.Name = "ctrEditApplicationType";
            this.Size = new System.Drawing.Size(521, 321);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbvalue;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txFees;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txType;
        private System.Windows.Forms.Label lbTitle;
    }
}
