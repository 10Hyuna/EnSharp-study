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
                do      // 무한반복문
                {
                    userChoice = Console.ReadLine();

                    if( handingException.DealWithException(userChoice) == true) // 입력 값이 숫자
                    {
                        select = int.Parse(userChoice);     // 정수 변환
                        if(select == 1 || select == 2)      // 주어진 메뉴의 범위에 해당한다면 반복문 탈출
                        {
                            break;
                        }
                        else     // 범위에서 벗어남
                        {
                            Console.Clear();
                            Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                            Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                            Console.Write("> 입력: ");
                            continue;
                        }
                    }
                    else        // 입력 값이 문자
                    {
                        Console.Clear();
                        Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                        Console.Write("> 입력: ");
                        continue;
                    }
                } while (true);

                if (userChoice == "2")      // 종료 선택
                {
                    Console.Clear();
                    Console.WriteLine("정말 종료하시겠습니까?");  // 종료를 의도하고 누른 건지 실수인지 구분하기 위해 다시 선택지 제공
                    Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                    Console.Write("> 입력: ");
                    do
                    {
                        userChoice = Console.ReadLine();
                        select = int.Parse(userChoice);

                        if (handingException.DealWithException(userChoice) == true) // 입력 값이 숫자
                        {
                            select = int.Parse(userChoice);     // 정수 변환
                            if (select == 1 || select == 2)      // 주어진 메뉴의 범위에 해당한다면 반복문 탈출
                            {
                                break;
                            }
                            else
                            { 
                                Console.Clear();
                                Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                                Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                                Console.Write("> 입력: ");
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("1. 메뉴로 돌아가기 2. 종료하기");
                            Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1과 2 중에서 선택하세요.");
                            Console.Write("> 입력: ");
                            continue;
                        }
                    } while (true);
                }

                if (userChoice == "1" || userChoice == "2")
                    break;
            }
            return userChoice;
        }
    }
}
