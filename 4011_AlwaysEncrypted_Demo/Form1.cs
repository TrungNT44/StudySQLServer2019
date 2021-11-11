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
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string user, string role)
        {
            InitializeComponent();
            this.user = user;
            this.role = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.AddStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SqlParameter studentCode = new SqlParameter("@StudentCode", SqlDbType.NVarChar, 32)
                    //{
                    //    Value = textBoxMssv.Text
                    //};
                    //SqlParameter fullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 500)
                    //{
                    //    Value = textBoxHoTen.Text
                    //};
                    //SqlParameter IdCardNo = new SqlParameter("@IDCardNo", SqlDbType.Int)
                    //{
                    //    Value = Convert.ToInt32(textBoxCMT.Text)
                    //};

                    //cmd.Parameters.Add(studentCode);
                    //cmd.Parameters.Add(fullName);
                    //cmd.Parameters.Add(IdCardNo);

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
                    //textBoxMssv.Clear();
                    //textBoxHoTen.Clear();
                    //textBoxCMT.Clear();
                    ClearTextBoxes();
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
    }
}
