using System;


namespace soda_machine_challenge_first_command
{
    class Program
    {
        static void Main(string[] args)
        {
            var drinkMachine = new SodaMachine();

            while (!drinkMachine.checkTotal())
            {
                drinkMachine.StateCurrentBalance();
                Console.WriteLine($"The cost of a drink is $1.75. Please enter coins(5, 10, 25) or a dollar bill (100)");
                drinkMachine.InsertCoin(Convert.ToInt32(Console.ReadLine()));
            }

            drinkMachine.ShowDrinkSelection();

            Console.ReadLine();
        }
    }

    public class SodaMachine
    {
      
        const float CostOfDrink = 175;
        public float CurrentBalance { get; set; }

        public SodaMachine()
        {
            CurrentBalance = 0;
        }

        public void InsertCoin(int coin)
        {
              // Valid coin entries are 5, 10, 25, 100 translating to nickels, dimes, quarters, and dollars
              switch (coin)
              {
                case (5):
                    CurrentBalance += 5;
                    break;
                case (10):
                    CurrentBalance += 10;
                    break;
                case (25):
                    CurrentBalance += 25;
                    break;
                case (100):
                    CurrentBalance += 100;
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
              }
        }

        public void StateCurrentBalance()
        {
            Console.WriteLine($"Your current balance is ${(CurrentBalance / 100)}");
        }
        public bool checkTotal()
        {
            if (CurrentBalance >= CostOfDrink)
                return true;
            else
                return false;
        }

        public void ShowDrinkSelection()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("Please Select A Beverage:");
            Console.WriteLine();
            Console.WriteLine("* W - Water             *");
            Console.WriteLine("* C - Coke              *");
            Console.WriteLine("* D - Diet Coke         *");
            Console.WriteLine("* G - Gatorade          *");
            Console.WriteLine("* O - Orange Fanta      *");
            Console.WriteLine("*************************");
            MakeSelection(Convert.ToChar(Console.ReadLine().ToUpper()));
        }

        private void MakeSelection(char selection)
        {
            bool selectionOK = false;
            while (!selectionOK)
            {
                switch(selection)
                {
                    case 'W':
                        Console.WriteLine("You have selected Water. Thank you for your purchase!");
                        selectionOK = true;
                        MakeChange();
                        break;
                    case 'C':
                        Console.WriteLine("You have selected Coke. Thank you for your purchase!");
                        selectionOK = true;
                        MakeChange();
                        break;
                     case 'D':
                        Console.WriteLine("You have selected Diet Coke. Thank you for your purchase!");
                        selectionOK = true;
                        MakeChange();
                        break;
                     case 'G':
                        Console.WriteLine("You have selected Gatorade. This product is currently sold out. Please make another selection.");
                        selection = Convert.ToChar(Console.ReadLine().ToUpper());
                        selectionOK = false;
                        break;
                     case 'O':
                        Console.WriteLine("You have selected Orange Fanta. Thank you for your purchase!");
                        selectionOK = true;
                        MakeChange();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection. Please try again: ");
                        selection = Convert.ToChar(Console.ReadLine().ToUpper());
                        selectionOK = false;
                        break;
                }
            }
        }

        private void MakeChange()
        {
            if (CurrentBalance > CostOfDrink)
                Console.WriteLine($"Your change is ${((CurrentBalance - CostOfDrink) / 100)}");
        }
    }
}
