using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class MergeSort
    {
        static void Main()
        {
            int n;

            do
            {
                Console.Write("Nhap so luong phan tu cua mang: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            int[] a = new int[n];
            nhapMangNgauNhien(a, n);

            Console.WriteLine("Mang chua duoc sap xep:");
            xuatMang(a, n);

            mergeSort(a, 0, n - 1); 

            Console.WriteLine("\nMang sau khi duoc sap xep:");
            xuatMang(a, n);

            Console.ReadLine();
        }

        static void nhapMangNgauNhien(int[] a, int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = rand.Next(1, 100);
            }
        }

        static void xuatMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"\t{a[i]}");
            }
            Console.WriteLine();
        }

        // Hàm trộn hai mảng con đã được sắp xếp thành một mảng con duy nhất
        static void merge(int[] a, int l, int m, int r)
        {
            // Tạo mảng tạm để lưu kết quả của quá trình trộn
            int[] b = new int[r - l + 1];
            int i = l, j = m + 1, k = 0;

            // Trộn hai mảng con
            while (i <= m && j <= r)
            {
                if (a[i] <= a[j])
                    b[k++] = a[i++];
                else
                    b[k++] = a[j++];
            }

            // Sao chép các phần tử còn lại của mảng con bên trái (nếu có)
            while (i <= m)
                b[k++] = a[i++];

            // Sao chép các phần tử còn lại của mảng con bên phải (nếu có)
            while (j <= r)
                b[k++] = a[j++];

            // Sao chép mảng tạm trở lại mảng gốc
            for (i = l, k = 0; i <= r; i++, k++)
                a[i] = b[k];
        }

        // Hàm sắp xếp trộn
        static void mergeSort(int[] a, int l, int r)
        {
            if (l >= r)
                return;

            // Tìm chỉ số giữa của mảng
            int mid = (l + r) / 2;

            // Đệ quy sắp xếp nửa trái của mảng
            mergeSort(a, l, mid);

            // Đệ quy sắp xếp nửa phải của mảng
            mergeSort(a, mid + 1, r);

            // Trộn hai nửa đã được sắp xếp
            merge(a, l, mid, r);
        }
    }
}