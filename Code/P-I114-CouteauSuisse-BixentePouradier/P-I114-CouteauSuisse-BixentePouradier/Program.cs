// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

string UserChoice = "";
int UserChoiceNumber = 0;
string UserInput = "";

Console.WriteLine("=== Couteau Suisse ===" +
    "\n1. Texte -> Morse" +
    "\n2. Morse -> Texte" +
    "\n3. (à venir)" +
    "\n4. (à venir)" +
    "\n0. Quitter" +
    "Votre choix : ");

UserChoice = Console.ReadLine();

if (!(int.TryParse(UserChoice, out UserChoiceNumber)))
{
    Console.WriteLine("Seul les chiffres sont autorisé.");
}

if(UserChoiceNumber != 1 || UserChoiceNumber != 2 || UserChoiceNumber != 3 || UserChoiceNumber != 4 || UserChoiceNumber != 0)
{
    Console.WriteLine("Seul les chiffres entre 0 et 4 sont autorisé.");
}

switch (UserChoiceNumber)
{
    case 1:
        Console.WriteLine();
        break;
}

string ConvertirTexteMorse (string UserInput)
{
    string Translation = "";
    string value = "";
    Dictionary<char, string> texte = new Dictionary<char, string>()
    {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."},
        {'0', "-----"},
        {'1', ".----"},
        {'2', "..---"},
        {'3', "...--"},
        {'4', "....-"},
        {'5', "....."},
        {'6', "-...."},
        {'7', "--..."},
        {'8', "---.."},
        {'9', "----."},
        {' ', "/"},
    };

    for (int i = 0; i < UserInput.Length; i++)
    {
        if (texte.TryGetValue(UserInput[i], out value))
        {
            Translation += value + " ";
        }
    }
    return Translation;
}

string ConvertirMorseTexte(string UserInput)
{
    string Translation = "";
    string FragUserInput = "";
    bool space = false;
    string value = "";
    Dictionary<string, string> morse = new Dictionary<string, string>();

    for (int i = 0; i < UserInput.Length; i++)
    {
        if (UserInput[i].Equals(" "))
        {
            FragUserInput += UserInput[i];
        }
        else
        {
            space = true;
        }


        if (morse.TryGetValue(FragUserInput, out value) && space)
        {
            Translation += value;
            FragUserInput = "";
            space = false;
        }
    }
    return Translation;
}