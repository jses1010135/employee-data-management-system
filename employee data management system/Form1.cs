using employee_data_management_system.BLL;
using employee_data_management_system.models;

namespace employee_data_management_system
{

    public partial class Form1 : Form
    {
        // --- 變數宣告區 ---
        private bool _isAddingNew = false;    // 模式開關：記錄現在是不是在「新增員工」的狀態
        private byte[] _tempPhotoBytes = null; // 暫存區：用來捧著新員工的照片，直到按下存檔
        private bool _isInitializing = true;
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private List<Employee> employees;
        private int currentIndex = 0;
        private bool _isHovering = false; // 記錄滑鼠是否懸停在照片上
        // --- 變數宣告區 (集中放在最上方) ---
        // --- 建構子 ---
        public Form1()
        {
            InitializeComponent();
        }

        // --- 畫面載入事件 ---
        private void Form1_Load(object sender, EventArgs e)
        {
            _isInitializing = true; // 1. 開啟狀態：程式正在初始化


            employees = employeeBLL.GetAllEmployees();
            if (employees != null && employees.Count > 0)
            {
                currentIndex = 0;
                DisplayEmployee(currentIndex);
            }

            // 1. 取得目前畫面上正在顯示的這位員工
            Employee currentEmp = employees[currentIndex];

            // 2. 透過 BLL 撈出他的責任區清單，並綁定給下方的表格
            dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);

            // 3. 透過 BLL 撈取所有的業務區
            List<Territory> allTerritories = employeeBLL.GetAllTerritories();

            // 4. 設定顯示與隱藏的值
            cboTerritories.DisplayMember = "TerritoryDescription";
            cboTerritories.ValueMember = "TerritoryID";

            // 5. 綁定給 ComboBox
            cboTerritories.DataSource = allTerritories;

            _isInitializing = false; // 2. 狀態解除：資料綁定完畢
        }

        // --- 顯示員工資料方法 ---
        private void DisplayEmployee(int index)
        {
            _isAddingNew = false; // 只要顯示現有員工，就關閉新增模式
            if (employees == null || index < 0 || index >= employees.Count)
                return;

            Employee emp = employees[index];

           
            lblEmployeeInfo.Text = $"目前員工編號: {emp.EmployeeID}";

            // 2. 將名字分別填入左上角或畫面上的 TextBox 中
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;

            // 3. 顯示照片
            pictureBoxEmployee.Image = employeeBLL.GetEmployeePhoto(emp.Photo);
        }

        // --- 導覽按鈕事件 ---
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;
            currentIndex = 0;
            DisplayEmployee(currentIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;

            if (currentIndex < employees.Count - 1)
            {
                currentIndex++;
                DisplayEmployee(currentIndex);
            }
            Employee currentEmp = employees[currentIndex];
            dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;

            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayEmployee(currentIndex);
            }
            Employee currentEmp = employees[currentIndex];
            dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;

            currentIndex = employees.Count - 1;
            DisplayEmployee(currentIndex);

