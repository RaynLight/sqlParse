using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sqlParse;

namespace sqlParse
{
    public partial class Form1 : Form
    {
        private Connection connObj = new Connection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string ip_address = ip_addressInput.Text;
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (string.IsNullOrWhiteSpace(ip_address) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (connObj.Connect(ip_address, username, password, out string msg))
                outputBox.Text = msg;
            else
                MessageBox.Show(msg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void queryText_TextChanged(object sender, EventArgs e)
        {

        }

        private void RunQuerybutton_Click(object sender, EventArgs e)
        {
            string query = queryText.Text.Trim();
            if (query.StartsWith("scan", StringComparison.OrdinalIgnoreCase))
            {
                var scanner = new Scan(connObj.GetConnection());
                outputBox.Text = scanner.ScanQuery(query);
            }
            else
            {
                outputBox.Text = connObj.RunQuery(query);
                Logger.Query(query);
            }
        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
