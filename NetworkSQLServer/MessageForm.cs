using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkSQLServer
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        public void SetStatus(string message)
        {
            label1.Text = message;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
