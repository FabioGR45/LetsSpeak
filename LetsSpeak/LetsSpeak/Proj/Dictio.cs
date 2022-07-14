using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharprompt;
using BetterConsoleTables;
using System.ComponentModel.DataAnnotations;

namespace LetsSpeak
{
    public class Dictio
    {
        [Display(Name = "Enter the word you want to add")]
        public string word { get; set; }

        [Display(Name = "Enter the meaning of the word")]
        public string meaning { get; set; }

        public static void registerWords()
        {
            Console.Clear();
            var inputedWord = Prompt.Bind<Dictio>();

            var confirmWord = Prompt.Confirm("Confirm this?");

            if (!confirmWord)
                return;

            if (!Database.Dict.ContainsKey(inputedWord.word)) {
            
                Database.Dict.Add(inputedWord.word.ToLower(), inputedWord.meaning.ToLower());
                DatabaseSave.Save(Database.Dict, Database._DictioDb);
            
            } else {

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n" + inputedWord.word + " already exists in the dictionary!");
                Console.ReadLine();
                Console.ResetColor();
                return;

            }


            Console.Clear();
            Console.WriteLine($"\n'the {inputedWord.word}' has been added!");
        }

        public static void removeWords()
        {

            Console.WriteLine("Enter the word to remove");
            var wordToRemove = Console.ReadLine();

            var confirmWord = Prompt.Confirm("Are you sure you to remove " + wordToRemove + "?");

            if (Database.Dict.ContainsKey(wordToRemove)){

                if (!confirmWord)
                    return;

                Database.Dict.Remove(wordToRemove);
                DatabaseSave.Save(Database.Dict, Database._DictioDb);

            } else {

                Console.WriteLine(wordToRemove + " does not exist in the dictionary!");
                return;

            }

            Console.WriteLine("\nThe word " + wordToRemove + " has been removed!");
            return;

        }
    }
}
