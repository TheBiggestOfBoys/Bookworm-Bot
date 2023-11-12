namespace Bookworm_Bot
{
    internal class Program
    {
        static void Main()
        {
            List<string> validWords = new();

            #region Read Text files containing valid words
            string[] fileNames = { "colors.txt", "mammals.txt", "metals.txt", "words.txt" };
            foreach (string fileName in fileNames)
            {
                using StreamReader reader = new($"C:\\Users\\jrsco\\source\\repos\\Bookworm Bot\\Bookworm Bot\\Word Banks\\{fileName}");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    validWords.Add(line);
                }
            }
            #endregion

            Console.Write("Enter the letters all together ('q' for 'qu'): ");
            string letters = Console.ReadLine();

            List<string> words = GenerateCombinations(letters, validWords);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        public static List<string> GenerateCombinations(string input, List<string> validWords)
        {
            // Create an empty list to store the results
            List<string> result = new();

            // Calculate the power set size
            int npow = 1 << input.Length;

            // Loop over the power set
            for (int i = 0; i < npow; i++)
            {
                // Initialize an empty string for each combination
                string combination = string.Empty;

                // Loop over the characters in the input string
                for (int j = 0; j < input.Length; j++)
                {
                    // If the jth bit in i is set, add the jth character of the input string to the combination
                    if ((i & (1 << j)) != 0)
                    {
                        combination += input[j];
                    }
                }

                // If the combination is not empty and is in the validWords list, add it to the result list
                if (!string.IsNullOrEmpty(combination) && validWords.Contains(combination))
                {
                    result.Add(combination);
                }
            }

            // Return the result list
            return result;
        }
    }
}
