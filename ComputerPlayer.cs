//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class ComputerPlayer : Player
    {
        public override int MakeMove(ref Board theBoard, int cmove)
        {
            //Can Computer win
            bool found = false;
            int move = 0;
            int[] BEST_MOVES = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };

            while (!found && move < theBoard.NumberOfSquares)
            {
                if (theBoard.IsLegalMove(move)) //empty
                {
                    //try this...
                    theBoard.ReceiveMove(PIECE, move);   //put on board.
                    //can I win...
                    found = theBoard.IsWinner(PIECE);
                    if (found == true)// if can win
                    {
                        return move;
                    }
                    //remove board..
                    theBoard.ReceiveMove(' ', move);
                }

                
                if (found == false)
                {
                    move += 1;
                }

            }
            
            //opponent can win. Same as above but GetOpponentsPiece
            if (found == false)
            {
                move = 0;
                //Can Opponent win
                while (!found && move < theBoard.NumberOfSquares)
                {
                    if (theBoard.IsLegalMove(move)) //empty
                    {
                        //try this...
                        theBoard.ReceiveMove(GetOpponentPiece(), move);   //put on board.
                        //can I win...
                        found = theBoard.IsWinner(GetOpponentPiece());
                        if (found == true)  // if the opponent can win
                        {
                            //fill the allowable winning slot
                            theBoard.ReceiveMove(PIECE, move);
                            return move;
                        }
                        //remove board..
                        theBoard.ReceiveMove(' ', move);
                        
                    }

                    if (found == false)
                    {
                        move += 1;
                    }
                }
            }

            //Best moves
            if (found == false)
            {
                move = 0;
                int i = 0;
                while (!found && i < theBoard.NumberOfSquares)
                {
                    move = BEST_MOVES[i];

                    if (theBoard.IsLegalMove(move))
                    {
                        found = true;
                    }
                    i++;
                }
            }
         
            theBoard.ReceiveMove(PIECE, move);
            return move;
        }

        public char GetOpponentPiece() //obtains the opponent's piece
        {
            const int FIRST = 0;
            const int SECOND = 1;
            char piece;
            if (m_piece == PIECES[FIRST])
            {
                piece = PIECES[SECOND];
            }
            else
            {
                piece = PIECES[FIRST];
            }

            return piece;
        }
    }
}
