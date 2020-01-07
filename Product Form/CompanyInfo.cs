using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Form
{
    public partial class CompanyInfo : Form
    {
        List<Panel> panels;
        List<PictureBox> pictures;
        List<string> headers;
        List<string> UploadedPicturs;
        int step = 0;
        DropDown drop;
        ConvertMetricInch cvrt;
        public CompanyInfo()
        {
            InitializeComponent();
            drop = new DropDown();
            UploadedPicturs = new List<string>();
            cvrt = new ConvertMetricInch();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            panels = new List<Panel>() { panel1, panel2, panel3 };
            pictures = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };
            headers = new List<string>() { "COMPANY INFO", "PRODUCT INFO", "Product Dimention" };
            cmbcolors.DataSource = drop.listColors();
            cmbcolors.DisplayMember = "Name";
            cmbcolors.ValueMember = "Id";

            cmbCountry.DataSource = drop.countries();
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "id";

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
            if (step == -1)
            {
                this.Close();
            }
            else
            {
                panels.ElementAt(step).Show();
                lblHeaders.Text = headers.ElementAt(step);
            }

        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pic_showUpload.Image = new Bitmap(open.FileName);
                // image file path  
                //MessageBox.Show(open.FileName);
                ManageFileFolder ff = new ManageFileFolder();
                string pic=ff.copy(open.FileName);
                UploadedPicturs.Add(pic);
                uploadpic();
                int x = 0;
            }
        }

        public void uploadpic()
        {

            for (int i = 0; i < UploadedPicturs.Count; i++)
            {
                pictures.ElementAt(i).ImageLocation = UploadedPicturs.ElementAt(i);
            }

            
        }
        public void ShowPicture(int i)
        {
            if(i<UploadedPicturs.Count)
            pic_showUpload.ImageLocation = UploadedPicturs.ElementAt(i);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowPicture(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowPicture(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowPicture(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShowPicture(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ShowPicture(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ShowPicture(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ShowPicture(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ShowPicture(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ShowPicture(8);
        }

        private void btnCheckPrice_Click(object sender, EventArgs e)
        {
            double xx = 0;
            if (txtPrice.Text != "")
                 xx = Convert.ToDouble(txtPrice.Text);   

            CostCenter frm = new CostCenter(xx);
            frm.ShowDialog();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void radioButtonMetric_Click(object sender, EventArgs e)
        {
            CalculateMetric();
        }

        private void radioButtonIperial_Click(object sender, EventArgs e)
        {
            CalculateImperial();
        }
        public void CalculateMetric()
        {
            txtWidth.Text = cvrt.WidthM.ToString();
            txtDepth.Text = cvrt.DepthM.ToString();
            txtHeight.Text = cvrt.HeightM.ToString();
            txtWeight.Text = cvrt.WeightM.ToString();
        }
        public void CalculateImperial()
        {
            txtWidth.Text = cvrt.WidthI.ToString();
            txtDepth.Text = cvrt.DepthI.ToString();
            txtHeight.Text = cvrt.HeightI.ToString();
            txtWeight.Text = cvrt.WeightI.ToString();
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtWidth.Text != "")
            {
                if (radioButtonMetric.Checked == true)
                    cvrt.WidthM = Convert.ToDouble(txtWidth.Text);
                else
                    cvrt.WidthI = Convert.ToDouble(txtWidth.Text);
            }

        }

        private void txtDepth_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtDepth.Text!="")
            { 
                if (radioButtonMetric.Checked == true)
                    cvrt.DepthM = Convert.ToDouble(txtDepth.Text);
                else
                    cvrt.DepthI = Convert.ToDouble(txtDepth.Text);
            }
        }

        private void txtHeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtHeight.Text != "")
            {
                if (radioButtonMetric.Checked == true)
                    cvrt.HeightM = Convert.ToDouble(txtHeight.Text);
                else
                    cvrt.HeightI = Convert.ToDouble(txtHeight.Text);
            }
        }

        private void txtWeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtWeight.Text != "")
            {
                if (radioButtonMetric.Checked == true)
                    cvrt.WeightM = Convert.ToDouble(txtWeight.Text);
                else
                    cvrt.WeightI = Convert.ToDouble(txtWeight.Text);
            }
        }
    }
}
