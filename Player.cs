//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    abstract class Player
    {
        //data members..
        const int NUM_PIECES = 2;  //X or O
        protected char m_piece;
        protected char[] PIECES = { 'X', 'O' };
        static int current; //remember what we were last time.

        public Player() //constructor
        {
            m_piece = PIECES[current];
            current = (current + 1) % NUM_PIECES; //toggle current
        }

        public char PIECE  //property no parenthesis
        {
            get { return m_piece; }
        }

        abstract public int MakeMove(ref Board theBoard, int move); //abstact later
    }
}