            Employee currentEmp = employees[currentIndex];
            dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);
        }

        // --- 新增、更新與照片處理事件 ---
        private void btnBrowse_Click_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("請先選擇一位員工。");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "請選擇員工照片";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] newPhotoBytes = employeeBLL.ConvertFileToByteArray(ofd.FileName);
                    pictureBoxEmployee.Image = employeeBLL.GetEmployeePhoto(newPhotoBytes);
                    employees[currentIndex].Photo = newPhotoBytes;

                    MessageBox.Show("照片已載入畫面，請記得點選「更新資料」來存入資料庫！");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("目前沒有可更新的資料。");
                return;
            }

            Employee currentEmp = employees[currentIndex];
            bool isSuccess = employeeBLL.UpdateEmployee(currentEmp);

            if (isSuccess)
            {
                MessageBox.Show("新員工資料已成功存入資料庫！");

                // 1. 重新從資料庫  撈取最新名單（包含剛新增的那位）
                employees = employeeBLL.GetAllEmployees();

                // 2. 將游標  移到最後一筆（剛新增的員工）
                currentIndex = employees.Count - 1;

                // 3. 更新畫面上的文字框與照片
                DisplayEmployee(currentIndex);

                // 4. 重新撈取該新員工的責任區（目前是空的），更新表格 
                Employee _currentEmp = employees[currentIndex];
                dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);

                // 5. 啟用責任區下拉選單 ，讓使用者開始指派
                cboTerritories.Enabled = true;
            }
            else
            {
                MessageBox.Show("更新失敗，請稍後再試。");
            }
        }

        private void btnAddNew_Click_Click(object sender, EventArgs e)
        {
            _isAddingNew = true;       // 1. 開啟新增模式！
            _tempPhotoBytes = null;    // 2. 清空照片暫存區
            lblEmployeeInfo.Text = "正在新增新員工..."; // 3. 更新標籤提示
            txtFirstName.Text = "";
            txtLastName.Text = "";
            pictureBoxEmployee.Image = null;
            dgvTerritories.DataSource = null;
            cboTerritories.SelectedIndex = -1;

            cboTerritories.Enabled = false; // 禁止選擇責任區，直到新增員工成功

            MessageBox.Show("請在欄位中輸入新員工姓名，點擊「瀏覽...」選擇照片，最後按下「新增存檔」。");
        }

        private void btnSaveNew_Click_Click(object sender, EventArgs e)
        {
            // 萬能存檔鍵！
            if (_isAddingNew == true)
            {
                // === 【新增 (Insert) 邏輯】 ===
                Employee newEmp = new Employee();
                newEmp.FirstName = txtFirstName.Text.Trim();
                newEmp.LastName = txtLastName.Text.Trim();
                newEmp.Photo = _tempPhotoBytes;

                bool isSuccess = employeeBLL.InsertEmployee(newEmp);

                if (isSuccess)
                {
                    MessageBox.Show("新員工資料已成功存入資料庫！");

                    employees = employeeBLL.GetAllEmployees();
                    currentIndex = employees.Count - 1;
                    DisplayEmployee(currentIndex);

                    Employee currentEmp = employees[currentIndex];
                    dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);
                    cboTerritories.Enabled = true;
                }
                else
                {
                    MessageBox.Show("新增失敗，請稍後再試。");
                }
            }
            else
            {
                // === 【修改 (Update) 邏輯】 ===
                Employee currentEmp = employees[currentIndex];
                currentEmp.FirstName = txtFirstName.Text.Trim();
                currentEmp.LastName = txtLastName.Text.Trim();

                if (_tempPhotoBytes != null)
                {
                    currentEmp.Photo = _tempPhotoBytes;
                }

                bool isSuccess = employeeBLL.UpdateEmployee(currentEmp);

                if (isSuccess)
                {
                    MessageBox.Show("員工資料更新成功！");

                    employees = employeeBLL.GetAllEmployees();
                    DisplayEmployee(currentIndex);
                }
                else
                {
                    MessageBox.Show("更新失敗，請稍後再試。");
                }
            }
        }

        // --- 責任區下拉選單變更事件 ---
        private void cboTerritories_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing == true)
            {
                return;
            }

            if (cboTerritories.SelectedValue == null) return;

            Employee currentEmp = employees[currentIndex];
            string selectedTerritoryId = cboTerritories.SelectedValue.ToString();

            if (employeeBLL.CheckTerritoryExists(currentEmp.EmployeeID, selectedTerritoryId))
            {
                MessageBox.Show("該員工已擁有此責任區。");
                return;
            }

            bool isSuccess = employeeBLL.InsertEmployeeTerritory(currentEmp.EmployeeID, selectedTerritoryId);

            if (isSuccess)
            {
                MessageBox.Show("責任區新增成功！");
                dgvTerritories.DataSource = employeeBLL.GetEmployeeTerritories(currentEmp);
            }
        }

        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "請選擇員工照片";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 將實體圖片轉換成 byte[]，並顯示在畫面上預覽
                    byte[] newPhotoBytes = employeeBLL.ConvertFileToByteArray(ofd.FileName);
                    pictureBoxEmployee.Image = employeeBLL.GetEmployeePhoto(newPhotoBytes);

                    // ??? 在這裡，我們需要根據「模式開關」來決定照片要存在哪裡！
                    if (_isAddingNew == true)
                    {
                        // 1. 如果正在「新增模式」，我們應該把 newPhotoBytes 存進哪一個剛剛宣告的變數裡？
                        _tempPhotoBytes = newPhotoBytes;
                    }
                    else
                    {
                        // 2. 如果是「編輯模式」，我們應該把 newPhotoBytes 存回目前這位員工的物件屬性中？
                        employees[currentIndex].Photo = newPhotoBytes;
                    }
                }
            }
        }

        private void pictureBoxEmployee_Paint(object sender, PaintEventArgs e)
        {
            // 準備一個「字串格式」設定器，並開啟「垂直排列」功能
            StringFormat verticalFormat = new StringFormat();
            verticalFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            // 1. 如果沒有圖片：永遠顯示預設提示
            if (pictureBoxEmployee.Image == null)
            {
                string hint = "點擊上傳照片";
                Font font = new Font("微軟正黑體", 12, FontStyle.Regular);
                Brush brush = Brushes.Gray;
                PointF location = new PointF(60, 60);

                e.Graphics.DrawString(hint, font, brush, location, verticalFormat);
            }
            // 2. 如果「有圖片」而且「滑鼠正好懸停在上面」
            else if (_isHovering == true)
            {
                // 準備半透明黑色遮罩的畫刷
                Brush overlayBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));

                // 準備白色提示文字的設定
                string hoverHint = "更換照片";
                Font hoverFont = new Font("微軟正黑體", 12, FontStyle.Bold);
                Brush textBrush = Brushes.White;
                PointF hoverLocation = new PointF(25, 60);

                // ??? 在這裡畫出半透明遮罩 (FillRectangle)
                e.Graphics.FillRectangle(overlayBrush, pictureBoxEmployee.ClientRectangle);
                // ??? 在這裡畫出白色提示文字 (DrawString)
                e.Graphics.DrawString(hoverHint, hoverFont, textBrush, hoverLocation, verticalFormat);
            }
        }

        private void pictureBoxEmployee_MouseEnter(object sender, EventArgs e)
        {
            _isHovering = true;
            pictureBoxEmployee.Invalidate(); // 觸發重繪，讓提示文字消失

        }

        private void pictureBoxEmployee_MouseLeave(object sender, EventArgs e)
        {
            _isHovering = false;
            pictureBoxEmployee.Invalidate(); // 觸發重繪，讓提示文字重新出現

        }
    }
}