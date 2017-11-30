/*Evgeniy Petin
 * Deatholid2@hotmail.com
 * CSIT 895
 * Assignment#2
 * Currency Converter - converts dollar amount to different amounts depending on users choice  (EUR, JPY, MXN, PHP, or RUB)
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      private void Form1_Load(object sender, EventArgs e)
        {
            lblCurAbbrevs.Text = "EUR = Euro; JPY = Japanese Ten; MXN = Mexican Peso; PHP = Phillipine Peso; RUB = Russian Rouble";
            //txtValue.Focus();
            //xtValue.Focused.
          //txtValue.
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblConvertedAmount.Text = "";
            txtValue.Text = "";
            txtCurrency.Text = "";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //int amount; //For INT Version
            decimal amount;
            string Input;
            bool DollarsValid = Decimal.TryParse(txtValue.Text, out amount) && amount>0;

           // amount = Convert.ToDecimal(txtValue.Text);

            Input = txtCurrency.Text.ToUpper();

            if (DollarsValid)
            {

                if (Input == "EUR")
                {
                    lblConvertedAmount.Text = ((amount * 0.68m).ToString("0.##")) + " euro(s)";
                    //amount.ToString(
                }

                else if (Input == "JPY")
                {
                    lblConvertedAmount.Text = ((amount * 106.65m).ToString("0.##")) + " yen(s)";
                }

                else if (Input == "MXN")
                {
                    lblConvertedAmount.Text = ((amount * 10.76m).ToString("0.##")) + " peso(s)";
                }

                else if (Input == "PHP")
                {
                    lblConvertedAmount.Text = ((amount * 40.65m).ToString("0.##")) + " peso(s)";
                }

                else if (Input == "RUB")
                {
                    lblConvertedAmount.Text = ((amount * 24.59m).ToString("0.##") + " rouble(s)");
                }

                else
                {
                    MessageBox.Show("Invalid \"Convert To\" Currency" + Environment.NewLine + "Use a valid 3 letter Abbreviation", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    txtCurrency.Focus();
                    txtCurrency.SelectAll();
                }

                //}
                //else
                //{
                //    // MessageBox.Show("Invalid Convert To  Currency Use a Valid 3 letter Abbreviation");

                //    MessageBox.Show("Dollars must be a Positive Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //    txtValue.Focus();
                //    txtValue.SelectAll();
                //}

            }

            else
            {
                MessageBox.Show("Dollars must be a Positive Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValue.Focus();
                txtValue.SelectAll();
            }
            //{
            //    MessageBox.Show("Invalid Convert To Currency Use a valid 3 letter Abbreviation", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCurrency.Focus();
            //    txtCurrency.SelectAll();
            //}
           

            
        }
    }
}
