using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab02_Bai10
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(string ma, string ten, double diem)
        {
            MaSV = ma;
            HoTen = ten;
            DiemTB = diem;
        }

        public void HienThi() => Console.WriteLine($"Mã: {MaSV,-6} | Họ tên: {HoTen,-18} | Điểm TB: {DiemTB}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<SinhVien> ds = new List<SinhVien>();
            int chon;

            do
            {
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Sửa thông tin theo mã");
                Console.WriteLine("4. Xóa theo mã");
                Console.WriteLine("5. Tìm kiếm theo mã");
                Console.WriteLine("6. Sắp xếp giảm dần theo điểm TB");
                Console.WriteLine("7. Thống kê (Cao nhất / Thấp nhất)");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                if (!int.TryParse(Console.ReadLine(), out chon)) continue;

                switch (chon)
                {
                    case 1:
                        Console.Write("Nhập mã SV: "); string ma = Console.ReadLine();
                        Console.Write("Nhập họ tên: "); string ten = Console.ReadLine();
                        Console.Write("Nhập điểm TB: "); double diem = double.Parse(Console.ReadLine());
                        ds.Add(new SinhVien(ma, ten, diem));
                        Console.WriteLine("-> Thêm thành công!");
                        break;
                    case 2:
                        Console.WriteLine("\n--- DANH SÁCH ---");
                        foreach (var sv in ds) sv.HienThi();
                        break;
                    case 3:
                        Console.Write("Nhập mã cần sửa: "); string mSua = Console.ReadLine();
                        var svSua = ds.Find(s => s.MaSV.Equals(mSua, StringComparison.OrdinalIgnoreCase));
                        if (svSua != null)
                        {
                            Console.Write("Tên mới: "); svSua.HoTen = Console.ReadLine();
                            Console.Write("Điểm mới: "); svSua.DiemTB = double.Parse(Console.ReadLine());
                            Console.WriteLine("-> Đã sửa!");
                        }
                        else Console.WriteLine("-> Không tìm thấy!");
                        break;
                    case 4:
                        Console.Write("Nhập mã cần xóa: "); string mXoa = Console.ReadLine();
                        ds.RemoveAll(s => s.MaSV.Equals(mXoa, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine("-> Đã xóa!");
                        break;
                    case 5:
                        Console.Write("Nhập mã cần tìm: "); string mTim = Console.ReadLine();
                        var svTim = ds.Find(s => s.MaSV.Equals(mTim, StringComparison.OrdinalIgnoreCase));
                        if (svTim != null) svTim.HienThi();
                        else Console.WriteLine("-> Không tìm thấy!");
                        break;
                    case 6:
                        ds = ds.OrderByDescending(s => s.DiemTB).ToList();
                        Console.WriteLine("-> Đã sắp xếp giảm dần theo điểm!");
                        foreach (var sv in ds) sv.HienThi();
                        break;
                    case 7:
                        if (ds.Count > 0)
                        {
                            var max = ds.OrderByDescending(s => s.DiemTB).First();
                            var min = ds.OrderBy(s => s.DiemTB).First();
                            Console.Write("Cao nhất: "); max.HienThi();
                            Console.Write("Thấp nhất: "); min.HienThi();
                        }
                        else Console.WriteLine("-> Danh sách trống!");
                        break;
                }
            } while (chon != 0);
        }
    }
}