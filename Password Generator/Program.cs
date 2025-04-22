using System;
class Program
{
    static void Main(string[] args)
    {
        
        int choice;
        Console.WriteLine("Welcome to Password Generator.\n" +
        "Which password do you want to generate with:");

        do
        {
            Console.WriteLine("Select the number 1 if you want a password made up of only numbers\n" +
            "select the number 2 if you want a password made up of only lowercase and uppercase letters\n" +
            "select the number 3 if you want a password made up of a mixture of lowercase and uppercase letters and numbers.\n" + 
            "select the number 3 if you want the password to consist of a combination of lowercase, uppercase letters and numbers, as well as special characters.\n" +
            "All passwords are generated up to 16 numbers.");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);
            if (isValid && choice >= 1 && choice <= 4)
            { Console.WriteLine($"You have chosen an option {choice}.");
                string password = GeneratePassword(choice);
                Console.WriteLine($"Your password: {password}");
                break;
            }


            else { Console.WriteLine("Mistake! Please select a number from 1 to 3."); }

        } while (choice < 1 || choice > 4);

            Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    static string GeneratePassword(int choice)
    {
        Random random = new Random();
        string numbers = "0123456789";
        string letters = "abcdefghijklmnopqrstuvwxyz".ToUpper() + "abcdefghijklmnopqrstuvwxyz";
        string special = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        string mixed = numbers + letters;
        string mixed2 = mixed + letters + special;
        string chars = choice switch
        {
            1 => numbers,
            2 => letters,
            3 => mixed,
            _ => numbers,
        };
        char[] password = new char[16];
        for (int i = 0; i < 16; i++)
        {
            password[i] = chars[random.Next(chars.Length)];
        }
        return new string(password);
    }
}