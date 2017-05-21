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
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-DOKL0OA; Database=TestJoin; User ID=sa; Password=123");
        SqlDataAdapter adt;
        DataTable ds;
        
        
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            try
            {
                conn.Open();
                adt = new SqlDataAdapter("select top 30 UName,Message from tbl_Chat order by id desc", conn);
                ds = new DataTable();
                adt.Fill(ds);
                dataGridView1.DataSource = ds;


                //com = new SqlCommand("select top 1 id from tbl_Chat order by id desc", conn);
                //id = com.ExecuteNonQuery();
                //MessageBox.Show(id.ToString());
                conn.Close();
            }
            catch (Exception)
            {
                timer1.Stop();
                conn.Close();
                MessageBox.Show("connection failed");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            timer1.Stop();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adt = new SqlDataAdapter("select top 30 UName,Message from tbl_Chat order by id desc", conn);
                ds = new DataTable();
                adt.Fill(ds);
                dataGridView1.DataSource = ds;

               
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            try
            {
                string s = "insert into tbl_Chat values('" + System.Net.Dns.GetHostName().ToString() + "', '" + textBox1.Text + "')";
                SqlCommand com = new SqlCommand(s, conn);

                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageForm f = new MessageForm();
                f.SetStatus("Sending failed");
                f.ShowDialog();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);
            }
        }
    }
}