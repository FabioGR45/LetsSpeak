using BetterConsoleTables;
using Sharprompt;

namespace LetsSpeak
{
    public class SearchWords
    {
        public static string UserInput()
        {

            string wordSearch;
            do
            {
                wordSearch = Prompt.Input<string>("Write a word to be searched");


                if (!String.IsNullOrEmpty(wordSearch) && !wordSearch.Any(c => !char.IsLetter(c)))
                    break;

                Console.Clear();
                Console.WriteLine("Enter a valid word!");

            } while (true);

            return wordSearch;

        }

        public static void Search()
        {

            List<string> wordFound = new List<string>();
            List<string> wordFoundMeaning = new List<string>();

            string wordSearch = UserInput();

            foreach (var dict in Database.Dict)
            {
                if (dict.Key.Contains(wordSearch.Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    wordFound.Add(dict.Key);
                    wordFoundMeaning.Add(dict.Value);
                }
            }

            if (wordFound.Count == 0)
            {
                Console.WriteLine("No words were found!");
                return;
            }

            Console.WriteLine("\nWords with {0}:", wordSearch.ToLower());

            Console.WriteLine("\n Word   -   Meaning");


            for(int i = 0; i < wordFoundMeaning.Count; i++)
            {

                Console.WriteLine("\n-----------------------------------------------------------------");

                Console.Write(" " + wordFound[i] + "   -   " + wordFoundMeaning[i]);


            }
        }
    }
}