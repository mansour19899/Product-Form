using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DropDown dr = new DropDown();
            var rr = dr.listColors();
            
        }

        private void btnProductForm_Click(object sender, EventArgs e)
        {
            CompanyInfo frm = new CompanyInfo();
            frm.ShowDialog();
        }
    }
}
