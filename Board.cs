//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class Board
    {
        //datamembers
        const int NUM_SQUARE = 9;
        const char EMPTY = ' ';
        static char[] m_Square = new char[NUM_SQUARE];

        public Board()
        {
            Reset();
        }
        public char[] PlayingBoard
        {
            get { return m_Square; }
        }
        public int NumberOfSquares
        {
            get { return NUM_SQUARE; }
        }
        public void Reset()
        {
            for (int i = 0; i < NUM_SQUARE; i++)
            {
                m_Square[i] = EMPTY;
            }
        }
        public bool IsFull()
        {
            bool full = true;
            int i = 0;

            //checks to see if every box on the board is full
            while (full == true && i < NUM_SQUARE) //stop when it finds the first one.
            {
                if (m_Square[i] == EMPTY)
                    full = false;
                i++;
            }
            return full;
        }
        public void ReceiveMove(char piece, int move)
        {
            //adds piece to the board
            m_Square[move] = piece;
        }

        public bool IsLegalMove(int move)
        {
            bool result = true;

            //is the location empty or within the array
            if ((move < 0) || (move >= NUM_SQUARE) || (m_Square[move] != EMPTY))
                result = false;

            return result;
        }

        public bool IsWinner(char piece)
        {
            //checks to see if someone won
            bool winner = false;
            
            //ACROSS/ROW
            //TOP
            if ((m_Square[0] == piece) && (m_Square[1] == piece) && (m_Square[2] == piece))
            {
                 winner = true;
            }
            
            //move if statements.
            //CENTER
            if ((m_Square[3] == piece) && (m_Square[4] == piece) && (m_Square[5] == piece))
            {
                winner = true;
            }
            //BOTTOM
            if ((m_Square[6] == piece) && (m_Square[7] == piece) && (m_Square[8] == piece))
            {
                winner = true;
            }

            //DOWN/COLUMN
            //LEFT
            if ((m_Square[0] == piece) && (m_Square[3] == piece) && (m_Square[6] == piece))
            {
                winner = true;
            }
            
            //MIDDLE
            if ((m_Square[1] == piece) && (m_Square[4] == piece) && (m_Square[7] == piece))
            {
                winner = true;
            }
            
            //RIGHT(|)
            if ((m_Square[2] == piece) && (m_Square[5] == piece) && (m_Square[8] == piece))
            {
                winner = true;
            }
            
            //DIAGONALLY
            //LEFT TO RIGHT(+)
            if ((m_Square[0] == piece) && (m_Square[4] == piece) && (m_Square[8] == piece))
            {
                winner = true;
            }
            
            //RIGHT TO LEFT(/)
            if ((m_Square[2] == piece) && (m_Square[4] == piece) && (m_Square[6] == piece))
            {
                winner = true;
            }
            return winner;
        }
        public void ShowWinner(char piece)
        {
            //shows how the player won.
            //ACROSS/ROW
            //TOP
            if ((m_Square[0] == piece) && (m_Square[1] == piece) && (m_Square[2] == piece))
            {
                m_Square[0] = '_';
                m_Square[1] = '_';
                m_Square[2] = '_';
                
            }
            //move if statements.
            //CENTER
            if ((m_Square[3] == piece) && (m_Square[4] == piece) && (m_Square[5] == piece))
            {
                m_Square[3] = '_';
                m_Square[4] = '_';
                m_Square[5] = '_';
                
            }
            //BOTTOM
            if ((m_Square[6] == piece) && (m_Square[7] == piece) && (m_Square[8] == piece))
            {
                m_Square[6] = '_';
                m_Square[7] = '_';
                m_Square[8] = '_';
                
            }

            //DOWN/COLUMN
            //LEFT
            if ((m_Square[0] == piece) && (m_Square[3] == piece) && (m_Square[6] == piece))
            {
                m_Square[0] = '|';
                m_Square[3] = '|';
                m_Square[6] = '|';
                
            }
            //MIDDLE
            if ((m_Square[1] == piece) && (m_Square[4] == piece) && (m_Square[7] == piece))
            {
                m_Square[1] = '|';
                m_Square[4] = '|';
                m_Square[7] = '|';
                
            }
            //RIGHT(|)
            if ((m_Square[2] == piece) && (m_Square[5] == piece) && (m_Square[8] == piece))
            {
                m_Square[2] = '|';
                m_Square[5] = '|';
                m_Square[8] = '|';
                
            }
            //DIAGONALLY
            //LEFT TO RIGHT(+)
            if ((m_Square[0] == piece) && (m_Square[4] == piece) && (m_Square[8] == piece))
            {
                m_Square[0] = '\\';
                m_Square[4] = '\\';
                m_Square[8] = '\\';
                
            }
            //RIGHT TO LEFT(/)
            if ((m_Square[2] == piece) && (m_Square[4] == piece) && (m_Square[6] == piece))
            {
                m_Square[2] = '/';
                m_Square[4] = '/';
                m_Square[6] = '/';                
            }
        }
    }
}
