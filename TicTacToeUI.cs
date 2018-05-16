//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class TicTacToeUI
    {
        //data members
        const int FIRST = 0;
        const int SECOND = 1;
        const int NUM_OF_PLAYERS = 2;
        int current;
        Player[] theplayers = new Player[NUM_OF_PLAYERS]; //array players.
        string[] playerTypes = new string[] { "h", "c" }; //array player types.
        Board theBoard;
        public void MainMethod()
        {
            do
            {
                DisplayWelcome();
                Play(); //call play                
            } while (PlayAgain() == true); //keep running as long as the user says yes
        }
        void Play() //controlling method.
        {            
                current = FIRST;
                //instantiate Board
                theBoard = new Board();
                //Display Actual Grid...
                DisplayGrid();
                //Get the players
                SetPlayer();
                
                do
                {
                    Console.WriteLine("");                              

                    //make move...
                    GetMove();
                    
                    if (IsPlaying() == true)
                    {
                        NextPlayer();//changes current...
                    }
                
                } 
                while (IsPlaying() == true);  //isPlaying check Board is Full or if X or O is winner            
                announceWinner(theplayers[current].PIECE);         
        }

        bool IsPlaying() //Is the game still going on.
        {
            if (theBoard.IsFull() == false &&
                theBoard.IsWinner(theplayers[FIRST].PIECE) == false &&
                theBoard.IsWinner(theplayers[SECOND].PIECE) == false)
            { return true; }
            else
            { return false; }

        }

        //switch player
        void NextPlayer()
        {
            if (current == FIRST)
                current = SECOND;
            else
                current = FIRST;
        }

        void DisplayWelcome() //display Instructions
        {
            System.Console.WriteLine("Welcome to my Tic Tac Toe Game");
            System.Console.WriteLine("Enter the number you wish put your piece on. First one to get 3 in a row wins.");
        }

        void DisplayGrid()
        {
            char[] thegrid;
            thegrid = theBoard.PlayingBoard;
            System.Console.WriteLine();
            System.Console.WriteLine("  0 | 1 | 2       " + "  {0} | {1} | {2} ", thegrid[0], thegrid[1], thegrid[2]);
            System.Console.WriteLine("  ----------        ----------");
            System.Console.WriteLine("  3 | 4 | 5       " + "  {0} | {1} | {2} ", thegrid[3], thegrid[4], thegrid[5]);
            System.Console.WriteLine("  ----------        ----------");
            System.Console.WriteLine("  6 | 7 | 8       " + "  {0} | {1} | {2} \n ", thegrid[6], thegrid[7], thegrid[8]);
        }
        void DisplayBoardGrid()
        {
            char[] thegrid;
            thegrid = theBoard.PlayingBoard;

            System.Console.WriteLine();
            System.Console.WriteLine("  {0} | {1} | {2} ", thegrid[0], thegrid[1], thegrid[2]);
            System.Console.WriteLine("  ---------- ");
            System.Console.WriteLine("  {0} | {1} | {2} ", thegrid[3], thegrid[4], thegrid[5]);
            System.Console.WriteLine("  ---------- ");
            System.Console.WriteLine("  {0} | {1} | {2}", thegrid[6], thegrid[7], thegrid[8]);
        }

        void announceWinner(char piece)
        {
            if (theBoard.IsWinner(piece) == true)
            {
                System.Console.Clear();
                theBoard.ShowWinner(piece);
                DisplayGrid();
                System.Console.WriteLine("\nPlayer " + piece + " wins"); 
            }
            else
            {
                IsTie();
            }
        }

        void IsTie()
        {                        
                System.Console.WriteLine("The game is a tie.");            
        }

        public void GetMove() 
        {            
            int move = 0;
            int legalMove;
            if (playerTypes[current] == "h") //human
            {
                do //Prompts the player for a move.
                {
                    System.Console.Write("Player " + theplayers[current].PIECE + " where would you like to move? (0-8)?  ");
                    int.TryParse(Console.ReadLine(), out move);
                    legalMove = theplayers[current].MakeMove(ref theBoard, move);
                    if (legalMove == 0)
                    {
                        System.Console.WriteLine("Invalid move - try again");
                    }
                } while (legalMove == 0);
                System.Console.Clear();
                //Display Actual Grid...
                DisplayGrid();
            }
            else
            {
                legalMove = theplayers[current].MakeMove(ref theBoard, 0);
                System.Console.WriteLine("The computer placed " + theplayers[current].PIECE + " in the " + legalMove + " location" );
                DisplayBoardGrid();

            }
        }

        private bool PlayAgain()  //Ask the user to see if they want to play again
        {
            string replay;
            //Ask the user to see if they want to play again
            System.Console.Write("Would you like to play again? (y or n) ");
            replay = System.Console.ReadLine();

            if (replay.Equals("y"))
            {
                System.Console.Clear();
                return true;           
            }
            else
            {
                return false;
            }
        }
        void SetPlayer()    //Obtain the players
        {
            string playerType;

            System.Console.WriteLine("Declare the opponents");
            for (int i = 0; i < NUM_OF_PLAYERS; i++)
            {
                System.Console.Write("Human 'h' or Computer 'c': ");
                playerType = System.Console.ReadLine();
                playerType = playerType.Substring(0, 1).ToLower();

                if (playerType == "h")
                {
                    theplayers[i] = new HumanPlayer();
                }
                else
                {
                    theplayers[i] = new ComputerPlayer();
                }
                playerTypes[i] = playerType;
            }
        }
    }

}
