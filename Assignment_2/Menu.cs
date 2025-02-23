using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_2.Inputs;
using static Assignment_2.Program;

namespace Assignment_2
{
    class Menu
    {
        public static void ChuongTrinhQuanLiHocVien()
        {
            do
            {
                //Danh sách chức năng
                Console.WriteLine("===== Chương trình quản lí học viên =====");
                Console.WriteLine("0. Thoát!");
                Console.WriteLine("1. Nhập thông tin học viên");
                Console.WriteLine("2. Xuất danh sách học viên");
                Console.WriteLine("3. Tìm kiếm học viên theo khoảng điểm");
                Console.WriteLine("4. Tìm kiếm học viên theo học lực");
                Console.WriteLine("5. Tìm học viên theo mã số và cập nhật thông tin học viên");
                Console.WriteLine("6. Sắp xếp học viên theo điểm");
                Console.WriteLine("7. Xuất 5 học viên có điểm cao nhất");
                Console.WriteLine("8. Tính điểm trung bình");
                Console.WriteLine("9. Xuất danh sách học viên có điểm trên điểm trung bình");
                Console.WriteLine("10. Tổng hợp số học viên theo học lực");

                //Chọn chức năng
                int selectCN;
                do
                {
                    selectCN = InputInt("Chọn chức năng: ");
                    if (selectCN < 0 || selectCN > 10) Console.WriteLine("Vui lòng chọn chức năng từ 0 -> 10!");
                } while (selectCN < 0 || selectCN > 10);

                Console.WriteLine("");
                switch (selectCN)
                {
                    case 0:
                        Console.WriteLine("Tạm biệt!");
                        return;
                    case 1:
                        ChucNang1();
                        break;
                    case 2:
                        ChucNang2();
                        break;
                    case 3:
                        ChucNang3();
                        break;
                    case 4:
                        ChucNang4();
                        break;
                    case 5:
                        ChucNang5();
                        break;
                    case 6:
                        ChucNang6();
                        break;
                    case 7:
                        ChucNang7();
                        break;
                    case 8:
                        ChucNang8();
                        break;
                    case 9:
                        ChucNang9();
                        break;
                    case 10:
                        ChucNang10();
                        break;
                }

                //Quay lại Menu
                Console.WriteLine("");
                bool isContinue;
                do
                {
                    Console.WriteLine("Nhấn Esc đề quay lại Menu:");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    isContinue = keyInfo.Key != ConsoleKey.Escape;
                } while (isContinue);
                Console.WriteLine("");
            } while (true);
        }
    }
}
