using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partyplanner
{
    class DinnerParty 
    {
        public DinnerParty (int numberOfPeople, bool healthyOption, bool fancyDecorations) 
        {
            NumberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            SetHealthyOption(healthyOption);
            CalculateCostOfDecorations (fancyDecorations);
        }
        
        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations;
        const int CostOfFoodPerPerson = 25;
        private int numberOfPeople;
        private bool fancyDecorations;
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
            }
        }
                              
        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption)
            {
                CostOfBeveragesPerPerson = 5.00M;
            }
            else
            {
                CostOfBeveragesPerPerson = 20.00M;
            }
        }

        public void CalculateCostOfDecorations(bool fancyOption)
        {              //figure cost of decorations for the # of people attending.  
            if (fancyOption)
            {
                CostOfDecorations = (numberOfPeople * 15.00M) + 50M;
            }
            else
            {
                CostOfDecorations = (numberOfPeople * 7.50M) + 30M;
            }
        }
        
        public decimal CalculateCost(bool healthyOption) {  //will take cost of total drinks and add to decorations.  Make sure to consider healthy 
                                                            //discount here not and not in the SetHealthyOption method.
            decimal totalCost = CostOfDecorations + ((CostOfBeveragesPerPerson + CostOfFoodPerPerson)*(numberOfPeople));
            if (healthyOption) {
                return totalCost * .95M;
            } else {
                return totalCost; }
        }


    }
}
