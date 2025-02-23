using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class HocVien
    {
        //Thuộc tính
        private string HoTen { get; set; }
        private double Diem { get; set; }
        private string Email { get; set; }

        //Contructor
        public HocVien(string hoTen, double diem, string email)
        {
            HoTen = hoTen;
            Diem = diem;
            Email = email;
        }


        //Phương thức
        public string GetHoTen()
        {
            return HoTen;
        }
        public double GetDiem()
        {
            return Diem;
        }
        public string GetEmail()
        {
            return Email;
        }
        public string GetHocLuc()
        {
            if (Diem >= 9) return "Xuất sắc";
            else if (Diem >= 7.5) return "Giỏi";
            else if (Diem >= 6.5) return "Khá";
            else if (Diem >= 5) return "Trung bình";
            else if (Diem >= 3) return "Yếu";
            else return "Kém";
        }

        public void XuatInfo()
        {
            Console.WriteLine($"|- Họ tên: {HoTen}");
            Console.WriteLine($"|- Điểm: {Diem}");
            Console.WriteLine($"|- Email: {Email}");
            Console.WriteLine($"|- Học lực: {GetHocLuc()}");
        }
    }
}
