using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.VO;

namespace Library.View
{
    public class PrintLogInformation
    {
        public void ModifyUI()
        {
            Console.SetCursorPosition(0, 0);
            MainView.SetMainView().PrintBox(3);
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("삭제할 로그 아이디: ");
        }

        public void ModifySuccess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("삭제되었습니다!");
            Console.ResetColor();
        }
        public void SaveCheckUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(22, 10);
            Console.WriteLine("로그 파일을 저장하시겠습니까?");
            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER: 저장하기    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void SaveSuccessUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(21, 10);
            Console.WriteLine("로그 파일을 저장 완료했습니다!");
            Console.SetCursorPosition(29, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void DeleteCheckUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(22, 10);
            Console.WriteLine("로그 파일을 삭제하시겠습니까");
            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER: 삭제하기    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void DeleteSuccessUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(21, 10);
            Console.WriteLine("로그 파일을 삭제 완료했습니다!");
            Console.SetCursorPosition(29, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void CheckResetUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("로그 기록을 초기화하시겠습니까");
            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER: 삭제하기    ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void ResetSuccessUI()
        {
            Console.Clear();
            MainView.SetMainView().PrintMain();
            MainView.SetMainView().PrintBox(5);
            Console.SetCursorPosition(21, 10);
            Console.WriteLine("로그 기록 초기화를 완료했습니다!");
            Console.SetCursorPosition(29, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.ResetColor();
        }

        public void PrintLog(List<LogVO> log)
        {
            for(int i = 0; i < log.Count; i++)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("로그 번호 : {0}", log[i].Id);
                Console.WriteLine("로그 시간 : {0}", log[i].Time);
                Console.WriteLine("사용자    : {0}", log[i].User);
                Console.WriteLine("로그 정보 : {0}", log[i].Information);
                Console.WriteLine("로그 행위 : {0}", log[i].Action);
            }
        }
    }
}
