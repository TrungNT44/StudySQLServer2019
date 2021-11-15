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

        public MainForm(string user, string role)
        {
            InitializeComponent();
            this.user = user;
            this.role = role;
            var isAdmin = role == "ADMIN";
            buttonAddNew.Visible = isAdmin;
            buttonEdit.Visible = isAdmin;
            buttonDelete.Visible = isAdmin;
            buttonReload.Visible = isAdmin;
            DisplayData();
        }

        //Display Data in DataGridView
        private void DisplayData()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select StudentCode	as 'Mã SV', FullName as 'Họ tên', IDCardNo as 'CMT',	BirthDate as 'Ngày sinh',	Gender as 'Giới tính',	Mobile	as 'Số ĐT', Address as 'Địa chỉ',	Class as 'Lớp', Faculty as 'Khoa'  from dbo.StudentInfo", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
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
            textboxGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxLop.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
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
                            new SqlParameter() {ParameterName = "@FullName", SqlDbType = SqlDbType.NVarChar, Size = 500, Value = textBoxHoTen.Text},
                            new SqlParameter() {ParameterName = "@IDCardNo", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxCMT.Text},
                            new SqlParameter() {ParameterName = "@BirthDate", SqlDbType = SqlDbType.NVarChar, Size = 32, Value = textBoxNgaySinh.Text},
                            new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = textboxGioiTinh.Text},
                            new SqlParameter() {ParameterName = "@Mobile", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxDienThoai.Text},
                            new SqlParameter() {ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Size = 1000, Value = textBoxDiaChi.Text},
                            new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxLop.Text},
                            new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxKhoa.Text}
                        };
                    if (sp != null)
                        cmd.Parameters.AddRange(sp.ToArray());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sinh viên mới đã được thêm thành công");
                    DisplayData();
                    ClearTextBoxes();
                }
                con.Close();
            }
        }

        private void buttonGetStudentInfo_Click(object sender, EventArgs e)
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
                        Value = textBoxMssv.Text
                    };
                    cmd.Parameters.Add(studentCode);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            textBoxMssv.Text = rdr["StudentCode"].ToString();
                            textBoxHoTen.Text = rdr["FullName"].ToString();
                            textBoxCMT.Text = rdr["IDCardNo"].ToString();
                            textBoxNgaySinh.Text = rdr["BirthDate"].ToString();
                            textboxGioiTinh.Text = rdr["Gender"].ToString();
                            textBoxDienThoai.Text = rdr["Mobile"].ToString();
                            textBoxDiaChi.Text = rdr["Address"].ToString();
                            textBoxLop.Text = rdr["Class"].ToString();
                            textBoxKhoa.Text = rdr["Faculty"].ToString();
                        }
                        MessageBox.Show("Tra cứu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào");
                    }
                    

                }
                con.Close();
            }
        }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void MainFrom_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

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
                DisplayData();
                ClearTextBoxes();
                con.Close();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
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
                using (SqlCommand cmd = new SqlCommand("dbo.UpdateStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<SqlParameter> sp = new List<SqlParameter>()
                        {
                            new SqlParameter() {ParameterName = "@StudentCode", SqlDbType = SqlDbType.NVarChar, Size = 32, Value= textBoxMssv.Text},
                            new SqlParameter() {ParameterName = "@FullName", SqlDbType = SqlDbType.NVarChar, Size = 500, Value = textBoxHoTen.Text},
                            new SqlParameter() {ParameterName = "@IDCardNo", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxCMT.Text},
                            new SqlParameter() {ParameterName = "@BirthDate", SqlDbType = SqlDbType.NVarChar, Size = 32, Value = textBoxNgaySinh.Text},
                            new SqlParameter() {ParameterName = "@Gender", SqlDbType = SqlDbType.NVarChar, Size = 20, Value = textboxGioiTinh.Text},
                            new SqlParameter() {ParameterName = "@Mobile", SqlDbType = SqlDbType.NVarChar,  Size = 30, Value = textBoxDienThoai.Text},
                            new SqlParameter() {ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Size = 1000, Value = textBoxDiaChi.Text},
                            new SqlParameter() {ParameterName = "@Class", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxLop.Text},
                            new SqlParameter() {ParameterName = "@Faculty", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = textBoxKhoa.Text}
                        };
                    if (sp != null)
                        cmd.Parameters.AddRange(sp.ToArray());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sinh viên đã được cập nhật thành công");
                    DisplayData();
                    ClearTextBoxes();
                }
                con.Close();
            }
        }
    }
}
