using System;

namespace PasswordGenerator
{
	class Program
	{
        static class Password
        {
            private static string letters;
            private static string numbers;
            private static string symbols;
            private static int lettersLen;
            private static int numbersLen;
            private static int symbolsLen;

            static Password()
            {
                letters = "abcdefghijklmnopqrtsuvwxyz";
                numbers = "0123456789";
                symbols = "€&@?!#%$£";

                lettersLen = letters.Length - 1;
                numbersLen = numbers.Length - 1;
                symbolsLen = symbols.Length - 1;
            }
            static public string Generate(int length)
            {
                Random rnd = new Random();
                string password = "";
                int choice;
                int isUpper;

                do
                {
                    choice = rnd.Next(4);
                    switch (choice)
                    {
                        case 0:
                        case 1:
                            isUpper = rnd.Next(2);
                            choice = rnd.Next(lettersLen);
                            if (isUpper > 0)
                                password += Char.ToUpper(letters[choice]);
                            else password += letters[choice];

                            break;

                        case 2:
                            choice = rnd.Next(numbersLen);
                            password += numbers[choice];
                            break;

                        case 3:
                            choice = rnd.Next(symbolsLen);
                            password += symbols[choice];
                            break;
                    }
                } while ((--length) > 0);
                return password;
            }
        }

        static void Main(string[] args)
        {
            int length = Int32.Parse(Console.ReadLine());
            string pswd;

            if (length >= 8 && length <= 32)
            {
                pswd = Password.Generate(length);

                Console.WriteLine($"Generated password: {pswd}");
                Console.ReadLine();
            }
            else
            {
                pswd = Password.Generate(8);
                Console.WriteLine("Invalid length. Default length: 8");
                Console.WriteLine($"GeneratedPassword: {pswd}");
                Console.ReadLine();
            }
        }
	}
}