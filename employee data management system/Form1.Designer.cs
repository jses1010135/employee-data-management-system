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
            cboTerritories = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTerritories).BeginInit();
            SuspendLayout();
            // 
            // lblEmployeeInfo
            // 
            lblEmployeeInfo.AutoSize = true;
            lblEmployeeInfo.Location = new Point(71, 42);
            lblEmployeeInfo.Margin = new Padding(2, 0, 2, 0);
            lblEmployeeInfo.Name = "lblEmployeeInfo";
            lblEmployeeInfo.Size = new Size(38, 15);
            lblEmployeeInfo.TabIndex = 0;
            lblEmployeeInfo.Text = "label1";
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(34, 277);
            btnFirst.Margin = new Padding(2, 2, 2, 2);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(78, 20);
            btnFirst.TabIndex = 1;
            btnFirst.Text = "第一筆";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(154, 277);
            btnNext.Margin = new Padding(2, 2, 2, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(78, 20);
            btnNext.TabIndex = 2;
            btnNext.Text = "下一筆";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(274, 277);
            btnPrev.Margin = new Padding(2, 2, 2, 2);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(78, 20);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "上一筆";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(400, 277);
            btnLast.Margin = new Padding(2, 2, 2, 2);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(78, 20);
            btnLast.TabIndex = 4;
            btnLast.Text = "最後一筆";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // pictureBoxEmployee
            // 
            pictureBoxEmployee.BackColor = SystemColors.AppWorkspace;
            pictureBoxEmployee.Location = new Point(732, 42);
            pictureBoxEmployee.Margin = new Padding(2, 2, 2, 2);
            pictureBoxEmployee.Name = "pictureBoxEmployee";
            pictureBoxEmployee.Size = new Size(105, 150);
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
            btnAddNew_Click.Location = new Point(520, 277);
            btnAddNew_Click.Margin = new Padding(2, 2, 2, 2);
            btnAddNew_Click.Name = "btnAddNew_Click";
            btnAddNew_Click.Size = new Size(78, 20);
            btnAddNew_Click.TabIndex = 8;
            btnAddNew_Click.Text = "新增空白";
            btnAddNew_Click.UseVisualStyleBackColor = true;
            btnAddNew_Click.Click += btnAddNew_Click_Click;
            // 
            // btnSaveNew_Click
            // 
            btnSaveNew_Click.Location = new Point(640, 277);
            btnSaveNew_Click.Margin = new Padding(2, 2, 2, 2);
            btnSaveNew_Click.Name = "btnSaveNew_Click";
            btnSaveNew_Click.Size = new Size(78, 20);
            btnSaveNew_Click.TabIndex = 9;
            btnSaveNew_Click.Text = "新增存檔";
            btnSaveNew_Click.UseVisualStyleBackColor = true;
            btnSaveNew_Click.Click += btnSaveNew_Click_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(182, 40);
            txtFirstName.Margin = new Padding(2, 2, 2, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(106, 23);
            txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(332, 40);
            txtLastName.Margin = new Padding(2, 2, 2, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(106, 23);
            txtLastName.TabIndex = 11;
            // 
            // dgvTerritories
            // 
            dgvTerritories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTerritories.Location = new Point(64, 370);
            dgvTerritories.Margin = new Padding(2, 2, 2, 2);
            dgvTerritories.Name = "dgvTerritories";
            dgvTerritories.RowHeadersWidth = 62;
            dgvTerritories.Size = new Size(773, 135);
            dgvTerritories.TabIndex = 12;
            // 
            // cboTerritories
            // 
            cboTerritories.FormattingEnabled = true;
            cboTerritories.Location = new Point(64, 333);
            cboTerritories.Margin = new Padding(2, 2, 2, 2);
            cboTerritories.Name = "cboTerritories";
            cboTerritories.Size = new Size(774, 23);
            cboTerritories.TabIndex = 13;
            cboTerritories.SelectedValueChanged += cboTerritories_SelectedValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 533);
            Controls.Add(cboTerritories);
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
            Margin = new Padding(2, 2, 2, 2);
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
        private ComboBox cboTerritories;
    }
}
