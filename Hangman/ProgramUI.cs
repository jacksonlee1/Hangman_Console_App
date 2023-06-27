using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman
{
    public class ProgramUI
    {
        private string[] HangmanPics = new String[]{
"  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",

        "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
};
        string Word;
        char[] CorrectGuesses;
        List<char> IncorrectGuesses;
        public ProgramUI()
        {
            Word = "Chicken";
            CorrectGuesses = Populate(new char[Word.Length], '_');
            IncorrectGuesses = new List<char>();
        }
        public void Run()
        {
            int gameState = 0;


            while (gameState != HangmanPics.Length - 1)
            {
                Console.Clear();
                Console.WriteLine("\n" + HangmanPics[gameState]);
                Console.WriteLine("Incorrect Letters Guessed: " + string.Join(", ", IncorrectGuesses));
                Console.WriteLine("Correct Letters Guessed: " + string.Join("", CorrectGuesses));
                var key = Console.ReadKey().KeyChar;
                if (!CheckAnswer(key))
                {
                    gameState++;
                    IncorrectGuesses.Add(key);
                }
            }
            Console.WriteLine(HangmanPics[6]);
            Console.WriteLine("Game Over");
        }
        public bool CheckAnswer(char guess)
        {
            bool found = false;
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == guess)
                {
                    CorrectGuesses[i] = guess;
                    found = true;
                }
            }
            return found;
        }
        public char[] Populate(char[] arr, char value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
            return arr;
        }
    }
}
