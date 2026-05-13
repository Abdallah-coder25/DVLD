namespace Driving_License_Issuanse_Project
{
    partial class ctrTestType
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
            this.button1 = new System.Windows.Forms.Button();
            this.txFees = new System.Windows.Forms.TextBox();
            this.txDescription = new System.Windows.Forms.TextBox();
            this.lbValue = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbTypeName = new System.Windows.Forms.Label();
            this.lbInfoId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(163, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Reset";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txFees
            // 
            this.txFees.Location = new System.Drawing.Point(195, 329);
            this.txFees.Name = "txFees";
            this.txFees.Size = new System.Drawing.Size(139, 27);
            this.txFees.TabIndex = 22;
            this.txFees.Validating += new System.ComponentModel.CancelEventHandler(this.txFees_Validating);
            // 
            // txDescription
            // 
            this.txDescription.Location = new System.Drawing.Point(195, 175);
            this.txDescription.Multiline = true;
            this.txDescription.Name = "txDescription";
            this.txDescription.Size = new System.Drawing.Size(289, 144);
            this.txDescription.TabIndex = 21;
            this.txDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txDescription_Validating);
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbValue.ForeColor = System.Drawing.Color.Black;
            this.lbValue.Location = new System.Drawing.Point(190, 88);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(36, 27);
            this.lbValue.TabIndex = 20;
            this.lbValue.Text = "??";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbFees.ForeColor = System.Drawing.Color.Black;
            this.lbFees.Location = new System.Drawing.Point(93, 326);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(60, 27);
            this.lbFees.TabIndex = 19;
            this.lbFees.Text = "Fees";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbDescription.ForeColor = System.Drawing.Color.Black;
            this.lbDescription.Location = new System.Drawing.Point(32, 172);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(144, 27);
            this.lbDescription.TabIndex = 18;
            this.lbDescription.Text = "Description";
            // 
            // lbTypeName
            // 
            this.lbTypeName.AutoSize = true;
            this.lbTypeName.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbTypeName.ForeColor = System.Drawing.Color.Black;
            this.lbTypeName.Location = new System.Drawing.Point(85, 135);
            this.lbTypeName.Name = "lbTypeName";
            this.lbTypeName.Size = new System.Drawing.Size(72, 27);
            this.lbTypeName.TabIndex = 17;
            this.lbTypeName.Text = "Title";
            // 
            // lbInfoId
            // 
            this.lbInfoId.AutoSize = true;
            this.lbInfoId.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoId.ForeColor = System.Drawing.Color.Black;
            this.lbInfoId.Location = new System.Drawing.Point(117, 88);
            this.lbInfoId.Name = "lbInfoId";
            this.lbInfoId.Size = new System.Drawing.Size(36, 27);
            this.lbInfoId.TabIndex = 16;
            this.lbInfoId.Text = "ID";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(360, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 28);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txTitle
            // 
            this.txTitle.Location = new System.Drawing.Point(195, 135);
            this.txTitle.Name = "txTitle";
            this.txTitle.Size = new System.Drawing.Size(289, 27);
            this.txTitle.TabIndex = 14;
            this.txTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txTitle_Validating);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Cascadia Code", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(3, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(204, 27);
            this.lbTitle.TabIndex = 13;
            this.lbTitle.Text = "Update Test Type";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txFees);
            this.Controls.Add(this.txDescription);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbFees);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbTypeName);
            this.Controls.Add(this.lbInfoId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txTitle);
            this.Controls.Add(this.lbTitle);
            this.Name = "ctrTestType";
            this.Size = new System.Drawing.Size(491, 417);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txFees;
        private System.Windows.Forms.TextBox txDescription;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbTypeName;
        private System.Windows.Forms.Label lbInfoId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
