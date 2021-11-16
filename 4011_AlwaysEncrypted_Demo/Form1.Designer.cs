namespace AE1
{
    partial class MainForm
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
            this.aEDataSet = new AE1.AEDataSet();
            this.aEDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.textBoxMssv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCMT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNgaySinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textboxGioiTinh = new System.Windows.Forms.TextBox();
            this.textBoxDienThoai = new System.Windows.Forms.TextBox();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxLop = new System.Windows.Forms.TextBox();
            this.textBoxKhoa = new System.Windows.Forms.TextBox();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.queriesTableAdapter1 = new AE1.AEDataSetTableAdapters.QueriesTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aEDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // aEDataSet
            // 
            this.aEDataSet.DataSetName = "AEDataSet";
            this.aEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aEDataSetBindingSource
            // 
            this.aEDataSetBindingSource.DataSource = this.aEDataSet;
            this.aEDataSetBindingSource.Position = 0;
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNew.Location = new System.Drawing.Point(34, 437);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(147, 71);
            this.buttonAddNew.TabIndex = 0;
            this.buttonAddNew.Text = "Thêm mới";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // textBoxMssv
            // 
            this.textBoxMssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxMssv.Location = new System.Drawing.Point(140, 15);
            this.textBoxMssv.Name = "textBoxMssv";
            this.textBoxMssv.Size = new System.Drawing.Size(267, 29);
            this.textBoxMssv.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Họ tên";
            // 
            // textBoxHoTen
            // 
            this.textBoxHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxHoTen.Location = new System.Drawing.Point(140, 69);
            this.textBoxHoTen.Name = "textBoxHoTen";
            this.textBoxHoTen.Size = new System.Drawing.Size(267, 29);
            this.textBoxHoTen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã số SV";
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStudent.Location = new System.Drawing.Point(446, 13);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(214, 32);
            this.btnSearchStudent.TabIndex = 5;
            this.btnSearchStudent.Text = "Tra cứu theo mã số SV";
            this.btnSearchStudent.UseVisualStyleBackColor = true;
            this.btnSearchStudent.Click += new System.EventHandler(this.buttonGetStudentInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "CMT";
            // 
            // textBoxCMT
            // 
            this.textBoxCMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxCMT.Location = new System.Drawing.Point(140, 114);
            this.textBoxCMT.Name = "textBoxCMT";
            this.textBoxCMT.Size = new System.Drawing.Size(267, 29);
            this.textBoxCMT.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(27, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ngày sinh";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxNgaySinh
            // 
            this.textBoxNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxNgaySinh.Location = new System.Drawing.Point(140, 163);
            this.textBoxNgaySinh.Name = "textBoxNgaySinh";
            this.textBoxNgaySinh.Size = new System.Drawing.Size(267, 29);
            this.textBoxNgaySinh.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(27, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Giới tính";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(27, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(27, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Địa chỉ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(27, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Lớp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(29, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "Khoa";
            // 
            // textboxGioiTinh
            // 
            this.textboxGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textboxGioiTinh.Location = new System.Drawing.Point(140, 210);
            this.textboxGioiTinh.Name = "textboxGioiTinh";
            this.textboxGioiTinh.Size = new System.Drawing.Size(267, 29);
            this.textboxGioiTinh.TabIndex = 19;
            // 
            // textBoxDienThoai
            // 
            this.textBoxDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxDienThoai.Location = new System.Drawing.Point(140, 258);
            this.textBoxDienThoai.Name = "textBoxDienThoai";
            this.textBoxDienThoai.Size = new System.Drawing.Size(267, 29);
            this.textBoxDienThoai.TabIndex = 20;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxDiaChi.Location = new System.Drawing.Point(140, 306);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(267, 29);
            this.textBoxDiaChi.TabIndex = 21;
            // 
            // textBoxLop
            // 
            this.textBoxLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxLop.Location = new System.Drawing.Point(140, 351);
            this.textBoxLop.Name = "textBoxLop";
            this.textBoxLop.Size = new System.Drawing.Size(267, 29);
            this.textBoxLop.TabIndex = 22;
            // 
            // textBoxKhoa
            // 
            this.textBoxKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxKhoa.Location = new System.Drawing.Point(140, 392);
            this.textBoxKhoa.Name = "textBoxKhoa";
            this.textBoxKhoa.Size = new System.Drawing.Size(267, 29);
            this.textBoxKhoa.TabIndex = 23;
            // 
            // buttonReload
            // 
            this.buttonReload.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReload.Location = new System.Drawing.Point(606, 437);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(163, 71);
            this.buttonReload.TabIndex = 24;
            this.buttonReload.Text = "Làm mới";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(245, 437);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(107, 71);
            this.buttonEdit.TabIndex = 25;
            this.buttonEdit.Text = "Sửa";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(421, 437);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 71);
            this.buttonDelete.TabIndex = 26;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(446, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 358);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(877, 25);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(114, 32);
            this.btnSignOut.TabIndex = 28;
            this.btnSignOut.Text = "Đăng xuất";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(873, 1);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(49, 21);
            this.labelUser.TabIndex = 29;
            this.labelUser.Text = "User: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 520);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.textBoxKhoa);
            this.Controls.Add(this.textBoxLop);
            this.Controls.Add(this.textBoxDiaChi);
            this.Controls.Add(this.textBoxDienThoai);
            this.Controls.Add(this.textboxGioiTinh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNgaySinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCMT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearchStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHoTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMssv);
            this.Controls.Add(this.buttonAddNew);
            this.Name = "MainForm";
            this.Text = "Demo tính năng Always Encryted trong SQL Server 2019";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrom_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aEDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource aEDataSetBindingSource;
        private AEDataSet aEDataSet;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.TextBox textBoxMssv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCMT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNgaySinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textboxGioiTinh;
        private System.Windows.Forms.TextBox textBoxDienThoai;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.TextBox textBoxLop;
        private System.Windows.Forms.TextBox textBoxKhoa;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private AEDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label labelUser;
    }
}

