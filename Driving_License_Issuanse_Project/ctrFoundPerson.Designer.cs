namespace Driving_License_Issuanse_Project
{
    partial class ctrFoundPerson
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.pbPerson = new System.Windows.Forms.PictureBox();
            this.txFilter = new System.Windows.Forms.TextBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lkbEdit = new System.Windows.Forms.LinkLabel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbInfoAddres = new System.Windows.Forms.Label();
            this.lbInfoEmail = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbInfoName = new System.Windows.Forms.Label();
            this.lbInfoNational = new System.Windows.Forms.Label();
            this.lbInfoGender = new System.Windows.Forms.Label();
            this.lbInfoDate = new System.Windows.Forms.Label();
            this.lbInfoPhone = new System.Windows.Forms.Label();
            this.lbInfoCountry = new System.Windows.Forms.Label();
            this.lbInfoId = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).BeginInit();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.White;
            this.gbFilter.Controls.Add(this.pbSearch);
            this.gbFilter.Controls.Add(this.cbSearch);
            this.gbFilter.Controls.Add(this.pbPerson);
            this.gbFilter.Controls.Add(this.txFilter);
            this.gbFilter.ForeColor = System.Drawing.Color.Black;
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(672, 81);
            this.gbFilter.TabIndex = 4;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.White;
            this.pbSearch.Image = global::Driving_License_Issuanse_Project.Properties.Resources.SearchPerson;
            this.pbSearch.Location = new System.Drawing.Point(408, 37);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(44, 26);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 7;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "None",
            "National No",
            "PersonID"});
            this.cbSearch.Location = new System.Drawing.Point(40, 36);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(130, 27);
            this.cbSearch.TabIndex = 6;
            // 
            // pbPerson
            // 
            this.pbPerson.BackColor = System.Drawing.Color.White;
            this.pbPerson.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Add_Person_40;
            this.pbPerson.Location = new System.Drawing.Point(497, 37);
            this.pbPerson.Name = "pbPerson";
            this.pbPerson.Size = new System.Drawing.Size(44, 26);
            this.pbPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerson.TabIndex = 4;
            this.pbPerson.TabStop = false;
            this.pbPerson.Click += new System.EventHandler(this.pbPerson_Click);
            // 
            // txFilter
            // 
            this.txFilter.Location = new System.Drawing.Point(216, 36);
            this.txFilter.Name = "txFilter";
            this.txFilter.Size = new System.Drawing.Size(147, 27);
            this.txFilter.TabIndex = 3;
            this.txFilter.Validating += new System.ComponentModel.CancelEventHandler(this.txFilter_Validating);
            // 
            // gbInfo
            // 
            this.gbInfo.BackColor = System.Drawing.Color.White;
            this.gbInfo.Controls.Add(this.linkLabel1);
            this.gbInfo.Controls.Add(this.lkbEdit);
            this.gbInfo.Controls.Add(this.pbImage);
            this.gbInfo.Controls.Add(this.lbInfoAddres);
            this.gbInfo.Controls.Add(this.lbInfoEmail);
            this.gbInfo.Controls.Add(this.label14);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.lbInfoName);
            this.gbInfo.Controls.Add(this.lbInfoNational);
            this.gbInfo.Controls.Add(this.lbInfoGender);
            this.gbInfo.Controls.Add(this.lbInfoDate);
            this.gbInfo.Controls.Add(this.lbInfoPhone);
            this.gbInfo.Controls.Add(this.lbInfoCountry);
            this.gbInfo.Controls.Add(this.lbInfoId);
            this.gbInfo.Controls.Add(this.label10);
            this.gbInfo.Controls.Add(this.label9);
            this.gbInfo.Controls.Add(this.label8);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.ForeColor = System.Drawing.Color.Black;
            this.gbInfo.Location = new System.Drawing.Point(3, 103);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(672, 317);
            this.gbInfo.TabIndex = 5;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Person Information";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(483, 61);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 19);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Peron Info";
            // 
            // lkbEdit
            // 
            this.lkbEdit.AutoSize = true;
            this.lkbEdit.LinkColor = System.Drawing.Color.White;
            this.lkbEdit.Location = new System.Drawing.Point(493, 59);
            this.lkbEdit.Name = "lkbEdit";
            this.lkbEdit.Size = new System.Drawing.Size(0, 19);
            this.lkbEdit.TabIndex = 23;
            // 
            // pbImage
            // 
            this.pbImage.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Male_512;
            this.pbImage.Location = new System.Drawing.Point(468, 92);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(187, 115);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 22;
            this.pbImage.TabStop = false;
            // 
            // lbInfoAddres
            // 
            this.lbInfoAddres.AutoSize = true;
            this.lbInfoAddres.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoAddres.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoAddres.ForeColor = System.Drawing.Color.Black;
            this.lbInfoAddres.Location = new System.Drawing.Point(138, 280);
            this.lbInfoAddres.Name = "lbInfoAddres";
            this.lbInfoAddres.Size = new System.Drawing.Size(32, 18);
            this.lbInfoAddres.TabIndex = 21;
            this.lbInfoAddres.Text = "???";
            // 
            // lbInfoEmail
            // 
            this.lbInfoEmail.AutoSize = true;
            this.lbInfoEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoEmail.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoEmail.ForeColor = System.Drawing.Color.Black;
            this.lbInfoEmail.Location = new System.Drawing.Point(138, 233);
            this.lbInfoEmail.Name = "lbInfoEmail";
            this.lbInfoEmail.Size = new System.Drawing.Size(32, 18);
            this.lbInfoEmail.TabIndex = 20;
            this.lbInfoEmail.Text = "???";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(19, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 21);
            this.label14.TabIndex = 19;
            this.label14.Text = "Addres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Email";
            // 
            // lbInfoName
            // 
            this.lbInfoName.AutoSize = true;
            this.lbInfoName.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoName.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoName.ForeColor = System.Drawing.Color.Black;
            this.lbInfoName.Location = new System.Drawing.Point(138, 80);
            this.lbInfoName.Name = "lbInfoName";
            this.lbInfoName.Size = new System.Drawing.Size(32, 18);
            this.lbInfoName.TabIndex = 17;
            this.lbInfoName.Text = "???";
            // 
            // lbInfoNational
            // 
            this.lbInfoNational.AutoSize = true;
            this.lbInfoNational.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoNational.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoNational.ForeColor = System.Drawing.Color.Black;
            this.lbInfoNational.Location = new System.Drawing.Point(138, 139);
            this.lbInfoNational.Name = "lbInfoNational";
            this.lbInfoNational.Size = new System.Drawing.Size(32, 18);
            this.lbInfoNational.TabIndex = 16;
            this.lbInfoNational.Text = "???";
            // 
            // lbInfoGender
            // 
            this.lbInfoGender.AutoSize = true;
            this.lbInfoGender.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoGender.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoGender.ForeColor = System.Drawing.Color.Black;
            this.lbInfoGender.Location = new System.Drawing.Point(138, 193);
            this.lbInfoGender.Name = "lbInfoGender";
            this.lbInfoGender.Size = new System.Drawing.Size(32, 18);
            this.lbInfoGender.TabIndex = 15;
            this.lbInfoGender.Text = "???";
            // 
            // lbInfoDate
            // 
            this.lbInfoDate.AutoSize = true;
            this.lbInfoDate.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoDate.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoDate.ForeColor = System.Drawing.Color.Black;
            this.lbInfoDate.Location = new System.Drawing.Point(340, 38);
            this.lbInfoDate.Name = "lbInfoDate";
            this.lbInfoDate.Size = new System.Drawing.Size(32, 18);
            this.lbInfoDate.TabIndex = 14;
            this.lbInfoDate.Text = "???";
            // 
            // lbInfoPhone
            // 
            this.lbInfoPhone.AutoSize = true;
            this.lbInfoPhone.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoPhone.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoPhone.ForeColor = System.Drawing.Color.Black;
            this.lbInfoPhone.Location = new System.Drawing.Point(340, 136);
            this.lbInfoPhone.Name = "lbInfoPhone";
            this.lbInfoPhone.Size = new System.Drawing.Size(32, 18);
            this.lbInfoPhone.TabIndex = 13;
            this.lbInfoPhone.Text = "???";
            // 
            // lbInfoCountry
            // 
            this.lbInfoCountry.AutoSize = true;
            this.lbInfoCountry.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoCountry.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoCountry.ForeColor = System.Drawing.Color.Black;
            this.lbInfoCountry.Location = new System.Drawing.Point(340, 186);
            this.lbInfoCountry.Name = "lbInfoCountry";
            this.lbInfoCountry.Size = new System.Drawing.Size(32, 18);
            this.lbInfoCountry.TabIndex = 12;
            this.lbInfoCountry.Text = "???";
            // 
            // lbInfoId
            // 
            this.lbInfoId.AutoSize = true;
            this.lbInfoId.BackColor = System.Drawing.Color.Transparent;
            this.lbInfoId.Font = new System.Drawing.Font("Cascadia Code", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbInfoId.ForeColor = System.Drawing.Color.Black;
            this.lbInfoId.Location = new System.Drawing.Point(138, 39);
            this.lbInfoId.Name = "lbInfoId";
            this.lbInfoId.Size = new System.Drawing.Size(32, 18);
            this.lbInfoId.TabIndex = 11;
            this.lbInfoId.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(19, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.TabIndex = 10;
            this.label10.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(19, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "National No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "Gendor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(249, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(249, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(249, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Country";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(431, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "PersonID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrFoundPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrFoundPerson";
            this.Size = new System.Drawing.Size(680, 428);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.PictureBox pbPerson;
        private System.Windows.Forms.TextBox txFilter;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lkbEdit;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lbInfoAddres;
        private System.Windows.Forms.Label lbInfoEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbInfoName;
        private System.Windows.Forms.Label lbInfoNational;
        private System.Windows.Forms.Label lbInfoGender;
        private System.Windows.Forms.Label lbInfoDate;
        private System.Windows.Forms.Label lbInfoPhone;
        private System.Windows.Forms.Label lbInfoCountry;
        private System.Windows.Forms.Label lbInfoId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
