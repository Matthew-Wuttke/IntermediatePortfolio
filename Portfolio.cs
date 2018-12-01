//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{
    class Portfolio
    {
        //mainmethod..
        public void MainMethod()
        {
            int choice;
            do
            {
                System.Console.Clear();
                DisplayMyInfo();
                DisplayMenu();
                choice = Getchoice();
                ProcessMenu(choice);
            } while (choice != 5);
        }
       
        void ProcessMenu(int choice)
        {
            switch (choice)
            {
                case 1: //Jumble
                    JumbleUI jumbleGame = new JumbleUI();
                    jumbleGame.MainMethod();
                    break;
                case 2: //Homer
                    HomerUI homerGame = new HomerUI();
                    homerGame.MainMethod();
                    break;
                case 3: //TicTacToe
                    TicTacToeUI ticTacGame = new TicTacToeUI();
                    ticTacGame.MainMethod();
                    break;
                case 4: //Trivia
                    TriviaUI triviaGame = new TriviaUI();
                    triviaGame.MainMethod();
                    break;
                case 5:  //exit
                    break;
                default:
                    System.Console.WriteLine("Enter 1 - 5");
                    break;
            }
        }
       
        void DisplayMenu()
        {
            System.Console.WriteLine("1: Jumble Game");
            System.Console.WriteLine("2: Homer Game");
            System.Console.WriteLine("3: TicTacToe Game");
            System.Console.WriteLine("4: Trivia Game");
            System.Console.WriteLine("5: Exit\n");
        }
        void DisplayMyInfo()
        {
            Info myInfo = new Info("Portfolio");
            myInfo.DisplayInfo();
        }

        int Getchoice()
        {
            int choice;

            int.TryParse(System.Console.ReadLine(), out choice);
            System.Console.Clear();

            return choice;
        }
    }
}
