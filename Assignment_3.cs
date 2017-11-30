/*Evgeniy Petin
 * Deatholid2@hotmail.com
 * CSIT 895
 * Assignment#3
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

      //private void Form1_Load(object sender, EventArgs e)
      //  {
      //      lblCurAbbrevs.Text = "EUR = Euro; JPY = Japanese Ten; MXN = Mexican Peso; PHP = Phillipine Peso; RUB = Russian Rouble";
      //      //txtValue.Focus();
      //      //xtValue.Focused.
      //    //txtValue.
      //  }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblConvertedAmount.Text = "";
            txtValue.Text = "";
           // txtCurrency.Text = "";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            bool isValidInput;
            decimal dollars, convertAmt;
            string strCurrency;

           isValidInput = SetInputs(out dollars, out strCurrency);

           if (isValidInput)
           {

               DoConversion(dollars, ref strCurrency, out convertAmt);

               DisplayResult(convertAmt, strCurrency);
           }

            //MessageBox.Show("The input dollar amount is " + dollars + ";\n" + "the selected RadioButton Text is: " + strCurrency);
        }

        private void DisplayResult(decimal convam, string strCurr)
        {
            lblConvertedAmount.Text = convam.ToString("0.00") + " " + strCurr + "(s)";
        }

        private void DoConversion( decimal dolls, ref string currency, out decimal convAm)
        {
            currency = currency.Substring(0, 3);
            currency = currency.ToUpper();

            decimal multiplier = 1;
            
            if (currency == "EUR")
            {
                multiplier = 0.68m;
                //lblConvertedAmount.Text = ((dolls * 0.68m).ToString("0.##")) + " euro(s)";
                //amount.ToString(
            }

            else if (currency == "JPY")
            {
                multiplier = 106.65m;
               // lblConvertedAmount.Text = ((dolls * 106.65m).ToString("0.##")) + " yen(s)";
            }

            else if (currency == "MXN")
            {
                multiplier = 10.76m;
               // lblConvertedAmount.Text = ((dolls * 10.76m).ToString("0.##")) + " peso(s)";
            }

            else if (currency == "PHP")
            {
                multiplier = 40.65m;
               // lblConvertedAmount.Text = ((dolls * 40.65m).ToString("0.##")) + " peso(s)";
            }

            else if (currency == "RUB")
            {
                multiplier = 24.59m;
               // lblConvertedAmount.Text = ((dolls * 24.59m).ToString("0.##") + " rouble(s)");
            }

            convAm = dolls * multiplier;

           // convAm = convAm.
            //else
            //{
            //    MessageBox.Show("Something");
            //   // MessageBox.Show("Invalid \"Convert To\" Currency" + Environment.NewLine + "Use a valid 3 letter Abbreviation", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //txtCurrency.Focus();
            //    //txtCurrency.SelectAll();
            //}
            
        }

        private bool SetInputs(out decimal doll, out string Currency)
        {
            bool good;

            good = Decimal.TryParse(txtValue.Text, out doll) && doll>0;
            Currency = null;
            //string CurrencyText = null;
            if (good)
            {
                foreach (RadioButton rad in this.grpbSelect.Controls)
                {
                    if (rad.Checked)
                    {
                        // CurrencyText = rad.Text;
                        Currency = rad.Text;
                    }
                    //else
                    //    Currency = rad.Text;
                }
                return true;
            }
            else
                 MessageBox.Show("Dollars to Convert must be a Positive Number", "Invalid Dollars", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtValue.Focus();
                 txtValue.SelectAll();
                return false;


        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            lblConvertedAmount.Text = "";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtValue.Focus();
            txtValue.SelectAll();
            lblConvertedAmount.Text = "";
        }

        //private void btnConvert_Click(object sender, EventArgs e)
        //{
        //    //int amount; //For INT Version
        //    decimal amount;
        //    string Input;
        //    bool DollarsValid = Decimal.TryParse(txtValue.Text, out amount) && amount>0;

        //   // amount = Convert.ToDecimal(txtValue.Text);

        //    Input = txtCurrency.Text.ToUpper();

        //    if (DollarsValid)
        //    {

        //        if (Input == "EUR")
        //        {
        //            lblConvertedAmount.Text = ((amount * 0.68m).ToString("0.##")) + " euro(s)";
        //            //amount.ToString(
        //        }

        //        else if (Input == "JPY")
        //        {
        //            lblConvertedAmount.Text = ((amount * 106.65m).ToString("0.##")) + " yen(s)";
        //        }

        //        else if (Input == "MXN")
        //        {
        //            lblConvertedAmount.Text = ((amount * 10.76m).ToString("0.##")) + " peso(s)";
        //        }

        //        else if (Input == "PHP")
        //        {
        //            lblConvertedAmount.Text = ((amount * 40.65m).ToString("0.##")) + " peso(s)";
        //        }

        //        else if (Input == "RUB")
        //        {
        //            lblConvertedAmount.Text = ((amount * 24.59m).ToString("0.##") + " rouble(s)");
        //        }

        //        else
        //        {
        //            MessageBox.Show("Invalid \"Convert To\" Currency" + Environment.NewLine + "Use a valid 3 letter Abbreviation", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        //            txtCurrency.Focus();
        //            txtCurrency.SelectAll();
        //        }

        //        //}
        //        //else
        //        //{
        //        //    // MessageBox.Show("Invalid Convert To  Currency Use a Valid 3 letter Abbreviation");

        //        //    MessageBox.Show("Dollars must be a Positive Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //        //    txtValue.Focus();
        //        //    txtValue.SelectAll();
        //        //}

        //    }

        //    else
        //    {
        //        MessageBox.Show("Dollars must be a Positive Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        txtValue.Focus();
        //        txtValue.SelectAll();
        //    }
        //    //{
        //    //    MessageBox.Show("Invalid Convert To Currency Use a valid 3 letter Abbreviation", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    txtCurrency.Focus();
        //    //    txtCurrency.SelectAll();
        //    //}
           

            
        //}
    }
}
