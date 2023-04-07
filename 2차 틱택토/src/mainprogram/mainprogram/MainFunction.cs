using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class MainFunction
    {
        static void Main(string[] args)
        {
            StartingTheGame startTheGame = new StartingTheGame();
            startTheGame.StartTheTicTacToe();       // 틱택토 게임 시작
        }
    }
}
