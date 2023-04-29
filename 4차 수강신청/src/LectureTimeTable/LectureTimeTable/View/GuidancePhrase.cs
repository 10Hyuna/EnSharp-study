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
            if (condition == (int)EXCEPTION.NOT_MATCH_CONDITION)
            {
                Console.SetCursorPosition(column + 13, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("올바르지 않은 입력입니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column + 13, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row);
            }
            else if(condition == (int)EXCEPTION.MAX_CREDIT)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("저장 가능 학점을 초과했습니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.FAILURE_LOGIN)
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
            else if(condition == (int)EXCEPTION.FREE_CREDIT)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("강의가 성공적으로 담겼습니다!");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.NULL_LECTURE)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("해당 강의가 존재하지 않습니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.OVERLAP_LECTURE)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이미 담긴 강의입니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.OVERLAP_TIME)
            {
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("동일한 시간대에 이미 존재하는 강의가 있습니다.");
                Console.ResetColor();
                Console.SetCursorPosition(column, row);
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.NULL_STORAGE)
            {
                Console.SetCursorPosition(0, row + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("저장된 강의 내역이 없습니다.");
                Console.ResetColor();
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.SUCCESS_DELETE)
            {
                Console.SetCursorPosition(column + 5, row);
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("삭제되었습니다!");
                Console.ResetColor();
                EraseAnounce();
                Console.SetCursorPosition(column, row - 1);
            }
            else if(condition == (int)EXCEPTION.CHECK)
            {
                Console.WriteLine("강의 시간표를 엑셀 파일로 저장하시겠습니까?");
                Console.SetCursorPosition(column + 5, row + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ENTER : 예              ESC : 아니오");
                Console.ResetColor();
            }
            else if(condition == (int)EXCEPTION.COMPLETE)
            {
                Console.WriteLine("강의 시간표를 엑셀 파일로 저장했습니다!");
                Console.SetCursorPosition(column + 10, row + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ESC : 뒤로가기");
                Console.SetCursorPosition(0, 0);
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

                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Escape)
                {
                    isEnteredESC = true;
                    Console.Write("                                               ");
                }
            }
        }

        public void ErasePrint()
        {
            Console.Write("                                           ");
        }
    }
}
