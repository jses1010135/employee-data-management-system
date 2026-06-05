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
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTerritories).BeginInit();
            SuspendLayout();
            // 
            // lblEmployeeInfo
            // 
            lblEmployeeInfo.AutoSize = true;
            lblEmployeeInfo.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmployeeInfo.ForeColor = SystemColors.ControlLight;
            lblEmployeeInfo.Location = new Point(74, 44);
            lblEmployeeInfo.Name = "lblEmployeeInfo";
            lblEmployeeInfo.Size = new Size(180, 74);
            lblEmployeeInfo.TabIndex = 0;
            lblEmployeeInfo.Text = "label1";
            // 
            // btnFirst
            // 
            btnFirst.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFirst.Location = new Point(418, 368);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(148, 127);
            btnFirst.TabIndex = 1;
            btnFirst.Text = "第一筆";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += BtnFirst_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(224, 368);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(148, 127);
            btnNext.TabIndex = 2;
            btnNext.Text = "下一筆";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrev.Location = new Point(73, 368);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(148, 127);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "上一筆";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnLast
            // 
            btnLast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLast.Location = new Point(570, 368);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(150, 129);
            btnLast.TabIndex = 4;
            btnLast.Text = "最後一筆";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // pictureBoxEmployee
            // 
            pictureBoxEmployee.BackColor = SystemColors.AppWorkspace;
            pictureBoxEmployee.Location = new Point(968, 44);
            pictureBoxEmployee.Name = "pictureBoxEmployee";
            pictureBoxEmployee.Size = new Size(228, 276);
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
            btnAddNew_Click.Location = new Point(778, 366);
            btnAddNew_Click.Name = "btnAddNew_Click";
            btnAddNew_Click.Size = new Size(148, 127);
            btnAddNew_Click.TabIndex = 8;
            btnAddNew_Click.Text = "新增空白";
            btnAddNew_Click.UseVisualStyleBackColor = true;
            btnAddNew_Click.Click += btnAddNew_Click_Click;
            // 
            // btnSaveNew_Click
            // 
            btnSaveNew_Click.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveNew_Click.Location = new Point(968, 366);
            btnSaveNew_Click.Name = "btnSaveNew_Click";
            btnSaveNew_Click.Size = new Size(228, 129);
            btnSaveNew_Click.TabIndex = 9;
            btnSaveNew_Click.Text = "存檔";
            btnSaveNew_Click.UseVisualStyleBackColor = true;
            btnSaveNew_Click.Click += btnSaveNew_Click_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = SystemColors.GrayText;
            txtFirstName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(73, 249);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(299, 71);
            txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = SystemColors.GrayText;
            txtLastName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(418, 249);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(508, 71);
            txtLastName.TabIndex = 11;
            // 
            // dgvTerritories
            // 
            dgvTerritories.AllowUserToOrderColumns = true;
            dgvTerritories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTerritories.BackgroundColor = SystemColors.ControlLightLight;
            dgvTerritories.ColumnHeadersHeight = 34;
            dgvTerritories.Location = new Point(74, 519);
            dgvTerritories.Name = "dgvTerritories";
            dgvTerritories.RowHeadersWidth = 62;
            dgvTerritories.Size = new Size(1122, 331);
            dgvTerritories.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(1276, 888);
            Controls.Add(dgvTerritories);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnSaveNew_Click);
            Controls.Add(btnAddNew_Click);
            Controls.Add(pictureBoxEmployee);
            Controls.Add(btnLast);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(btnFirst);
            Controls.Add(lblEmployeeInfo);
            Name = "Form1";
            Text = "員工資料管理系統";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTerritories).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
