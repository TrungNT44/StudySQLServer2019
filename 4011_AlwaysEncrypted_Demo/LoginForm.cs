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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["AE1.Properties.Settings.SQLServer2021Connection"].ToString();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetUserByUsername", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter user = new SqlParameter("@Username", SqlDbType.NVarChar, 100)
                    {
                        Value = textBoxUser.Text
                    };
                    SqlParameter pass = new SqlParameter("@Password", SqlDbType.NVarChar, 200)
                    {
                        Value = textboxPassword.Text
                    };
                    cmd.Parameters.Add(user);
                    cmd.Parameters.Add(pass);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        while (rdr.Read())
                        {
                            MainForm mf = new MainForm(rdr["username"].ToString(), rdr["role"].ToString());
                            this.Hide();
                            mf.ShowDialog();
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Tên user hoặc password không đúng");
                    }


                }
                con.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void onLoginFrom_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
