using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


/*Evgeniy Petin
 * CSIT 895 Section 3123
 * Final Test*/


namespace Final895
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private int n = 0;
        frmDialog DlgFrm = new frmDialog();
        private Button[] BtnArray;
        private int[] freqArray;// = new int[n];
        private int index = 0;

        private void btnSetBase_Click(object sender, EventArgs e)
        {
             //creates the dialog form in memory
            DialogResult dResult = DlgFrm.ShowDialog(this);

            if (dResult == DialogResult.OK)
            {
                index = DlgFrm.Base;
              //  lblOutDigits.Text = DlgFrm.Base.ToString();
                CreateBaseButtons(DlgFrm.Base);
                freqArray = new int[index];
            }
            //if (dResult == DialogResult.Cancel)
            //{

            //}

        }

        private void CreateBaseButtons(int NumOfButtons)
        {
            BtnArray = new Button[NumOfButtons];

            int x = 13;
            int y = 13;

            for (int i = 0; i < NumOfButtons; i++)
            {
                BtnArray[i] = new Button();
                BtnArray[i].Location = new System.Drawing.Point(x, y);
                BtnArray[i].Name = "btn" + i;
                BtnArray[i].Size = new System.Drawing.Size(75, 25);
                BtnArray[i].Text = i.ToString();
                BtnArray[i].UseVisualStyleBackColor = true;

                this.Controls.Add(BtnArray[i]);
                BtnArray[i].Click += new System.EventHandler(btnN_Click);

                x += BtnArray[i].Size.Width;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblOutDigits.Text = "";
            lstFrequencies.Items.Clear();
            for (int i = 0; i < index; i++)
            {
                BtnArray[i].Dispose();
            }
            index = 0;
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            string StringNumber = ((Button)sender).Text;
            int IntNumber = int.Parse(StringNumber);
            freqArray[IntNumber]++;
            lblOutDigits.Text += StringNumber;
            //lblOutDigits.Text.so
          //  freqArray[int.Parse(((Button)sender).Text)] += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =  "\t" + "Digit" + "               " + "Frequency";
        }

        private void btnShowFreq_Click(object sender, EventArgs e)
        {
          //  freqArray = new int[n];
            lstFrequencies.Items.Clear();
            for (int i = 0; i < index; i++)
            {
                lstFrequencies.Items.Add(i + "\t\t"+freqArray[i]);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            lblOutDigits.Text = "";

            for (int i = 0; i < index; i++)
            {
                int number = freqArray[i];
                for (int x = 0; x < number; x++)
                {
                    lblOutDigits.Text += i;
                }
            }
        }
    }
}
