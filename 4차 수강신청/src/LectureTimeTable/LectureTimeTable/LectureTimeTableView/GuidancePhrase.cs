using LectureTimeTable.LectureTimeTableUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableView
{
    public class GuidancePhrase
    {
        public void PrintESC()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 뒤로가기");
            Console.ResetColor();
        }
        public void PrintAnounce()
        {
            Console.WriteLine("\t\t   __                                                                              __  ");
            Console.WriteLine("\t\t  / /                         ◎ ↑ ↓ 로 메뉴를 선택하세요                        \\ \\  ");
            Console.WriteLine("\t\t / /                          ◎ ← → 로 옵션을 선택하세요                         \\ \\ ");
            Console.WriteLine("\t\t< <                ◎ 검색 도중 ESC를 눌러 입력을 취소할 수 있습니다                 > >");
            Console.WriteLine("\t\t \\ \\            ◎ 입력을 완료한 뒤 검색하기에서 ENTER를 눌러 주세요                / / ");
            Console.WriteLine("\t\t  \\_\\                                                                              /_/  \n\n\n\n");
        }
        public void PrintException(int condition, int column, int row)
        {
            if (condition == ConstantNumber.NOT_MATCH_CONDITION)
            {

            }
            if(condition == ConstantNumber.FAILURE_LOGIN)
            {
                Console.SetCursorPosition(88, 30);
                ErasePrint();
                Console.SetCursorPosition(81, 31);
                ErasePrint();
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("저장된 정보가 없습니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
            }
        }

        private void EraseAnounce()
        {
            ConsoleKeyInfo keyInfo;

            bool isEnteredESC = false;

            while (!isEnteredESC)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnteredESC = true;
                    Console.Write("                                           ");
                }
            }
        }

        public void ErasePrint()
        {
            Console.Write("                                           ");
        }
    }
}
