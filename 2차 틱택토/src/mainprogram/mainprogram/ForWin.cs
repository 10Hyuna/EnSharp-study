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
        BoardControl controlBoard = new BoardControl();
        public int CheckCorner()        // 모서리에 유효한 값이 있는지 찾는 함수
        {
            for(int i = 0;i < 9;i++)
            {
                if (i == 0 || i == 2 || i == 3 || i == 5 || i == 6 || i == 8)
                {
                    if (information.IsvalidPart(i))
                    {
                        controlBoard.InputBoard(i, 'X');
                        return i;
                    }

                }
            }
            return -1;
        }

        public void CheckSide(char player)      // 모서리와 중앙을 제외한 자리에 유효한 자리가 있는지 확인하는 함수
        {
            for(int i = 0;i <  9;i++)
            {
                if((i == 1 || i == 3 || i == 5 || i == 7) && controlBoard.CheckBoard(i) == player)
                {
                    controlBoard.InputBoard(4, 'X');
                    return;
                }
            }
        }
    }
}
