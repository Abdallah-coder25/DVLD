namespace Driving_License_Issuanse_Project
{
    partial class ManageLocalDrivingLicense
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
            this.txSearch = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.cbSerach = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.datagridview1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleWritenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicensefirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbMangePeople = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMangePeople)).BeginInit();
            this.SuspendLayout();
            // 
            // txSearch
            // 
            this.txSearch.Location = new System.Drawing.Point(322, 207);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(181, 27);
            this.txSearch.TabIndex = 27;
            this.txSearch.Visible = false;
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Font = new System.Drawing.Font("Cascadia Code", 8F, System.Drawing.FontStyle.Italic);
            this.lbNumber.ForeColor = System.Drawing.Color.Black;
            this.lbNumber.Location = new System.Drawing.Point(127, 612);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(37, 21);
            this.lbNumber.TabIndex = 26;
            this.lbNumber.Text = "???";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Cascadia Code", 8F, System.Drawing.FontStyle.Italic);
            this.lbRecord.ForeColor = System.Drawing.Color.Black;
            this.lbRecord.Location = new System.Drawing.Point(12, 612);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(109, 21);
            this.lbRecord.TabIndex = 25;
            this.lbRecord.Text = "# Record : ";
            // 
            // cbSerach
            // 
            this.cbSerach.Font = new System.Drawing.Font("Cascadia Code", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbSerach.FormattingEnabled = true;
            this.cbSerach.Items.AddRange(new object[] {
            "None",
            "L.D.LAppID",
            "National",
            "FullName",
            "Status"});
            this.cbSerach.Location = new System.Drawing.Point(131, 203);
            this.cbSerach.Name = "cbSerach";
            this.cbSerach.Size = new System.Drawing.Size(171, 32);
            this.cbSerach.TabIndex = 23;
            this.cbSerach.Text = "None";
            this.cbSerach.SelectedIndexChanged += new System.EventHandler(this.cbSerach_SelectedIndexChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Cascadia Code", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.lbFilter.ForeColor = System.Drawing.Color.Black;
            this.lbFilter.Location = new System.Drawing.Point(12, 209);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(109, 21);
            this.lbFilter.TabIndex = 22;
            this.lbFilter.Text = "Filter by :";
            // 
            // datagridview1
            // 
            this.datagridview1.BackgroundColor = System.Drawing.Color.White;
            this.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview1.ContextMenuStrip = this.contextMenuStrip1;
            this.datagridview1.Location = new System.Drawing.Point(12, 247);
            this.datagridview1.Name = "datagridview1";
            this.datagridview1.RowHeadersWidth = 62;
            this.datagridview1.RowTemplate.Height = 29;
            this.datagridview1.Size = new System.Drawing.Size(1384, 350);
            this.datagridview1.TabIndex = 21;
            this.datagridview1.SelectionChanged += new System.EventHandler(this.datagridview1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.sechduleTestsToolStripMenuItem,
            this.issueDrivingLicensefirstTimeToolStripMenuItem,
            this.sToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(339, 293);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Close_32;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.closeBlack32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleVisionTestToolStripMenuItem,
            this.sechduleWritenTestToolStripMenuItem,
            this.sechduleStreetTestToolStripMenuItem});
            this.sechduleTestsToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Written_Test_32_Sechdule;
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.sechduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.sechduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.sechduleVisionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            this.sechduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // sechduleWritenTestToolStripMenuItem
            // 
            this.sechduleWritenTestToolStripMenuItem.Name = "sechduleWritenTestToolStripMenuItem";
            this.sechduleWritenTestToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.sechduleWritenTestToolStripMenuItem.Text = "Sechdule Writen Test";
            this.sechduleWritenTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleWritenTestToolStripMenuItem_Click);
            // 
            // sechduleStreetTestToolStripMenuItem
            // 
            this.sechduleStreetTestToolStripMenuItem.Name = "sechduleStreetTestToolStripMenuItem";
            this.sechduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.sechduleStreetTestToolStripMenuItem.Text = "Sechdule Street Test";
            this.sechduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleStreetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicensefirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicensefirstTimeToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicensefirstTimeToolStripMenuItem.Name = "issueDrivingLicensefirstTimeToolStripMenuItem";
            this.issueDrivingLicensefirstTimeToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.issueDrivingLicensefirstTimeToolStripMenuItem.Text = "Issue Driving License(first Time)";
            this.issueDrivingLicensefirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicensefirstTimeToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.License_View_32;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.sToolStripMenuItem.Text = "Show License ";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Driving_License_Issuanse_Project.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Cascadia Code", 16F, System.Drawing.FontStyle.Italic);
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(109, 26);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(646, 43);
            this.lbTitle.TabIndex = 20;
            this.lbTitle.Text = "Local Driving License Application";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.BackgroundImage = global::Driving_License_Issuanse_Project.Properties.Resources.cross_64;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(1324, 603);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 38);
            this.btnClose.TabIndex = 28;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.BackgroundImage = global::Driving_License_Issuanse_Project.Properties.Resources.New_Application_64;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(1324, 202);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 35);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbMangePeople
            // 
            this.pbMangePeople.BackColor = System.Drawing.Color.White;
            this.pbMangePeople.Image = global::Driving_License_Issuanse_Project.Properties.Resources.Applications_64;
            this.pbMangePeople.Location = new System.Drawing.Point(493, 84);
            this.pbMangePeople.Name = "pbMangePeople";
            this.pbMangePeople.Size = new System.Drawing.Size(225, 99);
            this.pbMangePeople.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMangePeople.TabIndex = 19;
            this.pbMangePeople.TabStop = false;
            // 
            // ManageLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1423, 653);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txSearch);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbSerach);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.datagridview1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pbMangePeople);
            this.Name = "ManageLocalDrivingLicense";
            this.Text = "ManageLocalDrivingLicense";
            this.Load += new System.EventHandler(this.ManageLocalDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMangePeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbSerach;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.DataGridView datagridview1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbMangePeople;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicensefirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleWritenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleStreetTestToolStripMenuItem;
    }
}