using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman
{
    public class ProgramUI
    {
        private string[] HangmanPics = new String[]{

        "
  +---+\n
  |   |\n
      |\n
      |\n
      |\n
      |\n
=========",

"
  +---+\n
  |   |\n
  O   |\n
      |\n
      |\n
      |\n
=========", 
"
  +---+\n
  |   |\n
  O   |\n
  |   |\n
      |\n
      |\n
=========", 
"
  +---+\n
  |   |\n
  O   |\n
 /|   |\n
      |\n
      |\n
=========",
"
  +---+\n
  |   |\n
  O   |\n
 /|\  |\n
      |\n
      |\n
=========", 
"
  +---+\n
  |   |\n
  O   |\n
 /|\  |\n
 /    |\n
      |\n
=========", 
"
  +---+\n
  |   |\n
  O   |\n
 /|\  |\n
 / \  |\n
      |\n
========="
}
        public void Run()
        {
            Console.WriteLine("Hi Mom");
        }
    }
}