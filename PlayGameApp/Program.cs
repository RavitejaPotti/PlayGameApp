using System;

namespace PlayGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello player!");
            Console.WriteLine("\n");
            Console.WriteLine("I have Created a random code:");
            Console.WriteLine(" -- I have secret code which has only 4 digits.Each digit falls between 1 and 6.");
            Console.WriteLine("You have 10 attempts to guess my secret code.");
            Console.WriteLine("After each guess, I will print you a 4-digit response:");
            Console.WriteLine(" -- character Plus('+') means your guess was correct in that position.");
            Console.WriteLine(" -- character Minus ('-') means that digit is in the secret code, but not present in the same position.");
            Console.WriteLine(" -- charcter Space (' ') means that digit is not in the code at all.");
            Console.WriteLine("\n");
            Console.WriteLine("Please enter your first guess number now.");
            var play = new Play();

            do
            {
                Console.Write("\n> ");
                var guessCode = Console.ReadLine();

                Console.WriteLine(play.GuessSecretCode(guessCode));

            } while (!play.IsCompleted);
        }
    }
}
