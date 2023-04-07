using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ForWin
    {
        InformationForGame information = new InformationForGame();
        ControlBoard controlBoard = new ControlBoard();
        public int CheckCorner()
        {
            for(int i = 0;i < 9;i++)
            {
                if (i == 0 || i == 2 || i == 3 || i == 5 || i == 6 || i == 8)
                {
                    if (information.IsvalidPart(i))
                    {
                        controlBoard.board[i] = 'X';
                        return i;
                    }

                }
            }
            return -1;
        }

        public void CheckSide(char player)
        {
            for(int i = 0;i <  9;i++)
            {
                if((i == 1 || i == 3 || i == 5 || i == 7) && controlBoard.board[i] == player)
                {
                    controlBoard.board[4] = 'X';
                    return;
                }
            }
        }
    }
}
