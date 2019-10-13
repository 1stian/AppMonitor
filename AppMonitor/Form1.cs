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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="name">Application Name</param>
        /// <param name="time">Interval to check</param>
        /// <param name="path">Path to program executable</param>
        public void addProgram(String name, int time, String path)
        {
            listProgram.Items.Add(new ListViewItem(new string[] { name, time.ToString(), path }));
            log(name + " has been added. Check every " + time + " mins.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add(this);
            add.Show(this);
            this.Enabled = false;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listProgram.CheckedItems)
            {
                log(i.Text + " is now removed.");
                listProgram.Items.Remove(i);
            }
        }

        public void log(String text)
        {
            textLog.AppendText(Environment.NewLine + text);
            textLog.SelectionStart = textLog.Text.Length;
            textLog.ScrollToCaret();
        }
    }
}
