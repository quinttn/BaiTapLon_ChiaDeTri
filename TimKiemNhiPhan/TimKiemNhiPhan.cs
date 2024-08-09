using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimKiemNhiPhan
{
    internal class TimKiemNhiPhan
    {
        static void Main()
        {
            int[] a;
            int n, x;

            do
            {
                Console.Write("Nhap so phan tu cua mang: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            a = new int[n]; 

            nhapMang(a, n);
            Array.Sort(a); // Sắp xếp mảng trước khi tìm
            xuatMang(a, n); 

            Console.Write("\nNhap x can tim: "); 
            x = int.Parse(Console.ReadLine());

            int kq = binarySearch(a, 0, n - 1, x); // Gọi hàm binarySearch để tìm x trong mảng a

            if (kq == -1)
                Console.WriteLine($"\nKhong tim thay {x} trong mang");
            else
                Console.WriteLine($"\nTim thay {x} tai vi tri thu {kq}");

            Console.ReadLine();
        }

        static void nhapMang(int[] a, int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = rand.Next(1, 100);
            }
        }

        static void xuatMang(int[] a, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"\t{a[i]}");
            }
            Console.WriteLine();
        }

        // Hàm tìm kiếm nhị phân
        static int binarySearch(int[] a, int left, int right, int key)
        {
            if (left > right)
                return -1; // Nếu left vượt quá right, trả về -1 (không tìm thấy)

            int mid = (left + right) / 2; // Tính chỉ số giữa

            if (a[mid] == key)
                return mid; // Nếu phần tử ở giữa bằng key, trả về chỉ số giữa

            if (key < a[mid])
                return binarySearch(a, left, mid - 1, key); // Nếu key nhỏ hơn phần tử ở giữa, tìm kiếm bên trái
            else
                return binarySearch(a, mid + 1, right, key); // Nếu key lớn hơn phần tử ở giữa, tìm kiếm bên phải
        }
    }
}