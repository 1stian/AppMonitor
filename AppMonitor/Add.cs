using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class Add : Form
    {

        private Form1 form1;

        public Add(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void buttonAdd(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int interval = int.Parse(textBoxInterval.Text);
            string path = textBoxPath.Text;

            if (name == "" || interval == 0 || path == "")
            {
                MessageBox.Show("You must specify all values!", "Error!", MessageBoxButtons.OK);
            }
            else
            {
                form1.addProgram(name, interval, path);
                this.Close();
            }
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Enabled = true;
        }

        private void buttonClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPath(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "executables (*.exe)|*.exe";
            file.Title = "Select executable";

            if (file.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = file.FileName;
            }
            
        }
    }
}
