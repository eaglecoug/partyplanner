using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace partyplanner
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;  //created this because DinnerParty fields (such as NumberOfPeople) are on different class.
        
        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty((int) numericUpDown1.Value, checkBox2.Checked, checkBox1.Checked);
            DisplayDinnerPartyCost ();
        }                                                   

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) 
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            dinnerParty.CalculateCostOfDecorations(checkBox1.Checked);
            DisplayDinnerPartyCost();  //Make sure to add DisplayDinnerPartyCost when checkbox or numeric is altered by user.
        }

        private void DisplayDinnerPartyCost()
            {
                decimal Cost = dinnerParty.CalculateCost (checkBox2.Checked);
                costLabel.Text = Cost.ToString("c");
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                dinnerParty.CalculateCostOfDecorations(checkBox1.Checked);
                DisplayDinnerPartyCost();
            }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
                dinnerParty.SetHealthyOption(checkBox2.Checked);
                DisplayDinnerPartyCost();
            }

           
    }
}
