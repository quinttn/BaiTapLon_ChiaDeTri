using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nhan2SoNguyenLon
{
    internal class Nhan2SoNguyenLon
    {
        static void Main()
        {
            Console.Write("Nhap so nguyen lon thu nhat: ");
            BigInteger X = BigInteger.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen lon thu hai: ");
            BigInteger Y = BigInteger.Parse(Console.ReadLine());

            BigInteger result = KaratsubaMultiply(X, Y);

            Console.WriteLine($"\nKet qua nhan: {result}");

            Console.ReadLine();
        }

        // Hàm nhân hai số nguyên lớn bằng thuật toán Karatsuba
        static BigInteger KaratsubaMultiply(BigInteger X, BigInteger Y)
        {
            // Nếu một trong hai số nhỏ hơn 10, trả về kết quả phép nhân thông thường
            if (X < 10 || Y < 10)
            {
                return X * Y;
            }

            // Tìm độ dài lớn nhất của hai số
            int n = Math.Max(X.ToString().Length, Y.ToString().Length);

            // Tính nửa độ dài (cộng thêm một nếu số lẻ)
            int half = (n / 2) + (n % 2);

            // Tách số X thành hai phần: A là phần nguyên khi chia X cho 10^half, B là phần dư
            BigInteger A = X / BigInteger.Pow(10, half);
            BigInteger B = X % BigInteger.Pow(10, half);

            // Tách số Y thành hai phần: C là phần nguyên khi chia Y cho 10^half, D là phần dư
            BigInteger C = Y / BigInteger.Pow(10, half);
            BigInteger D = Y % BigInteger.Pow(10, half);

            // Gọi đệ quy KaratsubaMultiply để tính tích của A và C, lưu vào m1
            BigInteger m1 = KaratsubaMultiply(A, C);

            // Gọi đệ quy KaratsubaMultiply để tính tích của B và D, lưu vào m2
            BigInteger m2 = KaratsubaMultiply(B, D);

            // Gọi đệ quy KaratsubaMultiply để tính tích của (A + B) và (C + D), sau đó trừ m1 và m2, lưu vào m3
            BigInteger m3 = KaratsubaMultiply(A + B, C + D) - m1 - m2;

            // Kết hợp các kết quả lại để tạo ra tích cuối cùng theo công thức Karatsuba
            return m1 * BigInteger.Pow(10, 2 * half) + m3 * BigInteger.Pow(10, half) + m2;
        }
    }
}