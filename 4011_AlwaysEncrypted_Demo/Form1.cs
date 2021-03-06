using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE1
{
    public partial class MainForm : Form
    {
        string user;
        string role;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record
        string StudentCode = "";
        public MainForm()
        {
            InitializeComponent();            
        }

        // khởi tạo form chính
        public MainForm(string user, string role)
        {
            InitializeComponent();
            this.user = user;
            this.role = role;
            labelUser.Text = "User: " + user;
            DisplayData();
            // nếu user ko phải ADMIN, ko cho chỉnh sửa thông tin sv
            if (role != "ADMIN")
            {
                DisableButton();
                DisableTextBoxes();
            }
        }

        //Display Data in DataGridView
        private void DisplayData()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetStudentByCode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter studentCode = new SqlParameter("@StudentCode", SqlDbType.NVarChar, 32)
                    {
                        Value = textBoxMssv.Text == "" ? null : textBoxMssv.Text
                    };
                    SqlParameter username = new SqlParameter("@Username", SqlDbType.NVarChar, 100)
                    {
                        Value = user
                    };
                    cmd.Parameters.Add(studentCode);
                    cmd.Parameters.Add(username);
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;


                }
                // lấy dữ liệu hiển thị combo box chọn Khoa
                SqlCommand cmdGetValueForCombobox = new SqlCommand("select distinct Faculty from dbo.ClassInfo", con);
                SqlDataAdapter da = new SqlDataAdapter(cmdGetValueForCombobox);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cbboxKhoa.DataSource = ds.Tables[0];
                cbboxKhoa.DisplayMember = "Faculty";
                cbboxKhoa.ValueMember = "Faculty";
                cbboxKhoa.SelectedIndex = -1;
                cmdGetValueForCombobox.ExecuteNonQuery();

                con.Close();
            }
        }

        //dataGridView1 RowHeaderMouseClick Event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StudentCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxMssv.Text = StudentCode;
            textBoxHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxCMT.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxNgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //textboxGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbboxGioitinh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //textBoxLop.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //textBoxKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            cbboxLop.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            cbboxKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        // thêm sinh viên mới
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (cbboxLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp");
                return;
            }

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.AddStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<SqlParameter> sp = new List<SqlParameter>()
                        {
                            new SqlParameter() {ParameterName = "@StudentCode", SqlDbType = SqlDbType.NVarChar, Size = 32, Value= textBoxMssv.Text},
                            new SqlParameter() {ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Size = 200, Value= textBoxMssv.Text},
                            new SqlParameter() {ParameterName = "@FullName", SqlDbType = SqlDbType.NVarChar, Size = 500, Value = textBoxHoTen.Text},
                            new SqlParameter() {ParameterName = "@IDCardNo", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxCMT.Text},
                            new SqlParameter() {ParameterName = "@BirthDate", SqlDbType = SqlDbType.NVarChar, Size = 32, Value = textBoxNgaySinh.Text},
                            //new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = textboxGioiTinh.Text},
                            new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = cbboxGioitinh.Text},
                            new SqlParameter() {ParameterName = "@Mobile", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxDienThoai.Text},
                            new SqlParameter() {ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Size = 1000, Value = textBoxDiaChi.Text},
                            //new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxLop.Text},
                            new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = cbboxLop.Text},
                            //new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxKhoa.Text}
                            new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = cbboxKhoa.Text}
                        };
                    if (sp != null)
                        cmd.Parameters.AddRange(sp.ToArray());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sinh viên mới đã được thêm thành công");
                    ClearTextBoxes();
                    DisplayData();
                }
                con.Close();
            }
        }

        // xóa sinh viên
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxMssv.Text == "")
            {
                MessageBox.Show("Mã số sinh viên không được trống");
                return;
            }
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from dbo.StudentInfo where StudentCode=@StudentCode", con);
                cmd.Parameters.AddWithValue("@StudentCode", StudentCode);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công");
                }
                ClearTextBoxes();
                DisplayData();
                con.Close();
            }
        }

        // cập nhật tt sinh viên
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxMssv.Text == "")
            {
                MessageBox.Show("Mã số sinh viên không được trống");
                return;
            }
            using (SqlConnection con = new SqlConnection())
            {
                if (cbboxLop.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn lớp");
                    return;
                }
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.UpdateStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<SqlParameter> sp = new List<SqlParameter>()
                        {
                            new SqlParameter() {ParameterName = "@StudentCode", SqlDbType = SqlDbType.NVarChar, Size = 32, Value= textBoxMssv.Text},
                            new SqlParameter() {ParameterName = "@FullName", SqlDbType = SqlDbType.NVarChar, Size = 500, Value = textBoxHoTen.Text},
                            new SqlParameter() {ParameterName = "@IDCardNo", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxCMT.Text},
                            new SqlParameter() {ParameterName = "@BirthDate", SqlDbType = SqlDbType.NVarChar, Size = 32, Value = textBoxNgaySinh.Text},
                            //new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = textboxGioiTinh.Text},
                            new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = cbboxGioitinh.Text},
                            new SqlParameter() {ParameterName = "@Mobile", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxDienThoai.Text},
                            new SqlParameter() {ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Size = 1000, Value = textBoxDiaChi.Text},
                            //new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxLop.Text},
                            new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = cbboxLop.Text},
                            //new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxKhoa.Text}
                            new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = cbboxKhoa.Text}
                        };
                    if (sp != null)
                        cmd.Parameters.AddRange(sp.ToArray());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sinh viên đã được cập nhật thành công");
                    ClearTextBoxes();
                    DisplayData();
                }
                con.Close();
            }
        }

        // lấy chi tiết thông tin sinh viên
        private void buttonGetStudentInfo_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // button reload
        private void buttonReload_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            DisplayData();
        }

        

        // clear nội dung textbox
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void DisableTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control == textBoxMssv) continue;
                    else if (control is TextBox)
                        (control as TextBox).ReadOnly = true;
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void DisableButton()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control == btnSignOut || control == btnSearchStudent) continue;
                    else if (control is Button)
                        (control as Button).Visible = false;
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        // nút thoát chương trình
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            Hide();
            user = null;
            role = null;
            loginForm.ShowDialog();
        }



        private void MainFrom_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // xử lý khi combo box Khoa thay đổi => reload danh sách lớp học
        private void cbboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadComboboxLophoc(cbboxKhoa.Text);
        }

        // reload danh sách lớp học
        private void reloadComboboxLophoc(string Faculty)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("select ClassName from dbo.ClassInfo where Faculty=@Faculty", con);
                cmd.Parameters.AddWithValue("@Faculty", Faculty);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cbboxLop.DataSource = ds.Tables[0];
                cbboxLop.DisplayMember = "ClassName";
                cbboxLop.ValueMember = "ClassName";
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        private void cbboxLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
