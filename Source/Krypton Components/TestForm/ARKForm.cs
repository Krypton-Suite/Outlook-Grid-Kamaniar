using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class ARKForm : KryptonForm
    {
        public ARKForm()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
           KryptonMessageBox.Show("Saved!");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonMessageBox.Show("Canceled.");
        }
    }
}
