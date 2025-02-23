using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_2.Inputs;

namespace Assignment_2
{
    class Program
    {
        public static HocVienList danhSachHV = new HocVienList();
        public static void ChucNang1() //Nhập thông tin học viên
        {
            Console.WriteLine("<--Nhập thông tin học viên-->");

            //Nhập số học viên
            int soHocVien;
            do
            {
                soHocVien = InputInt("Nhập số học viên: ");
                if (soHocVien <= 0) Console.WriteLine("vui lòng nhập lại số học viên!");
            } while (soHocVien <= 0);

            //Nhập thông tin các học viên
            string hoTen;
            double diem;
            string email;
            string maSo;
            for (int i = 0; i < soHocVien; i++)
            {
                Console.WriteLine("");
                if(soHocVien > 1) Console.WriteLine($"Nhập thông tin học viên thứ {i + 1}:");

                hoTen = InputName("- Nhập họ tên: ");

                diem = InputGrade("- Nhập điểm: ");

                email = InputEmail("- Nhập email: ");

                maSo = danhSachHV.TaoMaSo();

                danhSachHV.Add(maSo, new HocVien(hoTen, diem, email));
            }
        }
        public static void ChucNang2() //Xuất danh sách học viên
        {
            Console.WriteLine("<--Xuất danh sách học viên-->");
            if(danhSachHV.CheckCount()) danhSachHV.DisplayAll();
        }
        public static void ChucNang3() //Tìm kiếm học viên theo khoảng điểm
        {
            Console.WriteLine("<--Tìm kiếm học viên theo khoảng điểm-->");
            if (danhSachHV.CheckCount())
            {
                Console.WriteLine("Nhập khoảng điểm:"); //Nhập khoảng điểm
                double gradeStart = InputGrade("- Từ: ");
                double gradeEnd = InputGrade("- Đến: ");

                danhSachHV.SearchByGrade(gradeStart, gradeEnd);
            }
        }
        public static void ChucNang4() //Tìm kiếm học viên theo học lực
        {
            Console.WriteLine("<--Tìm kiếm học viên theo học lực-->");
            if (danhSachHV.CheckCount())
            {
                string hocLuc;
                while (true)
                {
                    Console.Write("Nhập học lực: ");
                    hocLuc = Console.ReadLine()?.ToLower();

                    if (!string.IsNullOrEmpty(hocLuc))
                    {
                        if (hocLuc == "xuất sắc") hocLuc = "Xuất sắc";
                        else if (hocLuc == "giỏi") hocLuc = "Giỏi";
                        else if (hocLuc == "khá") hocLuc = "Khá";
                        else if (hocLuc == "trung bình") hocLuc = "Trung bình";
                        else if (hocLuc == "yếu") hocLuc = "Yếu";
                        else if (hocLuc == "kém") hocLuc = "Kém";
                        else
                        {
                            Console.WriteLine("Vui lòng nhập học lực hợp lệ!");
                            continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập học lực hợp lệ!");
                    }
                }
                danhSachHV.SearchByHocLuc(hocLuc);
            }
        }
        public static void ChucNang5() //Tìm học viên theo mã số và cập nhật thông tin học viên
        {
            Console.WriteLine("<--Tìm học viên theo mã số và cập nhật thông tin học viên-->");
            if (danhSachHV.CheckCount())
            {
                string maSo;
                while (true)
                {
                    Console.Write("Nhập mã số: ");
                    maSo = Console.ReadLine()?.ToUpper();

                    if (!string.IsNullOrEmpty(maSo))
                    {
                        if (danhSachHV.UpdateByMaSo(maSo)) break; //Kiểm tra mã số có tồn tại không
                        else continue;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập mã số hợp lệ!");
                    }
                }
            }
        }
        public static void ChucNang6() //Sắp xếp học viên theo điểm
        {
            Console.WriteLine("<--Sắp xếp học viên theo điểm-->");
            if (danhSachHV.CheckCount())
            {
                danhSachHV.SortByDiem();
                danhSachHV.DisplayAll();
            }
        }
        public static void ChucNang7() //Xuất 5 học viên có điểm cao nhất
        {
            Console.WriteLine("<--Xuất 5 học viên có điểm cao nhất-->");
            if (danhSachHV.CheckCount()) danhSachHV.TakeGradeHighest(5);
        }
        public static void ChucNang8() //Tính điểm trung bình
        {
            Console.WriteLine("<--Tính điểm trung bình-->");
            if (danhSachHV.CheckCount())
            {
                Console.WriteLine($"Điểm trung bình các học viên là: {danhSachHV.GetDiemTB()}");
            }
        }
        public static void ChucNang9() //Xuất danh sách học viên có điểm trên điểm trung bình
        {
            Console.WriteLine("<--Xuất danh sách học viên có điểm trên điểm trung bình-->");
            if (danhSachHV.CheckCount())
            {
                danhSachHV.TakeHigher();
            }
        }
        public static void ChucNang10() //Tổng hợp số học viên theo học lực
        {
            Console.WriteLine("<--Tổng hợp số học viên theo học lực-->");
            if (danhSachHV.CheckCount())
            {
                danhSachHV.TongHopHocLuc();
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Menu.ChuongTrinhQuanLiHocVien();
        }
    }
}
