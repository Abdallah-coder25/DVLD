namespace Driving_License_Issuanse_Project
{
    partial class ChangePassword
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
            this.ctrShowDetails1 = new Driving_License_Issuanse_Project.ctrShowDetails();
            this.btnSave = new System.Windows.Forms.Button();
            this.txConf = new System.Windows.Forms.TextBox();
            this.txPass = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbCurPas = new System.Windows.Forms.Label();
            this.lbNPas = new System.Windows.Forms.Label();
            this.lbConf = new System.Windows.Forms.Label();
            this.txCurent = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrShowDetails1
            // 
            this.ctrShowDetails1.DetailID = 0;
            this.ctrShowDetails1.Location = new System.Drawing.Point(-1, 2);
            this.ctrShowDetails1.Name = "ctrShowDetails1";
            this.ctrShowDetails1.Size = new System.Drawing.Size(679, 408);
            this.ctrShowDetails1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(523, 505);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 48);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txConf
            // 
            this.txConf.Location = new System.Drawing.Point(175, 532);
            this.txConf.Name = "txConf";
            this.txConf.PasswordChar = '*';
            this.txConf.Size = new System.Drawing.Size(141, 27);
            this.txConf.TabIndex = 9;
            this.txConf.Validating += new System.ComponentModel.CancelEventHandler(this.txConf_Validating);
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(175, 481);
            this.txPass.Name = "txPass";
            this.txPass.Size = new System.Drawing.Size(141, 27);
            this.txPass.TabIndex = 8;
            this.txPass.Validating += new System.ComponentModel.CancelEventHandler(this.txPass_Validating);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnClose.Location = new System.Drawing.Point(523, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 48);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Reset";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbCurPas
            // 
            this.lbCurPas.AutoSize = true;
            this.lbCurPas.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbCurPas.ForeColor = System.Drawing.Color.Black;
            this.lbCurPas.Location = new System.Drawing.Point(-4, 429);
            this.lbCurPas.Name = "lbCurPas";
            this.lbCurPas.Size = new System.Drawing.Size(154, 21);
            this.lbCurPas.TabIndex = 10;
            this.lbCurPas.Text = "Current Password";
            // 
            // lbNPas
            // 
            this.lbNPas.AutoSize = true;
            this.lbNPas.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbNPas.ForeColor = System.Drawing.Color.Black;
            this.lbNPas.Location = new System.Drawing.Point(32, 487);
            this.lbNPas.Name = "lbNPas";
            this.lbNPas.Size = new System.Drawing.Size(118, 21);
            this.lbNPas.TabIndex = 12;
            this.lbNPas.Text = "New Password";
            // 
            // lbConf
            // 
            this.lbConf.AutoSize = true;
            this.lbConf.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbConf.ForeColor = System.Drawing.Color.Black;
            this.lbConf.Location = new System.Drawing.Point(77, 532);
            this.lbConf.Name = "lbConf";
            this.lbConf.Size = new System.Drawing.Size(73, 21);
            this.lbConf.TabIndex = 13;
            this.lbConf.Text = "Confirm";
            // 
            // txCurent
            // 
            this.txCurent.Location = new System.Drawing.Point(175, 429);
            this.txCurent.Name = "txCurent";
            this.txCurent.Size = new System.Drawing.Size(141, 27);
            this.txCurent.TabIndex = 7;
            this.txCurent.Validating += new System.ComponentModel.CancelEventHandler(this.txCurent_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Close_32;
            this.pictureBox1.Location = new System.Drawing.Point(649, 443);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Save_32;
            this.pictureBox2.Location = new System.Drawing.Point(649, 517);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 573);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txConf);
            this.Controls.Add(this.txPass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbCurPas);
            this.Controls.Add(this.lbNPas);
            this.Controls.Add(this.lbConf);
            this.Controls.Add(this.txCurent);
            this.Controls.Add(this.ctrShowDetails1);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrShowDetails ctrShowDetails1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txConf;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbCurPas;
        private System.Windows.Forms.Label lbNPas;
        private System.Windows.Forms.Label lbConf;
        private System.Windows.Forms.TextBox txCurent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}