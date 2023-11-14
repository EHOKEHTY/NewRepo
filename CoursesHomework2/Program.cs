using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CoursesHomework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Exercise3(8));
        }

        //*************************КОД ЗАДАНИЯ 1*******************************************
        static void Exercise1()  //Реверс строки
        {
            StringBuilder sb = new StringBuilder();
            string text = "QWEewQQQ";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            Console.WriteLine(sb.ToString());
        }

        //*************************КОД ЗАДАНИЯ 2*******************************************
        static string Exercise2(string inputText, string[] forbiddenWords) //фильтр нежелательных слов
        {
            foreach (var word in forbiddenWords)
            {
                int index = inputText.IndexOf(word, StringComparison.OrdinalIgnoreCase);
                while (index != -1)
                {
                    int nextCharIndex = index + word.Length;
                    if ((nextCharIndex == inputText.Length || !char.IsLetterOrDigit(inputText[nextCharIndex])) &&
                        (index == 0 || !char.IsLetterOrDigit(inputText[index - 1])))
                    {
                        inputText = inputText.Remove(index, word.Length);
                        inputText = inputText.Insert(index, "***");
                    }
                    index = inputText.IndexOf(word, index + word.Length, StringComparison.OrdinalIgnoreCase);
                }
            }
            return inputText.ToString();
        }

        //*************************КОД ЗАДАНИЯ 3*******************************************
        static string Exercise3(int simbolCount)  //случайный символ
        {
            Random rand = new Random();
            rand.Next(0, 256);
            char[] simbol = new char[simbolCount];
            string result = "";
            for (int i = 0; i < simbolCount; i++)
            {
                simbol[i] += (char)rand.Next(0, 256);
                result += simbol[i].ToString();
            }
            return result;
        }

        //*************************КОД ЗАДАНИЯ 4*******************************************
        static void Exercise4()  //Дырка
        {
            int[] array = { 0, 1, 2, 3, 5 };
            int expectedSum = (array.Length * (array.Length + 1)) / 2;
            if (array.Sum() == expectedSum)
            {
                Console.WriteLine($"Дырки нет, либо дырка это следующий элемент {array.Length + 1}");
            }
            else
            {
                Console.WriteLine($"В массиве отсутствует число {expectedSum - array.Sum()}");
            }
        }

        //*************************КОД ЗАДАНИЯ 5*******************************************
        static void Exercise5()
        {
            string DNA = "AAAACGCGTA";
            byte[] compressed = Compress(DNA);

            Decompress(compressed);

            static byte[] Compress(string DNA)
            {
                byte[] compressed = new byte[DNA.Length];
                for (int i = 0; i < DNA.Length; i++)
                {
                    switch (DNA[i])
                    {
                        case 'A':
                            compressed[i] = 0b00;
                            break;
                        case 'C':
                            compressed[i] = 0b01;
                            break;
                        case 'G':
                            compressed[i] = 0b10;
                            break;
                        case 'T':
                            compressed[i] = 0b11;
                            break;
                        default:
                            Console.WriteLine("error dna reading");
                            break;
                    }
                }
                return compressed;
            }

            static string Decompress(byte[] compressed)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < compressed.Length; i++)
                {
                    switch (compressed[i])
                    {
                        case 0b00:
                            sb.Append("A");
                            break;
                        case 0b01:
                            sb.Append("C");
                            break;
                        case 0b10:
                            sb.Append("G");
                            break;
                        case 0b11:
                            sb.Append("T");
                            break;
                        default:
                            Console.WriteLine("error dna reading");
                            break;
                    }
                }
                return sb.ToString();
            }
        }

        //*************************КОД ЗАДАНИЯ 6*******************************************    
        static void Exercise6(string text, byte key = 0b0110_1110)
        {
            string test = Encryption(text, key);
            Console.WriteLine(test);
            Console.WriteLine(Decryption(test, key));

            static string Encryption(string text, byte key)
            {
                StringBuilder sb = new StringBuilder();
                char[] toEncrypt = text.ToCharArray();
                int[] encrypting = new int[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    encrypting[i] = (int)toEncrypt[i] ^ key;
                    sb.Append((char)encrypting[i]);
                }
                return sb.ToString();
            }
            static string Decryption(string encryptedText, byte key)
            {
                StringBuilder sb = new StringBuilder();
                char[] toDecrypt = encryptedText.ToCharArray();
                int[] encrypting = new int[encryptedText.Length];
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    encrypting[i] = (int)toDecrypt[i] ^ key;
                    sb.Append((char)encrypting[i]);
                }
                return sb.ToString();
            }
        }
    }
}
