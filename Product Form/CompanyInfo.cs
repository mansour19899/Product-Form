using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
        VanmeEntities db;
        List<Country> ListCountries;
        List<Category> ListCategories;
        List<SubCategory> ListSubCategories;
        List<ProductType> ListProductTypes;
        List<CategoriesSubCategory> ListCategoriesSubCategories;
        
        public CompanyInfo()
        {
            db = new VanmeEntities();
            ListCountries = db.Countries.ToList();
            ListCategories = db.Categories.ToList();
            ListSubCategories = db.SubCategories.ToList();
            ListProductTypes = db.ProductTypes.ToList();
            ListCategoriesSubCategories = db.CategoriesSubCategories.ToList();


            InitializeComponent();
            drop = new DropDown();
            UploadedPicturs = new List<string>();
            cvrt = new ConvertMetricInch();
            radioButtonIperial.Checked = true;
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

            cmbCountryofOrgin.DataSource = drop.countries();
            cmbCountryofOrgin.DisplayMember = "Name";
            cmbCountryofOrgin.ValueMember = "id";

            cmbMaterial.DataSource = drop.listMaterial();
            cmbMaterial.DisplayMember = "MaterialName";
            cmbMaterial.ValueMember = "id";

            cmbCategory.DataSource = drop.categories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            

            cmbSubCategory.DataSource = drop.subCategories();
            cmbSubCategory.DisplayMember = "Name";
            cmbSubCategory.ValueMember = "Id";
            cmbSubCategory.Enabled = false;

            cmbProductType.DataSource = drop.productTypes();
            cmbProductType.DisplayMember = "Name";
            cmbProductType.ValueMember = "Id";
            cmbProductType.Enabled = false;


            cmbBrand.DataSource = drop.brands();
            cmbBrand.DisplayMember = "Name";
            cmbBrand.ValueMember = "Id";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtCompany.Text))
            {
                panels.ElementAt(step).Hide();
                step = step + 1;
                if (step == 3)
                {
                    InsertOwnProduct();
                    this.Close();
                }
                else
                {
                    panels.ElementAt(step).Show();
                    lblHeaders.Text = headers.ElementAt(step);
                }
            }
            else
            {
                MessageBox.Show("Enter Company Name");
                txtCompany.Text = "";
            }


            
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void InsertOwnProduct()
        {
            string mac = GetMACAddress().ToString();

            var startId =Convert.ToInt16( db.Users.FirstOrDefault(p => p.MacAdress == mac).StartNumber);
            int EndId = startId + 10000;


            var CreatCompanyId = db.Companies.ToList().LastOrDefault(p=>p.Id>startId&&p.Id<EndId);
            int newCompanyId = startId + 1;
            if(CreatCompanyId!=null)
            {
                newCompanyId = CreatCompanyId.Id + 1;
            }

            var CreatProductId = db.OwnProducts.ToList().LastOrDefault(p => p.Id > startId && p.Id < EndId);
            int newProductId = startId+1;
            if (CreatProductId!=null)
            {
                 newProductId = CreatProductId.Id + 1;
            }

            try
            {

                Company company = new Company();
                company.Id = newCompanyId;
                company.CompanyName = txtCompany.Text;
                company.Manufacture = txtManufacture.Text;
                company.Website = txtWebSite.Text;
                company.Email = txtEmail.Text;
                company.StreetAddress = txtStreetAddress.Text;
                company.AddressLine2 = txtAdressline2.Text;
                company.City = txtCity.Text;
                company.StateProvinceRegion = txtStateProvince.Text;
                company.ZipPostlCode = txtZipPostalcode.Text;
                company.Country_Id_fk = Convert.ToInt16(cmbCountry.SelectedValue.ToString());
                company.Phone = txtPhone.Text;
                company.FAX = txtFax.Text;
                bool CansaveCompany = db.Companies.Any(p => p.CompanyName == company.CompanyName);
                db.Companies.Add(company);
                if (db.SaveChanges() > 0 & CansaveCompany == false)
                    MessageBox.Show("Sucsess Save   " + company.CompanyName);
                else
                    MessageBox.Show("Error Db Save Company");


                //OwnProduct product = new OwnProduct();
                //product.Id = newProductId;
                //product.ProductType_Id_fk = Convert.ToInt16(cmbProductType.SelectedValue.ToString());
                //product.ProductTittle = txtProductTittle.Text;
                //product.Color_Id_fk = Convert.ToInt16(cmbcolors.SelectedValue.ToString());
                //product.Material_Id_fk = Convert.ToInt16(cmbMaterial.SelectedValue.ToString());
                //product.Brand_Id_fk = Convert.ToInt16(cmbBrand.SelectedValue.ToString());
                //product.CountryofOrgin_Id_fk = Convert.ToInt16(cmbCountry.SelectedValue.ToString());
                //product.Box = chkBox.Checked;
                //product.Bag = chkBag.Checked;
                //product.Wrap = ChkWrap.Checked;
                //product.NoPackaging = ChkNoPackaging.Checked;
                //product.AirTransportation = ChkAirTransportation.Checked;
                //product.ShipTransportation = chkShipTransportation.Checked;
                //product.Train = chkTrain.Checked;
                //product.Truck = chkTruck.Checked;
                //product.Width = float.Parse(txtWidth.Text);
                //product.Depth = float.Parse(txtDepth.Text);
                //product.Height = float.Parse(txtHeight.Text);
                //product.Weight = float.Parse(txtWeight.Text);
                //product.SpecialPackingInstructions = txtSpecialPackaing.Text;
                //product.Price = float.Parse(txtPrice.Text);
                //product.RFIDProtected = chkRFID.Checked;
                //product.TSAApprovedLock = chkTSA.Checked;
                //product.Expandable = chkExpandable.Checked;
                //product.WaterResistance = chkWaterResistance.Checked;
                //product.RetractableHandle = chkRestractable.Checked;
                //product.Company_Id_fk = company.Id;
                //product.DescribeMaterial = txtDescribeMaterial.Text;
                //product.CheckPointFriendly = chkCheckPoint.Checked;

                //db.OwnProducts.Add(product);
                //db.SaveChanges();
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
           


            int x = 0;

        }
        public void InsertDeveloperProduct()
        {

        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public void txtCompany_Leave(object sender, EventArgs e)
        {
            var IsExist = db.Companies.FirstOrDefault(p => p.CompanyName.CompareTo(txtCompany.Text) == 0);
            if (IsExist!=null)
            {
                DialogResult result = MessageBox.Show("This company already exists. Do you want to complate?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtCompany.Text = IsExist.CompanyName.Trim();
                    txtManufacture.Text = IsExist.Manufacture.Trim();
                    txtWebSite.Text = IsExist.Website.Trim();
                    txtEmail.Text = IsExist.Email.Trim();
                    txtStreetAddress.Text = IsExist.StreetAddress.Trim();
                    txtAdressline2.Text = IsExist.AddressLine2.Trim();
                    txtCity.Text = IsExist.City.Trim();
                    txtStateProvince.Text = IsExist.StateProvinceRegion.Trim();
                    txtZipPostalcode.Text = IsExist.ZipPostlCode.Trim();
                    txtPhone.Text = IsExist.Phone.Trim();
                    txtFax.Text = IsExist.FAX.Trim();
                    cmbCountry.SelectedIndex = IsExist.Country_Id_fk-1;

                }
                else if (result == DialogResult.No)
                {
                    txtCompany.Text = "";
                }
                else
                {
                    //...
                }
            }
             
            else
                MessageBox.Show("nooo");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != 0)
            {
                var index = Convert.ToInt16( cmbCategory.SelectedValue);
                var list = ListCategoriesSubCategories.Where(p => p.Category_Id_fk == index||p.Category_Id_fk==0).Select(p => p.SubCategory).ToList();
                cmbSubCategory.DataSource = list;
                cmbSubCategory.DisplayMember = "Name";
                cmbSubCategory.ValueMember = "Id";
                cmbProductType.Enabled = false;
                cmbSubCategory.Enabled = true;

            }

        }

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubCategory.SelectedIndex != 0)
            {
                int index = Convert.ToInt16(cmbCategory.SelectedValue);
                int index1 = Convert.ToInt16(cmbSubCategory.SelectedValue);
                var index2 = ListCategoriesSubCategories.SingleOrDefault(p => p.Category_Id_fk == index&&p.SubCategory_Id_fk==index1).Id;
                var tt = ListProductTypes.Where(p => p.Categorysubcategoreis_Id_fk == index2).Select(p => p).ToList();
                cmbProductType.DataSource = tt;
                cmbProductType.DisplayMember = "Name";
                cmbProductType.ValueMember = "Id";
                cmbProductType.Enabled = true;

            }
        }
    }
}
