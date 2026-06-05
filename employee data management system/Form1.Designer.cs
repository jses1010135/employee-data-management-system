namespace employee_data_management_system
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEmployeeInfo = new Label();
            btnFirst = new Button();
            btnNext = new Button();
            btnPrev = new Button();
            btnLast = new Button();
            pictureBoxEmployee = new PictureBox();
            btnAddNew_Click = new Button();
            btnSaveNew_Click = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            dgvTerritories = new DataGridView();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTerritories).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmployeeInfo
            // 
            lblEmployeeInfo.AutoSize = true;
            lblEmployeeInfo.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmployeeInfo.ForeColor = SystemColors.ControlLight;
            lblEmployeeInfo.Location = new Point(679, 8);
            lblEmployeeInfo.Name = "lblEmployeeInfo";
            lblEmployeeInfo.Size = new Size(180, 74);
            lblEmployeeInfo.TabIndex = 0;
            lblEmployeeInfo.Text = "label1";
            // 
            // btnFirst
            // 
            btnFirst.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFirst.Location = new Point(1462, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(365, 199);
            btnFirst.TabIndex = 1;
            btnFirst.Text = "第一筆";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += BtnFirst_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(379, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(355, 199);
            btnNext.TabIndex = 2;
            btnNext.Text = "下一筆";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrev.Location = new Point(3, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(370, 199);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "上一筆";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnLast
            // 
            btnLast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLast.Location = new Point(740, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(355, 199);
            btnLast.TabIndex = 4;
            btnLast.Text = "最後一筆";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // pictureBoxEmployee
            // 
            pictureBoxEmployee.BackColor = SystemColors.AppWorkspace;
            pictureBoxEmployee.Location = new Point(2330, 0);
            pictureBoxEmployee.Name = "pictureBoxEmployee";
            pictureBoxEmployee.Size = new Size(228, 218);
            pictureBoxEmployee.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmployee.TabIndex = 5;
            pictureBoxEmployee.TabStop = false;
            pictureBoxEmployee.Click += pictureBoxEmployee_Click;
            pictureBoxEmployee.Paint += pictureBoxEmployee_Paint;
            pictureBoxEmployee.MouseEnter += pictureBoxEmployee_MouseEnter;
            pictureBoxEmployee.MouseLeave += pictureBoxEmployee_MouseLeave;
            // 
            // btnAddNew_Click
            // 
            btnAddNew_Click.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNew_Click.Location = new Point(1101, 3);
            btnAddNew_Click.Name = "btnAddNew_Click";
            btnAddNew_Click.Size = new Size(355, 199);
            btnAddNew_Click.TabIndex = 8;
            btnAddNew_Click.Text = "新增空白";
            btnAddNew_Click.UseVisualStyleBackColor = true;
            btnAddNew_Click.Click += btnAddNew_Click_Click;
            // 
            // btnSaveNew_Click
            // 
            btnSaveNew_Click.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveNew_Click.Location = new Point(2004, 3);
            btnSaveNew_Click.Name = "btnSaveNew_Click";
            btnSaveNew_Click.Size = new Size(554, 199);
            btnSaveNew_Click.TabIndex = 9;
            btnSaveNew_Click.Text = "存檔";
            btnSaveNew_Click.UseVisualStyleBackColor = true;
            btnSaveNew_Click.Click += btnSaveNew_Click_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = SystemColors.GrayText;
            txtFirstName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(379, 153);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(299, 71);
            txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = SystemColors.GrayText;
            txtLastName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(740, 153);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(508, 71);
            txtLastName.TabIndex = 11;
            // 
            // dgvTerritories
            // 
            dgvTerritories.AllowUserToOrderColumns = true;
            dgvTerritories.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTerritories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTerritories.BackgroundColor = SystemColors.ControlLightLight;
            dgvTerritories.ColumnHeadersHeight = 34;
            dgvTerritories.Location = new Point(0, 764);
            dgvTerritories.Name = "dgvTerritories";
            dgvTerritories.RowHeadersWidth = 62;
            dgvTerritories.Size = new Size(2728, 806);
            dgvTerritories.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(lblEmployeeInfo);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(pictureBoxEmployee);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(2728, 224);
            panel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8104219F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2599363F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2599363F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2599363F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.889904F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.5198727F));
            tableLayoutPanel1.Controls.Add(btnAddNew_Click, 3, 0);
            tableLayoutPanel1.Controls.Add(btnPrev, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSaveNew_Click, 5, 0);
            tableLayoutPanel1.Controls.Add(btnNext, 1, 0);
            tableLayoutPanel1.Controls.Add(btnFirst, 4, 0);
            tableLayoutPanel1.Controls.Add(btnLast, 2, 0);
            tableLayoutPanel1.Location = new Point(0, 554);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(2728, 216);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(2728, 1570);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dgvTerritories);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "員工資料管理系統";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTerritories).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblEmployeeInfo;
        private Button btnFirst;
        private Button btnNext;
        private Button btnPrev;
        private Button btnLast;
        private PictureBox pictureBoxEmployee;
        private Button btnAddNew_Click;
        private Button btnSaveNew_Click;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DataGridView dgvTerritories;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
