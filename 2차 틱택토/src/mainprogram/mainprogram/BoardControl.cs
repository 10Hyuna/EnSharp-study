using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class BoardControl
    { 
        private static char[] board = new char[9];      // 클래스 내의 함수가 호출될 때마다 초기화되는 것을
                                                        // 막기 위하여 static 변수로 정의

        public void InputBoard(int index, char mark)    // 인자로 받은 index와 mark를 이용해 배열 board에 입력
        {
            board[index] = mark;
        }

        public char CheckBoard(int index)               // 인자로 받은 index 값의 위치에 존재하는 값을 반환
        {
            return board[index];
        }
        public void SetBoard()                          // 게임을 다시 시작할 때 배열을 초기화하기 위한 함수
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = (char)(i + '1');
            }
        }
        public void DisplayBoard()                      // 보드 출력
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[6], board[7], board[8]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
        }
    }
}