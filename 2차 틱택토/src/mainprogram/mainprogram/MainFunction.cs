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
            StartTheGame startTheGame = new StartTheGame();
            startTheGame.StartTheTicTacToe();
        }
    }
}
