//GradeArrayToCode
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradeArrayToCode
{
    public partial class Form1 : Form
    {

        const int MAX = 5;
        int[]ScoreArray = new int[MAX]; //Array in C# must be created Dynamically
        int idxScore = -1;

        public Form1()
        {
            InitializeComponent();
        }

        //int[] ScoreArray = new int[MAX];
        

        private void btnProcessScore_Click(object sender, EventArgs e)
        {
            int score;
            bool isValidScore;
            txtScore.Focus();
            txtScore.SelectAll();
            idxScore++;

            if (idxScore < MAX)
            {
                isValidScore = SetScore (out score);
                if (isValidScore)
                {
                    StoreScore (score, idxScore);
                    DisplayScore(ScoreArray[idxScore]);
                }
                else
                {
                    idxScore--;
                }
            }
            else
            {
                MessageBox.Show ("Max number of scores reached: "+ MAX, "Cannot Accept Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            idxScore--;
            }
        }

        private bool SetScore(out int sc)
        {
            sc = 0;
            bool isValid = true;

            try
            {
                sc = int.Parse(txtScore.Text);

                //if (sc < 0)
                //    throw new Exception("Input cannot be negative");
                //else if (sc > 100)
                //    throw new Exception("Input Cannot be more than 100");
            }
            //catch (FormatException)
            //{
            //    isValid = false;
            //    MessageBox.Show("Input must be an integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            catch (Exception ex)
            {
                isValid = false;
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void StoreScore(int s, int i)
        {
            ScoreArray[i] = s;
        }

        private void DisplayScore(int score)
        {
            lstScores.Items.Add(score);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Array.Clear(ScoreArray, 0, ScoreArray.Length);
            idxScore = -1;
            lstScores.Items.Clear();
            txtScore.Clear();

            txtScore.Focus();
            //txtScore
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //Sort in descending order (largest to smallest)

           // Array.Sort(ScoreArray); //Sorts in ascending order
            Array.Sort(ScoreArray, 0, idxScore+1);
           // Array.Reverse(ScoreArray); //Reverses array
          lstScores.Items.Clear();

            for (int i = 0; i <= idxScore; i++)
            {
                lstScores.Items.Add(ScoreArray[i]);
            }
        }
    }
}
