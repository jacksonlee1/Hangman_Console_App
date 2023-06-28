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

        "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========",
        "██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗ ██████╗ ███╗   ██╗██╗██╗██╗\n╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██╔═══██╗████╗  ██║██║██║██║\n ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║   ██║██╔██╗ ██║██║██║██║\n  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║   ██║██║╚██╗██║╚═╝╚═╝╚═╝\n   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝╚██████╔╝██║ ╚████║██╗██╗██╗\n   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═══╝╚═╝╚═╝╚═╝\n"
};
        string Word;
        char[] CorrectGuesses;
        List<char> IncorrectGuesses;
        string[] NormalWordBank =
        {
                "planet",
                "excite",
                "guitar",
                "jungle",
                "butter",
                "dancer",
                "basket",
                "puzzle",
                "yellow",
                "candle",
                "monster",
                "sunset",
                "piano",
                "island",
                "safari",
                "cookie",
                "tigers",
                "coffee",
                "flames",
                "summer"
            };
        string[] DifficultWordBank = {
                "Architecture",
                "Elephantine",
                "Independence",
                "Labyrinthine",
                "Philosophy",
                "Revolutionary",
                "Terminology",
                "Unbelievable",
                "Astronomical",
                "Breathtaking",
                "Extravagant",
                "Impressionist",
                "Meteorology",
                "Perseverance",
                "Spectacular"
    };
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Press D for difficult. Press any other key for normal.");
            var WordBank = (Console.ReadKey().Key == ConsoleKey.D)? DifficultWordBank:NormalWordBank;
            Random random = new Random();
            int randomIndex = random.Next(0, WordBank.Length); // Generate a random index within the array bounds
            Word = WordBank[randomIndex];
            Word = Word.ToUpper();
            CorrectGuesses = Populate(new char[Word.Length], '_');
            IncorrectGuesses = new List<char>();
            Console.Clear();
            Console.WriteLine("██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗\n██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║\n███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║\n██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║\n██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║\n╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝\n");
            Console.WriteLine("Press enter to start");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Run();
        }
        public void Run()
        {
            int gameState = 0;

            while (gameState != HangmanPics.Length - 2 && CorrectGuesses.Contains('_'))
            {
                Console.Clear();
                // Console.WriteLine(CorrectGuesses.Contains('_'));
                // Console.WriteLine(Word);
                Console.WriteLine("\n" + HangmanPics[gameState]);
                Console.WriteLine("Incorrect Letters Guessed: " + string.Join(", ", IncorrectGuesses));
                Console.WriteLine("Correct Letters Guessed: " + string.Join("", CorrectGuesses));
                var key = Console.ReadKey().KeyChar;
                key = Char.ToUpper(key);
                if (!CheckAnswer(key))
                {
                    gameState++;
                    IncorrectGuesses.Add(key);
                }
            }
            Console.WriteLine("Incorrect Letters Guessed: " + string.Join(", ", IncorrectGuesses));
            Console.WriteLine("Correct Letters Guessed: " + string.Join("", CorrectGuesses));
            if (CorrectGuesses.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine(HangmanPics[6]);
                Console.WriteLine("The answer was: "+ Word);
                Console.WriteLine("██╗   ██╗ ██████╗ ██╗   ██╗    ██╗      ██████╗ ███████╗████████╗██╗██╗██╗\n╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║     ██╔═══██╗██╔════╝╚══██╔══╝██║██║██║\n ╚████╔╝ ██║   ██║██║   ██║    ██║     ██║   ██║███████╗   ██║   ██║██║██║\n  ╚██╔╝  ██║   ██║██║   ██║    ██║     ██║   ██║╚════██║   ██║   ╚═╝╚═╝╚═╝\n   ██║   ╚██████╔╝╚██████╔╝    ███████╗╚██████╔╝███████║   ██║   ██╗██╗██╗\n   ╚═╝    ╚═════╝  ╚═════╝     ╚══════╝ ╚═════╝ ╚══════╝   ╚═╝   ╚═╝╚═╝╚═╝\n                                                                          \n ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ \n██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗\n██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝\n██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗\n╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║\n ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(HangmanPics[7]);
            }
            Console.WriteLine("Press enter to play again! Press any other key to quit, you quitter.");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Start();
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
