using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class GuidancePhrase
    {
        private static GuidancePhrase guidancePhrase;

        private GuidancePhrase() { }

        public static GuidancePhrase SetGuidancePhrase()
        {
            if(guidancePhrase == null)
            {
                guidancePhrase = new GuidancePhrase();
            }
            return guidancePhrase;
        }

        public static void PrintMenu(string menu)
        {
            Console.Write(menu);
        }

        public static void PrintException(int condition, int column, int row)
        {
            if (condition == (int)EXCEPTION.NOT_MATCH_CONDITION)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("올바르지 않은 입력입니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row);
            }
            else if(condition == (int)EXCEPTION.ID_FAIL)
            {
                Console.SetCursorPosition(column + 4, row + 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("입력된 아이디와 일치하는 아이디가 없습니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.PW_FAIL)
            {
                Console.SetCursorPosition(column + 4, row + 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("틀린 비밀번호입니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.OVERLAP_DATA)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("존재하는 아이디입니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.NOT_MATCH_PASSWORD)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("일치하지 않는 비밀번호입니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.NULL_KEYWORD)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("최소 하나 이상의 키워드를 입력해 주세요");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.NULL_SEARCH_BOOK)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("검색 결과가 없습니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.LEAK_AMOUNT)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("수량이 부족합니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.ALREADY_RENT)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이미 빌린 책입니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.NULL_RENT)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("빌린 책이 없습니다");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
            else if(condition == (int)EXCEPTION.NOT_MATCH_SEARCH)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("검색 결과와 일치하는 아이디를 입력해 주세요");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
        }

        public static void PrintEsc()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ResetColor();
        }

        public static void PrintEnter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기 / 다시 선택");
            Console.ResetColor();
        }

        private static void EraseAnounce()
        {
            ConsoleKeyInfo keyInfo;

            bool isEnteredESC = false;

            while (!isEnteredESC)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Escape)
                {
                    isEnteredESC = true;
                    Console.Write("                                               ");
                }
            }
        }

        public static void ErasePrint()
        {
            Console.Write("                                           ");
        }
    }
}
