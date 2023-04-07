using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class ReturnOrEnd
    {
        ControlBoard controlBoard = new ControlBoard();
        HandingException handingException = new HandingException();
        InformationForGame informationForGame = new InformationForGame();

        private string userChoice;
        public string ReturnOrEndFunc()
        {
            while (true)
            {
                int select; Console.WriteLine();
                Console.WriteLine("1. 메뉴로 돌아가기  2. 종료하기");
                Console.Write("> 입력: ");
                do
                {
                    userChoice = Console.ReadLine();
                    select = int.Parse(userChoice);

                    if( handingException.DealWithException(userChoice) == true)
                    {
                        break;
                    }
                    else if (select>2||select<0)
                    {
                        Console.Clear();
                        controlBoard.DisplayBoard();
                        informationForGame.PrintWinner(); 
                        Console.WriteLine();
                        Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                        Console.Write("> 입력: ");
                    }
                    else
                    {
                        Console.Clear();
                        controlBoard.DisplayBoard();
                        informationForGame.PrintWinner(); 
                        Console.WriteLine();
                        Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                        Console.Write("> 입력: ");
                    }
                } while (handingException.DealWithException(userChoice) == false);

                if (userChoice == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("정말 종료하시겠습니까?");
                    Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                    Console.Write("> 입력: ");
                    do
                    {
                        userChoice = Console.ReadLine();
                        select = int.Parse(userChoice);

                        if (handingException.DealWithException(userChoice) == true && (select >= 1&&select <= 2))
                        {
                            break;
                        }
                        else if (select > 0 || select < 3)
                        {
                            controlBoard.DisplayBoard();
                            informationForGame.PrintWinner();
                            Console.WriteLine();
                            Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                            Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                            Console.Write("> 입력: ");
                        }
                        else
                        {
                            controlBoard.DisplayBoard();
                            informationForGame.PrintWinner();
                            Console.WriteLine();
                            Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                            Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                            Console.Write("> 입력: ");
                        }
                    } while (handingException.DealWithException(userChoice) == false);
                }

                if (userChoice == "1" || userChoice == "2")
                    break;
            }
            return userChoice;
        }
    }
}
