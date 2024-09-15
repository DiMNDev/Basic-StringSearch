// See https://aka.ms/new-console-template for more information
using CrypticWizard.RandomWordGenerator;

string[] arrayOfStrings = ["banana", "orange", "apple", "macintosh", "star", "star", "bilbo", "gandalf", "Helly R.", "Mark S.", "goose", "duck", "llama", "spruce", "diamond", "carmen sandiego"];
string[] largeArrayOfRandomWords = new string[1000];

#region Main()
Console.Clear();
SearchFor("carmen sandiego", arrayOfStrings);
SearchFor("waldo", arrayOfStrings);
GenerateRandomWordsArray(largeArrayOfRandomWords);
string targetToFind = PickRandomWordInArray(largeArrayOfRandomWords);
SearchFor(targetToFind, largeArrayOfRandomWords);
#endregion

void SearchFor(string word, string[] wordArray)
{
    string returnMessage = $"{word} not found";

    for (int i = 0; i < wordArray.Length; i++)
    {
        if (wordArray[i] == word)
        {
            returnMessage = $"{word} was found at index {i}";
        }
    }
    Console.WriteLine(returnMessage);
}

void GenerateRandomWordsArray(string[] arrayOfWords)
{
    int generationCount = arrayOfWords.Length;
    string generationStatusMessage = $"Generating {generationCount.ToString()} more words.";
    Console.WriteLine(generationStatusMessage);
    for (int i = 0; i < largeArrayOfRandomWords.Length; i++)
    {
        generationStatusMessage = $"Generating {(generationCount - i).ToString()} more words.";
        ClearLine(2);
        Console.WriteLine(generationStatusMessage);
        string randomWord = GenerateRandomWord(arrayOfWords);
        arrayOfWords[i] = randomWord;
    }
    ClearLine(2);
    Console.WriteLine("DONE!");
}

string GenerateRandomWord(string[] arrayOfWords)
{
    WordGenerator RandomWordGenerator = new WordGenerator();
    string randomWord = RandomWordGenerator.GetWord(WordGenerator.PartOfSpeech.noun);
    for (int i = 0; i < arrayOfWords.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (arrayOfWords[j] == randomWord)
            {
                return GenerateRandomWord(arrayOfWords);
            }
        }
    }
    return randomWord;
}

string PickRandomWordInArray(string[] wordArray)
{
    Random randomNumber = new Random();
    int randomIndex = randomNumber.Next(0, wordArray.Length);
    Console.WriteLine($"{wordArray[randomIndex]} was randomly selected");
    return wordArray[randomIndex];
}

void ClearLine(int row)
{
    Console.SetCursorPosition(0, row);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, row);
}

#region Debugging    
(string status, List<int> duplicates) CheckForDuplicates(string[] arrayOfWords)
{
    List<int> duplicates = [];
    string status = "No Duplicates Found";
    for (int i = 0; i < arrayOfWords.Length; i++)
    {
        if (arrayOfWords[i] != null)
        {

            for (int j = 0; j < i; j++)
            {
                if (arrayOfWords[j] == arrayOfWords[i])
                {
                    duplicates.Add(i);
                    status = "Duplicates Present";
                    Console.WriteLine($"RandomWord: {arrayOfWords[i]} at i:{i}");
                    Console.WriteLine($"RandomWord: {arrayOfWords[j]} at j:{j}");
                }
            }
        }

    }
    return (status, duplicates);
}

void PrintDuplicates(List<int> duplicates)
{
    Console.WriteLine($"There are {duplicates.Count} ");
    foreach (var duplicate in duplicates)
    {
        Console.Write($"{duplicate}, ");
        Console.WriteLine($"{largeArrayOfRandomWords[duplicate]}, ");
        SearchFor(largeArrayOfRandomWords[duplicate], largeArrayOfRandomWords);
    }
}
#endregion