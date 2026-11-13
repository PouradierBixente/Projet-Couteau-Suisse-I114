///ETML
///Auteur   : Bixente Pouradier
///Date     : 13.11.2026
///1. Le code morse est un encodage.
///2. Pour l'adapté au support de transmision de la donné.
///Pseudo code  : différence code avec pseudo code : 
///Le dictionnaire du texte au morse a été mis dans le code principale pour permettre de vérifier que l'entrée de l'utilisateur est valide.
///Rajouter un compteur dans la partie du morse à alphabet 

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
        {'a', ".-"},
        {'b', "-..."},
        {'c', "-.-."},
        {'d', "-.."},
        {'e', "."},
        {'f', "..-."},
        {'g', "--."},
        {'h', "...."},
        {'i', ".."},
        {'j', ".---"},
        {'k', "-.-"},
        {'l', ".-.."},
        {'m', "--"},
        {'n', "-."},
        {'o', "---"},
        {'p', ".--."},
        {'q', "--.-"},
        {'r', ".-."},
        {'s', "..."},
        {'t', "-"},
        {'u', "..-"},
        {'v', "...-"},
        {'w', ".--"},
        {'x', "-..-"},
        {'y', "-.--"},
        {'z', "--.."},
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

string UserChoice = " ";
int UserChoiceNumber = 0;
string UserInput = " ";
bool Reset = false;
string value = " ";

do
{
    UserChoice = " ";
    UserChoiceNumber = 0;
    UserInput = " ";
    Reset = false;
    value = " ";

    Console.Clear();

    Console.WriteLine("=== Couteau Suisse ===" +
        "\n1. Texte -> Morse" +
        "\n2. Morse -> Texte" +
        "\n3. (à venir)" +
        "\n4. (à venir)" +
        "\n0. Quitter");
    do
    {
        UserChoice = "";
        UserChoiceNumber = 0;
        Reset = false;

        Console.Write("Votre choix : ");

        UserChoice = Console.ReadLine();

        if (!(int.TryParse(UserChoice, out UserChoiceNumber)))
        {
            Console.WriteLine("Seul les chiffres sont autorisé.");
            Reset = true;
        }
        else
        {
            if (UserChoiceNumber == 1 || UserChoiceNumber == 2 || UserChoiceNumber == 3 || UserChoiceNumber == 4 || UserChoiceNumber == 0)
            {
                Reset = false;
            }
            else
            {
                Console.WriteLine("Seul les chiffres entre 0 et 4 sont autorisé.");
                Reset = true;
            }
        }
    } while (Reset);

    switch (UserChoiceNumber)
    {
        case 1:
            do
            {
                UserInput = "";
                Reset = false;
                value = "";

                Console.WriteLine("\n=== Texte -> Morse ===" +
                    "\nTexte (lettres A - Z, chiffres) :");
                UserInput = Console.ReadLine();
                for (int i = 0; i < UserInput.Length; i++)
                {
                    if (!(texte.TryGetValue(UserInput[i], out value)))
                    {
                        Console.WriteLine("Seul les lettres et chiffres sont autorisés.");
                        Reset = true;
                        break;
                    }
                }
                if (UserInput == "")
                {
                    Console.WriteLine("Une saisie vide est invalide.");
                    Reset = true;
                }
            } while (Reset);
            Console.WriteLine("Résultat en Morse :");
            ConvertirTexteMorse(UserInput);
            break;

        case 2:
            do
            {
                UserInput = "";
                Reset = false;
                value = "";

                Console.WriteLine("\n=== Morse -> Texte ===" +
                    "\nMorse (. - espace /) :");
                UserInput = Console.ReadLine();
                for (int i = 0; i < UserInput.Length; i++)
                {
                    if (!(UserInput[i].Equals('.') || UserInput[i].Equals('-') || UserInput[i].Equals(' ') || UserInput[i].Equals('/')))
                    {
                        Console.WriteLine("Seul les charactères (., -, espace, /) sont autorisés.");
                        Reset = true;
                        break;
                    }
                }
                if (UserInput == "")
                {
                    Console.WriteLine("Une saisie vide est invalide.");
                    Reset = true;
                }
            } while (Reset);
            Console.WriteLine("Résultat en texte :");
            ConvertirMorseTexte(UserInput);

            break;
    }

    Console.Write("Voulez-vous recommencer ?[Y/N] :");

    UserChoice = Console.ReadLine();
    if (UserChoice == "Y" || UserChoice == "y")
    {
        Reset = true;
    }
    else
    {
        Reset = false;
    }

} while (Reset);









void ConvertirTexteMorse(string UserInput)
{
    string Translation = "";

    for (int i = 0; i < UserInput.Length; i++)
    {
        if (texte.TryGetValue(UserInput[i], out value))
        {
            Translation += value + " ";
        }
    }
    Console.WriteLine(Translation);
}

void ConvertirMorseTexte(string UserInput)
{
    string Translation = "";
    string FragUserInput = "";
    bool space = false;
    int NoCharactere = 0;
    Dictionary<string, string> morse = new Dictionary<string, string>()
    {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" },
        { "-..", "D" },
        { ".", "E" },
        { "..-.", "F" },
        { "--.", "G" },
        { "....", "H" },
        { "..", "I" },
        { ".---", "J" },
        { "-.-", "K" },
        { ".-..", "L" },
        { "--", "M" },
        { "-.", "N" },
        { "---", "O" },
        { ".--.", "P" },
        { "--.-", "Q" },
        { ".-.", "R" },
        { "...", "S" },
        { "-", "T" },
        { "..-", "U" },
        { "...-", "V" },
        { ".--", "W" },
        { "-..-", "X" },
        { "-.--", "Y" },
        { "--..", "Z" },
        { "-----", "0" },
        { ".----", "1" },
        { "..---", "2" },
        { "...--", "3" },
        { "....-", "4" },
        { ".....", "5" },
        { "-....", "6" },
        { "--...", "7" },
        { "---..", "8" },
        { "----.", "9" },
        {"/", " "}
    };

    for (int i = 0; i < UserInput.Length; i++)
    {
        value = "";
        if (!(UserInput[i].Equals(' ')))
        {
            FragUserInput += UserInput[i];
        }

        if (UserInput.Length - 1 <= i || UserInput[i].Equals(' '))
        {
            space = true;
        }


        if (morse.TryGetValue(FragUserInput, out value) && space)
        {
            Translation += value;
            FragUserInput = "";
            space = false;
        }

        if (value == null && space)
        {
            NoCharactere++;
        }
    }
    Console.WriteLine(Translation);
    Console.WriteLine("Nombre de caractère non reconnu : " + NoCharactere + ".");
}