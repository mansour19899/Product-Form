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
    public partial class CompanyInfo : Form
    {
        List<Panel> panels;
        List<string> headers;
        int step = 0;
        public CompanyInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>() { panel1, panel2, panel3 };
            headers = new List<string>() { "COMPANY INFO", "PRODUCT INFO", "Product Dimention" };

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panels.ElementAt(step).Hide();
            step = step + 1;
            panels.ElementAt(step).Show();
            lblHeaders.Text = headers.ElementAt(step);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panels.ElementAt(step).Hide();
            step = step- 1;
            panels.ElementAt(step).Show();
            lblHeaders.Text = headers.ElementAt(step);
        }
    }
}
