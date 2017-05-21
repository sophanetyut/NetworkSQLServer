using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NetworkSQLServer
{
    public partial class TestConnection : Form
    {
        SqlConnection sqlConnection;
        MessageForm f = new MessageForm();
        MainForm mainForm = new MainForm();
        
        public TestConnection()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="sa"||textBox2.Text!="123")
            {
                f.SetStatus("Please check agian");
                f.ShowDialog();
                return;
            }
            sqlConnection = new SqlConnection("Server=DESKTOP-DOKL0OA; Database=TestJoin; User ID=sa; Password=123");
            try
            {
                sqlConnection.Open();
                #region a
                //try
                //{
                //    sqlCommand = new SqlCommand("select U_Name,U_Pass from tbl_pass where U_Name="+textBox1.Text+" and U_Pass=" + textBox2.Text,sqlConnection);
                //    ad = new SqlDataAdapter(sqlCommand);
                //    dt = new DataTable();
                //    ad.Fill(dt);


                //}
                //catch (Exception)
                //{
                //    f.SetStatus("Wrong user name or password");
                //    f.ShowDialog();
                //}
                #endregion
                f.SetStatus("you are connected");
                f.ShowDialog();
                sqlConnection.Close();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
            catch (Exception)
            {
                f.SetStatus("Connection failed");
                f.ShowDialog();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
