
namespace maxx_pos
{
    partial class FRMMAIN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStep = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUploadStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPrinters = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboPayslipOption = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayInYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayInMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payInStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEmployeeStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 245;
            this.label1.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(47, 2);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(57, 21);
            this.cmbYear.TabIndex = 246;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(168, 1);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(42, 21);
            this.cmbMonth.TabIndex = 249;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 248;
            this.label2.Text = "Month";
            // 
            // cmbStep
            // 
            this.cmbStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStep.FormattingEnabled = true;
            this.cmbStep.Location = new System.Drawing.Point(259, 1);
            this.cmbStep.Name = "cmbStep";
            this.cmbStep.Size = new System.Drawing.Size(47, 21);
            this.cmbStep.TabIndex = 252;
            this.cmbStep.SelectedIndexChanged += new System.EventHandler(this.cmbStep_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 251;
            this.label3.Text = "Step";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(441, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 254;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(519, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 22);
            this.btnPrint.TabIndex = 255;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // timerPrint
            // 
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // timerRead
            // 
            this.timerRead.Interval = 300000;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1149, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Copyright MAXX CREATION TECHNOLOGY CO., LTD © 2022 (Released: v5.0.2)";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUploadStatus
            // 
            this.lblUploadStatus.Name = "lblUploadStatus";
            this.lblUploadStatus.Size = new System.Drawing.Size(179, 17);
            this.lblUploadStatus.Text = "Outstanding Upload: 0 Record(s)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUploadStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1343, 22);
            this.statusStrip1.TabIndex = 243;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 251;
            this.label4.Text = "Branch";
            // 
            // cboBranch
            // 
            this.cboBranch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(367, 1);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(68, 21);
            this.cboBranch.TabIndex = 252;
            this.cboBranch.SelectedIndexChanged += new System.EventHandler(this.cboBranch_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 251;
            this.label5.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(346, 8);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(219, 21);
            this.cboDepartment.TabIndex = 252;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(994, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 251;
            this.label6.Text = "Printer";
            this.label6.Visible = false;
            // 
            // comboBoxPrinters
            // 
            this.comboBoxPrinters.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPrinters.FormattingEnabled = true;
            this.comboBoxPrinters.Location = new System.Drawing.Point(1048, 4);
            this.comboBoxPrinters.Name = "comboBoxPrinters";
            this.comboBoxPrinters.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPrinters.TabIndex = 252;
            this.comboBoxPrinters.Visible = false;
            this.comboBoxPrinters.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrinters_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(597, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 22);
            this.btnClear.TabIndex = 255;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboPayslipOption
            // 
            this.cboPayslipOption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPayslipOption.FormattingEnabled = true;
            this.cboPayslipOption.Items.AddRange(new object[] {
            "Payslip",
            "Payslip (Option 1)",
            "Payslip (Option 2)"});
            this.cboPayslipOption.Location = new System.Drawing.Point(626, 9);
            this.cboPayslipOption.Name = "cboPayslipOption";
            this.cboPayslipOption.Size = new System.Drawing.Size(133, 21);
            this.cboPayslipOption.TabIndex = 258;
            this.cboPayslipOption.SelectedIndexChanged += new System.EventHandler(this.cboPayslipOption_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 19);
            this.label7.TabIndex = 257;
            this.label7.Text = "Option";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1343, 25);
            this.toolStrip1.TabIndex = 241;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToResizeColumns = false;
            this.dgvDevice.AllowUserToResizeRows = false;
            this.dgvDevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevice.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevice.ColumnHeadersHeight = 40;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colEmpNo,
            this.colEmpName,
            this.colPayInYear,
            this.colPayInMonth,
            this.payInStep});
            this.dgvDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.EnableHeadersVisualStyles = false;
            this.dgvDevice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvDevice.Location = new System.Drawing.Point(0, 65);
            this.dgvDevice.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDevice.MultiSelect = false;
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDevice.RowHeadersVisible = false;
            this.dgvDevice.RowHeadersWidth = 51;
            this.dgvDevice.RowTemplate.Height = 35;
            this.dgvDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevice.Size = new System.Drawing.Size(1343, 588);
            this.dgvDevice.TabIndex = 239;
            // 
            // colID
            // 
            this.colID.HeaderText = "#";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEmpNo
            // 
            this.colEmpNo.HeaderText = "ID";
            this.colEmpNo.MinimumWidth = 6;
            this.colEmpNo.Name = "colEmpNo";
            this.colEmpNo.ReadOnly = true;
            this.colEmpNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEmpName
            // 
            this.colEmpName.HeaderText = "Name";
            this.colEmpName.MinimumWidth = 6;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPayInYear
            // 
            this.colPayInYear.HeaderText = "Department";
            this.colPayInYear.MinimumWidth = 6;
            this.colPayInYear.Name = "colPayInYear";
            this.colPayInYear.ReadOnly = true;
            this.colPayInYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPayInMonth
            // 
            this.colPayInMonth.HeaderText = "Position";
            this.colPayInMonth.MinimumWidth = 6;
            this.colPayInMonth.Name = "colPayInMonth";
            this.colPayInMonth.ReadOnly = true;
            this.colPayInMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // payInStep
            // 
            this.payInStep.HeaderText = "Team";
            this.payInStep.MinimumWidth = 6;
            this.payInStep.Name = "payInStep";
            this.payInStep.ReadOnly = true;
            this.payInStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboEmployeeStatus);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtEmployeeNo);
            this.panel1.Controls.Add(this.comboCategory);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboPayslipOption);
            this.panel1.Controls.Add(this.cboDepartment);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1343, 40);
            this.panel1.TabIndex = 260;
            // 
            // cboEmployeeStatus
            // 
            this.cboEmployeeStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployeeStatus.FormattingEnabled = true;
            this.cboEmployeeStatus.Items.AddRange(new object[] {
            "All",
            "MA",
            "Resigned",
            "Exclude Both"});
            this.cboEmployeeStatus.Location = new System.Drawing.Point(1095, 9);
            this.cboEmployeeStatus.Name = "cboEmployeeStatus";
            this.cboEmployeeStatus.Size = new System.Drawing.Size(133, 21);
            this.cboEmployeeStatus.TabIndex = 263;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(981, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 19);
            this.label10.TabIndex = 262;
            this.label10.Text = "Employee Status";
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Location = new System.Drawing.Point(102, 5);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(143, 26);
            this.txtEmployeeNo.TabIndex = 261;
            this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
            // 
            // comboCategory
            // 
            this.comboCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Items.AddRange(new object[] {
            "Payslip",
            "Payslip (Option 1)",
            "Payslip (Option 2)"});
            this.comboCategory.Location = new System.Drawing.Point(832, 9);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(133, 21);
            this.comboCategory.TabIndex = 260;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(765, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 259;
            this.label8.Text = "Category";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 19);
            this.label9.TabIndex = 251;
            this.label9.Text = "Employee No";
            // 
            // FRMMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 675);
            this.Controls.Add(this.dgvDevice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBoxPrinters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FRMMAIN";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MAXX HCM - Payslip Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMMAIN_Load);
            this.Shown += new System.EventHandler(this.FRMMAIN_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Timer timerPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUploadStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPrinters;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboPayslipOption;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayInYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayInMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn payInStep;
        private System.Windows.Forms.ComboBox cboEmployeeStatus;
        private System.Windows.Forms.Label label10;
    }
}

