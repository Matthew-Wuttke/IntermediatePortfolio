//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class HumanPlayer : Player
    {
        public override int MakeMove(ref Board theBoard, int move)
        {
            int sTrue = 1;
            int sFalse = 0;
            
            //asks the board if the move is legal if so add it, if not return false
            if (theBoard.IsLegalMove(move) == false)
            { return sFalse; }
            else
            {
                theBoard.ReceiveMove(m_piece, move);
                return sTrue;
            }
        }
    }
}
