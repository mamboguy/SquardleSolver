using ClassLibrary;
using ClassLibrary.Solvers;
using ClassLibrary.DictionaryTrees;

public class Program
{
    private static bool ShowGridPrintout = false;
    private static bool AllowDictionaryQuery = false;

    /// <summary>
    /// Entry point for the program
    /// </summary>
    private static void Main(string[] args)
    {
        ISquardleSolver? solver;
        ISquardleDictionary dictionary = new DictionaryTree();
        var factory = new SquardleSolverFactory();

        do
        {
            Console.WriteLine("Enter the squardle from left to right, top to bottom: ");
            var squardleValues = Console.ReadLine();

            solver = factory.Create(squardleValues, dictionary);

            if (solver is null)
            {
                Console.WriteLine();
                Console.WriteLine("Not a valid squardle grid, please re-enter");
                Console.WriteLine();
            }

        } while (solver is null);

        // Debug to show how the grid was created
        if (ShowGridPrintout)
        {
            Console.WriteLine();
            Console.WriteLine(solver.ToString());
            Console.WriteLine();
        }

        // Debug to check if the dictionary has certain words
        if (AllowDictionaryQuery)
        {
            bool exit = false;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Check if a word exists (1 to exit): ");

                var word = Console.ReadLine();

                exit = word == "1";

                if (exit)
                {
                    break;
                }

                var isWord = dictionary.IsWord(word);
                var isValidSequence = dictionary.IsValidSequence(word);

                Console.WriteLine($"The word {word} was {(isWord ? string.Empty : "not ")}found and is {(isValidSequence ? string.Empty : "not ")}a valid sequence");
            }
        }

        // Solves the squardle
        var words = solver.Solve();

        // Answer display
        Console.WriteLine($"There are {words.Count()} answers to today's puzzle");

        for (int i = 4; i < 16; i++)
        {
            var wordList = words.Where(x => x.Length == i).OrderBy(x => x).ToList();

            if (wordList.Any())
            {
                Console.WriteLine();
                Console.WriteLine($"The {i} letter words in the puzzle are: ");

                foreach (var word in wordList)
                {
                    Console.WriteLine($"{word}");
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
}