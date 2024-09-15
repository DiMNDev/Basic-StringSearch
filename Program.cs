// See https://aka.ms/new-console-template for more information
string[] arrayOfStrings = ["banana", "orange", "apple", "macintosh", "star", "bilbo", "gandalf", "Helly R.", "Mark S.", "goose", "duck", "llama", "spruce", "diamond", "carmen sandiego"];

string SearchFor(string word, string[] wordArray)
{
    string returnMessage = $"{word} not found";

    for (int i = 0; i < wordArray.Length; i++)
    {
        if (wordArray[i] == word)
        {
            returnMessage = $"{word} was found at index {i}";
        }
    }

    return returnMessage;
}

Console.WriteLine(SearchFor("carmen sandiego", arrayOfStrings));
Console.WriteLine(SearchFor("waldo", arrayOfStrings));