using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_2.Inputs;

namespace Assignment_2
{
    class HocVienList
    {
        //Khai báo 2 danh sách chứa các mã số và các học viên 
        List<string> danhSachMS = new List<string>();
        List<HocVien> danhSachHV = new List<HocVien>();

        public void Add(string maSo, HocVien hv) //Thêm học viên
        {
            danhSachMS.Add(maSo);
            danhSachHV.Add(hv);
        }
        public string TaoMaSo() //Tạo mã số
        {
            string maSo;
            int i = 1;
            while (true)
            {
                maSo = "HV" + i.ToString("D3");

                if (!danhSachMS.Contains(maSo)) return maSo; //Kiểm tra mã số có tồn tại chưa

                i++;
            }
        }
        public void SortByMaSo() //Sắp xếp theo mã số
        {
            int count = danhSachMS.Count;
            if (count <= 1) return;

            for(int i = 0; i < count - 1; i++)
            {
                for(int j = i + 1; j < count; j++)
                {
                    if (string.Compare(danhSachMS[i], danhSachMS[j]) > 0)
                    {
                        (danhSachMS[i], danhSachMS[j]) = (danhSachMS[j], danhSachMS[i]);
                        (danhSachHV[i], danhSachHV[j]) = (danhSachHV[j], danhSachHV[i]);
                    }
                }
            }
        }
        public void SortByDiem() //Sắp xếp theo điểm (nhỏ -> lớn)
        {
            int count = danhSachMS.Count;
            if (count <= 1) return;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (danhSachHV[i].GetDiem() > danhSachHV[j].GetDiem())
                    {
                        (danhSachMS[i], danhSachMS[j]) = (danhSachMS[j], danhSachMS[i]);
                        (danhSachHV[i], danhSachHV[j]) = (danhSachHV[j], danhSachHV[i]);
                    }

                }
            }
        }
        public void SortByDiem_Reverse() //Sắp xếp theo điểm (lớn -> nhỏ)
        {
            int count = danhSachMS.Count;
            if (count <= 1) return;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (danhSachHV[i].GetDiem() < danhSachHV[j].GetDiem())
                    {
                        (danhSachMS[i], danhSachMS[j]) = (danhSachMS[j], danhSachMS[i]);
                        (danhSachHV[i], danhSachHV[j]) = (danhSachHV[j], danhSachHV[i]);
                    }

                }
            }
        }
        public bool CheckCount() //Kiểm tra số lượng học viên
        {
            int count = danhSachMS.Count;
            if (count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return false;
            }
            return true;
        }
        public void DisplayAt(int index) //Xuất thông tin học viên
        {
            Console.WriteLine("");
            Console.WriteLine($"| Mã số: {danhSachMS[index]} |------------------------------------");
            danhSachHV[index].XuatInfo();
            Console.WriteLine("----------------------------------------------------");
        }
        public void DisplayAll() //Xuất danh sách học viên
        {
            int count = danhSachMS.Count;
            for(int i = 0; i < count; i++)
            {
                DisplayAt(i);
            }
            Console.WriteLine($"Danh sách có {count} học viên!");
        }
        public void SearchByGrade(double gradeStart, double gradeEnd) //Tìm học viên bằng điểm
        {

            int count = danhSachMS.Count();
            int found = 0;
            for(int i = 0; i < count; i++)
            {
                if (danhSachHV[i].GetDiem() >= gradeStart && danhSachHV[i].GetDiem() <= gradeEnd)
                {
                    DisplayAt(i);
                    found++;
                }
            }
            if(found == 0)
            {
                Console.WriteLine("Không tìm thấy học viên nào!");
            }
            else
            {
                Console.WriteLine($"Đã tìm thấy {found} học viên!");
            }
        }
        public void SearchByHocLuc(string hocLuc) //Tìm học viên bằng học lực
        {
            int count = danhSachMS.Count;
            int found = 0;
            for (int i = 0; i < count; i++)
            {
                if (danhSachHV[i].GetHocLuc() == hocLuc)
                {
                    DisplayAt(i);
                    found++;
                }
            }

            if (found == 0)
            {
                Console.WriteLine("Không tìm thấy học viên nào!");
            }
            else
            {
                Console.WriteLine($"Đã tìm thấy {found} học viên!");
            }
        }
        public bool UpdateByMaSo(string maSo) //Tìm và cập nhật thông tin học viên bằng mã số
        {
            int index = danhSachMS.BinarySearch(maSo);
            if(index < 0)
            {
                Console.WriteLine("Mã số không tồn tại!");
                return false;
            }
            DisplayAt(index);

            Console.WriteLine("");
            Console.WriteLine("0. Hủy thao tác");
            Console.WriteLine("1. Xóa học viên");
            Console.WriteLine("2. Cập nhật thông tin học viên");
            int selectNum;
            do
            {
                selectNum = InputInt("Chọn thao tác: ");
                if (selectNum < 0 || selectNum > 3)
                {
                    Console.WriteLine("Vui lòng chọn thao tác từ 0 -> 3!");
                }
            } while (selectNum < 0 || selectNum > 3);

            Console.WriteLine("");
            switch (selectNum)
            {
                case 0:
                    Console.WriteLine("Đã hủy thao tác!");
                    break;
                case 1:
                    Console.WriteLine($"Đã xóa học viên {danhSachMS[index]}!");
                    danhSachMS.Remove(danhSachMS[index]);
                    danhSachHV.Remove(danhSachHV[index]);
                    break;
                case 2:
                    string hoTenMoi = InputName("- Nhập họ tên mới: ");
                    double diemMoi = InputGrade("- Nhập điểm mới: ");
                    string emailMoi = InputEmail("- Nhập email mới: ");
                    danhSachHV[index] = new HocVien(hoTenMoi, diemMoi, emailMoi);
                    Console.WriteLine($"Đã cập nhật thông tin học viên {danhSachMS[index]}!");
                    break;
            }
            return true;
        }
        public void TakeGradeHighest(int soHocVien) //Lấy danh sách học viên có điểm cao
        {
            SortByDiem_Reverse();
            if (soHocVien > danhSachMS.Count) soHocVien = danhSachMS.Count;
            for(int i = 0; i < soHocVien; i++)
            {
                DisplayAt(i);
            }
        }
        public double GetDiemTB() //Lấy điểm trung bình
        {
            double sum = 0;
            double count = 0;
            foreach(HocVien hv in danhSachHV)
            {
                sum += hv.GetDiem();
                count++;
            }
            if (count == 0) return 0;
            else return count;
        }
        public void TakeHigher() //Lấy danh sách học viên có điểm hơn trung bình
        {
            int soHocVien = danhSachHV.Count;
            double diemTB = GetDiemTB();
            for (int i = 0; i < soHocVien; i++)
            {
                if (danhSachHV[i].GetDiem() >= diemTB)
                {
                    DisplayAt(i);
                }
            }
        }
        public void TongHopHocLuc() //Tổng hợp học lực
        {
            int xuatSac_Count = 0;
            int gioi_Count = 0;
            int kha_Count = 0;
            int trungBinh_Count = 0;
            int yeu_Count = 0;
            int kem_Count = 0;
            string hocLuc_Temp = "";
            foreach (HocVien hv in danhSachHV)
            {
                hocLuc_Temp = hv.GetHocLuc();
                if (hocLuc_Temp == "Xuất sắc") xuatSac_Count++;
                if (hocLuc_Temp == "Giỏi") gioi_Count++;
                if (hocLuc_Temp == "Khá") kha_Count++;
                if (hocLuc_Temp == "Trung bình") trungBinh_Count++;
                if (hocLuc_Temp == "Yếu") yeu_Count++;
                if (hocLuc_Temp == "Kém") kem_Count++;
            }
            if (hocLuc_Temp == "")
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }
            Console.WriteLine($"- Xuất sắc:   {xuatSac_Count} học viên");
            Console.WriteLine($"- Giỏi:       {gioi_Count} học viên");
            Console.WriteLine($"- Khá:        {kha_Count} học viên");
            Console.WriteLine($"- Trung bình: {trungBinh_Count} học viên");
            Console.WriteLine($"- Yếu:        {yeu_Count} học viên");
            Console.WriteLine($"- Kém:        {kem_Count} học viên");
        }
    }
}
