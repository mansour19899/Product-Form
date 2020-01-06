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
    public partial class CostCenter : Form
    {
        double MainPrice = 0;
        double LandedCost = 0;
        double WholeSalePrice = 0;
        double SalesCom5 = 0;
        double CreditInsurance10 = 0;
        double WholeSaleCash = 0;
        double wholeSaleCredit = 0;
        double WLGrossMargin = 0;
        double WLMargin = 0;
        double Retail = 0;
        double RTLGrossMargin = 0;
        double USDtoCAD = 0;
        double LandedCostRate = 15;

        public CostCenter(double price)
        {
            MainPrice = price;
            InitializeComponent();
            USDtoCAD = 1.38;
            txtCostRate.Text = "15";
            radioButton2.Checked = true;
            if (price != 0)
            {
                txtMainPrice.Text = MainPrice.ToString();
                CalculatePrice();
                UpdatePrice();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CostCenter_Load(object sender, EventArgs e)
        {

        }

        private void txtMainPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMainPrice.Text != "")
                MainPrice = Convert.ToDouble(txtMainPrice.Text);
            else
                MainPrice = 0;
            CalculatePrice();
            UpdatePrice();
        }


        public void UpdatePrice()
        {           
            txtLandedCostUSD.Text = Math.Round(LandedCost,2).ToString();
            txtWholesaleUSD.Text = Math.Round(WholeSalePrice, 2).ToString();
            txtSales5USD.Text = Math.Round(SalesCom5, 2).ToString();
            txtCreditIN10USD.Text= Math.Round(CreditInsurance10, 2).ToString();
            txtWholeCashUSD.Text = Math.Round(WholeSaleCash, 2).ToString();
            txtWholeCreditUSD.Text= Math.Round(wholeSaleCredit, 2).ToString();
            txtWLGrossUSD.Text = Math.Round(WLGrossMargin, 2).ToString();
            txtWLMarginUSD.Text= Math.Round(WLMargin, 2).ToString()+" %";
            txtReatailUSD.Text= Math.Round(Retail, 2).ToString();
            txtRTLGrossUSD.Text= Math.Round(RTLGrossMargin, 2).ToString() + " %";

            txtLandedCostCAD.Text = Math.Round(LandedCost*USDtoCAD, 2).ToString();
            txtWholesaleCAD.Text = Math.Round(WholeSalePrice * USDtoCAD, 2).ToString();
            txtSales5CAD.Text = Math.Round(SalesCom5 * USDtoCAD, 2).ToString();
            txtCreditIN10CAD.Text = Math.Round(CreditInsurance10 * USDtoCAD, 2).ToString();
            txtWholeCashCAD.Text = Math.Round(WholeSaleCash * USDtoCAD, 2).ToString();
            txtWholeCreditCAD.Text = Math.Round(wholeSaleCredit * USDtoCAD, 2).ToString();
            txtWLGrossCAD.Text = Math.Round(WLGrossMargin * USDtoCAD, 2).ToString();
            txtWLMarginCAD.Text = Math.Round(WLMargin, 2).ToString() + " %";
            txtReatailCAD.Text = Math.Round(Retail * USDtoCAD, 2).ToString();
            txtRTLGrossCAD.Text = Math.Round(RTLGrossMargin , 2).ToString() + " %";

        }
        public void CalculatePrice()
        {
             
             LandedCost = MainPrice* (1+(LandedCostRate/100));
            WholeSalePrice =LandedCost*1.55;
             SalesCom5 = WholeSalePrice*0.05;
             CreditInsurance10 = WholeSalePrice*0.1+SalesCom5;
             WholeSaleCash = SalesCom5*0.05+WholeSalePrice;
            wholeSaleCredit = WholeSaleCash * 1.1; 
             WLGrossMargin = WholeSaleCash-LandedCost;
             WLMargin = WLGrossMargin/WholeSaleCash*100;
             Retail = LandedCost*4;
             RTLGrossMargin = (Retail-LandedCost)/Retail*100;
        }

        private void txtCostRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCostRate_KeyUp(object sender, KeyEventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            if (txtCostRate.Text != "")
                LandedCostRate = Convert.ToDouble(txtCostRate.Text);
            else
                LandedCostRate = 0;            
            CalculatePrice();
            UpdatePrice();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            LandedCostRate = 18;
            txtCostRate.Text = "18";
            CalculatePrice();
            UpdatePrice();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            LandedCostRate = 15;
            txtCostRate.Text = "15";
            CalculatePrice();
            UpdatePrice();
        }
    }
}
