using employee_data_management_system.BLL;
using employee_data_management_system.models;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
            dgvTerritories.AutoGenerateColumns = false;
            _isInitializing = true; // 1. 開啟狀態：程式正在初始化

            txtFirstName.PlaceholderText = "請輸入名字 (First Name)";
            txtLastName.PlaceholderText = "請輸入姓氏 (Last Name)";
            employees = employeeBLL.GetAllEmployees();
            if (employees != null && employees.Count > 0)
            {
                currentIndex = 0;
                DisplayEmployee(currentIndex);

                // 1. 取得目前畫面上正在顯示的這位員工
                Employee currentEmp = employees[currentIndex];

                // 2. 透過 BLL 撈出他的責任區清單，並綁定給下方的表格
                var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
                dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);
            }

            // === 欄位替換手術開始 ===

            // 1. 去資料庫撈出「全公司所有的責任區」，當作下拉選單的選項
            List<Territory> allTerritories = employeeBLL.GetAllTerritories();

            // 2. 打造一個全新的下拉選單欄位
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.HeaderText = "責任區 (點擊選擇)"; // 表格上方的標題
            comboCol.DataPropertyName = "TerritoryId";   // ✨ 核心對應：這行告訴表格，這個欄位對應到員工現有清單的 TerritoryId

            // 3. 設定下拉選單裡面的「選項資料」
            comboCol.DataSource = allTerritories;
            comboCol.DisplayMember = "TerritoryDescription"; // 表面上給人看的文字 (例如: Westboro)
            comboCol.ValueMember = "TerritoryId";            // 骨子裡程式認的真實值 (例如: 01833)

            // 4. 拔除原本自動生成的舊文字欄位 (預防重複顯示)
            if (dgvTerritories.Columns.Contains("TerritoryId"))
            {
                dgvTerritories.Columns.Remove("TerritoryId");
            }
            if (dgvTerritories.Columns.Contains("TerritoryDescription"))
            {
                dgvTerritories.Columns.Remove("TerritoryDescription");
            }

            // 5. 將我們做好的下拉選單欄位，正式裝進表格中！
            dgvTerritories.Columns.Add(comboCol);

            // === 欄位替換手術結束 ===



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
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;
            currentIndex = 0;
            DisplayEmployee(currentIndex);
            Employee currentEmp = employees[currentIndex];
            var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
            dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);





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
            var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
            dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);
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
            var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
            dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (employees == null || employees.Count == 0) return;

            currentIndex = employees.Count - 1;
            DisplayEmployee(currentIndex);

            Employee currentEmp = employees[currentIndex];
            var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
            dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);
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

            MessageBox.Show("請在欄位中輸入新員工姓名，圖片欄選擇照片，最後按下「存檔」。");
        }

        private void btnSaveNew_Click_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
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

                    _isAddingNew = false; // 
                    _tempPhotoBytes = null; // 清空照片暫存

                    employees = employeeBLL.GetAllEmployees();
                    currentIndex = employees.Count - 1;
                    DisplayEmployee(currentIndex);

                    Employee currentEmp = employees[currentIndex];
                    var myTerritoryList = employeeBLL.GetEmployeeTerritories(currentEmp);
                    dgvTerritories.DataSource = new BindingList<Territory>(myTerritoryList);
                    comboCol.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("新增失敗，請稍後再試。");
                }
            }
            else
            {
                // === 【修改 (Update) 邏輯】 ===
                if (employees == null || employees.Count == 0) return; // 避免目前沒有員工的狀況
                Employee currentEmp = employees[currentIndex];
                currentEmp.FirstName = txtFirstName.Text.Trim();
                currentEmp.LastName = txtLastName.Text.Trim();

                // 1. 從表格中把資料拿出來，並明確告訴 C# 說：「這是一包 BindingList<Territory>」 (使用 as 安全轉型)
                BindingList<Territory> currentBindingList = dgvTerritories.DataSource as BindingList<Territory>;

                // 2. 利用 .ToList() 將它轉換回 BLL 需要的標準 List (加上 null 防呆)
                List<Territory> territoriesToSave = currentBindingList != null ? currentBindingList.ToList() : new List<Territory>();

                // 加入檢測：確認清單中是否有重複的責任區 (TerritoryId)
                bool hasDuplicates = territoriesToSave.GroupBy(t => t.TerritoryId).Any(g => g.Count() > 1);
                if (hasDuplicates)
                {
                    // 若有重複，阻擋存檔並提示用戶       
                    MessageBox.Show("無法儲存！您新增了已存在的責任區，請移除重複的項目再試一次。", "重複選擇", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 終止目前的存檔動作
                }

                if (_tempPhotoBytes != null)
                {
                    currentEmp.Photo = _tempPhotoBytes;
                }
                bool isSuccess = employeeBLL.UpdateEmployee(currentEmp, territoriesToSave);

                if (isSuccess)
                {
                    MessageBox.Show("員工資料更新成功！");
                    _tempPhotoBytes = null; // ✅ 清空照片暫存，避免污染下一筆資料
                    employees = employeeBLL.GetAllEmployees();
                    DisplayEmployee(currentIndex);
                }
                else
                {
                    MessageBox.Show("更新失敗，請稍後再試。");
                }
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