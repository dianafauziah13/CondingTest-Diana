using System;
using System.Collections.Generic;

namespace HelloDiana
{
    class Program
    {
        /*Method yang digunakan untuk mencari huruf yang sama untuk dikembalikan menjadi angka atau integer*/
        static int DictionaryOfChar(char huruf){

            Dictionary<char, int> mapping = new Dictionary<char, int>
            {
                {'A', 0}, {' ', 0}, {'v', 0}, {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0},
                {'B', 1}, {'C', 1}, {'D', 1}, {'u', 1},
                {'E', 2}, {'p', 2}, {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2},
                {'F', 3}, {'H', 3}, {'o', 3},
                {'I', 4}, {'j', 4}, {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4}, 
                {'J', 5}, {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5}, {'i', 5},
                {'O', 6}, {'f', 6}, {'g', 6}, {'h', 6},
                {'P', 7}, {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7}, {'e', 7},
                {'U', 8}, {'b', 8}, {'c', 8}, {'d', 8},
                {'V', 9}, {'W', 9}, {'X', 9}, {'Y', 9}, {'Z', 9}, {'a', 9},
            };

            return mapping.ContainsKey(huruf) ? mapping[huruf] : -1;
        }

        /*Method yang digunakan untuk mencari angka yang sama untuk dikembalikan menjadi huruf dengan index paling pertama*/
        static List<char> DictonaryOfNumber(int[] angkaArray){
            Dictionary<int, List<char>> reverseMapping = new Dictionary<int, List<char>>
            {
                { 0, new List<char> { 'A', ' '} },
                { 1, new List<char> { 'B', 'C', 'D' } },
                { 2, new List<char> { 'E' } },
                { 3, new List<char> { 'F', 'G', 'H' } },
                { 4, new List<char> { 'I'} },
                { 5, new List<char> { 'J', 'K', 'L', 'M', 'N'} },
                { 6, new List<char> { 'O' } },
                { 7, new List<char> { 'P', 'Q', 'R', 'S', 'T' } },
                { 8, new List<char> { 'U' } },
                { 9, new List<char> { 'V', 'W', 'X', 'Y', 'Z' } }
            };

            List<char> hasilHuruf = new List<char>();

            foreach (int angka in angkaArray)
            {
                // Jika angka ada dalam dictionary, ambil huruf pertama
                if (reverseMapping.ContainsKey(angka) && reverseMapping[angka].Count > 0)
                {
                    hasilHuruf.Add(reverseMapping[angka][0]); // Ambil huruf pertama dari list
                } 
                else{
                    Console.WriteLine("tidak ada");
                }
            }

            return hasilHuruf;
            
        }

        /*Funtion yang berfungsi untuk melakukan penjumlahan dan pengulangan dengan pola yang sama pada sebuah Array angka*/
        static int Calculate(int[] angka){
            int hasil = angka[0];
            bool tambah = true;

            for (int i = 1; i < angka.Length; i++){
                if (tambah)
                {
                    hasil += angka[i];
                    tambah = false;
                }
                else
                {
                    hasil -= angka[i];
                    tambah = true;
                }
            }

            return hasil;
        }

        /*Function yang berfungsi untuk mengubah sebuah bilangan menjadi array angka yang dapat dijumlahkan */
        static int[] ConvertToArray(int total){
            total = Math.Abs(total);
            List<int> angkaList = new List<int>();
            Random rand = new Random();
            int angka = 0;
            int sisa = total;

            while (sisa > 0)
            {
                if (sisa - angka >= 0)
                {
                    angkaList.Add(angka);
                    sisa -= angka;
                    
                }
                else
                {
                    angka = 0;
                    angkaList.Add(angka);
                    // angkaList.Add(sisa);
                    // sisa = 0;
                }
                angka++; // Menambahkan angka terkecil yang mungkin
            }
            return angkaList.ToArray();
        }

        /*Function yang berfungsi untuk menambahkan dengan bilangan 1 dari index ke 2 terakhir */
        static int[] AddOneAtEnd(int[] angka)
        {
            if (angka.Length < 2)
            {
                Console.WriteLine("Array harus memiliki setidaknya dua elemen.");
                return angka;
            }

            // Buat salinan array agar tidak mengubah array asli
            int[] hasil = (int[])angka.Clone();

            // Tambahkan 1 ke dua elemen terakhir
            hasil[hasil.Length - 2] += 1;
            hasil[hasil.Length - 1] += 1;

            return hasil;
        }

        /*Function yang berfungsi untuk mengubah value pada index genap */
        static int[] TransformArray(int[] inputArray)
        {
            int[] outputArray = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                // Jika indeks genap, tambahkan 1
                outputArray[i] = (i % 2 == 0) ? inputArray[i] + 1 : inputArray[i];
                
            }
            // outputArray[outputArray.Length - 1] += 1;
            return outputArray;
        }

        static void Main (String[] args)
        {
            bool next = true;
            while(next){
                Console.WriteLine("\nMasukan Kalimat:");
                String kata = Console.ReadLine();

                List<int> hasil = new List<int>();

                foreach(char huruf in kata){
                    hasil.Add(DictionaryOfChar(huruf));
                }
                Console.WriteLine("\nNOMOR 1");
                Console.WriteLine("Hasil Konversi kata menjadi angka: [" + string.Join(", ", hasil) + "] \n");

                int[] angkaArray = hasil.ToArray();
                int luaran = Calculate(angkaArray);
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("NOMOR 2");
                Console.WriteLine("Hasil Kalkulasi : " + luaran + "\n");

                int[] NumberArray = ConvertToArray(luaran);
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("NOMOR 3");
                Console.WriteLine("Konversi ke dalam array angka: [" + string.Join(", ", NumberArray) + "]");

                List<char> arrayHuruf = DictonaryOfNumber(NumberArray);
                Console.WriteLine("Convert Kembali kedalam Array Huruf: [" + string.Join(", ", arrayHuruf) + "]\n");


                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("NOMOR 4");
                luaran = Calculate(angkaArray);
                Console.WriteLine("Kalkulasi Ke dalam bilangan: " + luaran);
                Console.WriteLine("Konversi ke dalam array angka: [" + string.Join(", ", NumberArray) + "]");

                /*Melakukan operasi penambahan bilangan 1 pada 2 index terakhir dalam array*/
                int[] newArrayNumber = AddOneAtEnd(NumberArray) ;
                Console.WriteLine("Hasil Penambahan : [" + string.Join(", ", newArrayNumber) + "]");
                List<char> newArrayChar = DictonaryOfNumber(newArrayNumber);
                Console.WriteLine("Convert Kembali kedalam Array Huruf: [" + string.Join(", ", newArrayChar) + "]\n");

                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("NOMOR 5");
                int[] TrasnformArrayNumber = TransformArray(newArrayNumber);
                List<char> TrasnformArrayChar = DictonaryOfNumber(TrasnformArrayNumber);
                Console.WriteLine("Trasnform kedalam Array Huruf: [" + string.Join(", ", TrasnformArrayChar) + "]");
                Console.WriteLine("Hasil transform array number : [" + string.Join(", ", TrasnformArrayNumber) + "]\n");

                Console.Write("Apakah ingin melakukan input lagi? (ya/tidak): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "ya")
                {
                    next = false;
                }
            }
        
        
        }
    }
}