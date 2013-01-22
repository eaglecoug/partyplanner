using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartyPlanner2
{
    class BirthdayParty
    {
        public BirthdayParty(int numberOfPeople, bool fancyDecorations, string cakeWriting)
        {
            this.numberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            CalculateCakeSize();
            this.CakeWriting = cakeWriting;
            CalculateCostOfDecorations(fancyDecorations);
        }
        
        private void CalculateCakeSize () 
        {
            if (NumberOfPeople <= 4)
                CakeSize = 8;
                else
                CakeSize = 16;
        }
        private string cakeWriting = "";
        public string CakeWriting
        {
            get
            {
                return this.cakeWriting;
            }
            set
            {
                int maxLength;
                if (CakeSize == 8)
                    maxLength = 16;
                else
                    maxLength = 40;
                if (value.Length > maxLength)
                {
                    MessageBox.Show("Too many letters for a " + CakeSize + " inch cake");
                    if (maxLength > this.cakeWriting.Length)
                        maxLength = this.cakeWriting.Length;
                    this.cakeWriting = cakeWriting.Substring(0, maxLength);
                }
                else
                    this.cakeWriting = value;
            }
        }
        
        public int CakeSize;
        const int CostOfFoodPerPerson = 25;
        private bool fancyDecorations;
        public decimal CostOfDecorations = 0;
        private int numberOfPeople;
        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecorations);
                CalculateCakeSize();
                this.CakeWriting = cakeWriting;
            }
        }
        public void CalculateCostOfDecorations(bool fancy)
        {
            fancyDecorations = fancy;
            if (fancy)
            {
                CostOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                CostOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            }
        }
        public decimal CalculateCost()
        {
            decimal extrafee = 0M;
            decimal TotalCost = extrafee + CostOfDecorations + (CostOfFoodPerPerson * NumberOfPeople);
            if (NumberOfPeople > 12)
            {
                extrafee = 100M;
            }
            else
            {
                extrafee = 0M;
            }
            
            decimal CakeCost;
            if (CakeSize == 8)
                CakeCost = 40M + CakeWriting.Length * .25M;
            else
                CakeCost = 75M + CakeWriting.Length * .25M;
            return TotalCost + CakeCost;
        }

    }
}
