
using System;

///ETML
///Auteur   : Bixente Pouradier
///Date     : 13.11.2026
///1. Le code morse est un encodage.
///2. Pour l'adapté au support de transmision de la donné.
///Pseudo code  : différence code avec pseudo code : 
///Le dictionnaire du texte au morse a été mis dans le code principale pour permettre de vérifier que l'entrée de l'utilisateur est valide.
///Rajouter un compteur dans la partie du morse à alphabet
///Je ne retourne plus le code finale car c'est plus simple

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
Dictionary<char, int> hexa = new Dictionary<char, int>()
    {
        { '0', 0},
        { '1', 1},
        { '2', 2},
        { '3', 3},
        { '4', 4},
        { '5', 5},
        { '6', 6},
        { '7', 7},
        { '8', 8},
        { '9', 9},
        { 'A', 10},
        { 'B', 11},
        { 'C', 12},
        { 'D', 13},
        { 'E', 14},
        { 'F', 15},
        { 'a', 10},
        { 'b', 11},
        { 'c', 12},
        { 'd', 13},
        { 'e', 14},
        { 'f', 15},
    };

Dictionary<int, char> hexadec = new Dictionary<int, char>()
    {
        { 0, '0'},
        { 1, '1'},
        { 2, '2'},
        { 3, '3'},
        { 4, '4'},
        { 5, '5'},
        { 6, '6'},
        { 7, '7'},
        { 8, '8'},
        { 9, '9'},
        { 10, 'A'},
        { 11, 'B'},
        { 12, 'C'},
        { 13, 'D'},
        { 14, 'E'},
        { 15, 'F'},
    };

string UserChoice = " ";
int UserChoiceNumber = 0;
int UserChoiceNumber2 = 0;
string UserInput = " ";
bool Reset = false;
string valuestring = " ";
int valueint = 0;

do
{
    UserChoice = " ";
    UserChoiceNumber = 0;
    UserInput = " ";
    Reset = false;
    valuestring = " ";

    Console.Clear();

    Console.WriteLine("=== Couteau Suisse ===" +
        "\n1. Texte -> Morse" +
        "\n2. Morse -> Texte" +
        "\n3. Conversion de bases" +
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
                valuestring = "";

                Console.WriteLine("\n=== Texte -> Morse ===" +
                    "\nTexte (lettres A - Z, chiffres) :");
                UserInput = Console.ReadLine();
                for (int i = 0; i < UserInput.Length; i++)
                {
                    if (!(texte.TryGetValue(UserInput[i], out valuestring)))
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
                valuestring = "";

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

        case 3:
            Console.WriteLine("\n=== Conversion de bases ===" +
                "\n1. Decimal -> Binaire" +
                "\n2. Binaire -> Decimal" +
                "\n3. Decimal -> Octal" +
                "\n4. Octal -> Decimal" +
                "\n5. Binaire -> Octal" +
                "\n6. Octal -> Binaire" +
                "\n7. Decimal -> Hexadecimal" +
                "\n8. Hexadecimal -> Decimal");
            do
            {
                UserChoice = "";
                UserChoiceNumber2 = 0;
                Reset = false;

                Console.Write("Votre choix : ");

                UserChoice = Console.ReadLine();

                if (!(int.TryParse(UserChoice, out UserChoiceNumber2)))
                {
                    Console.WriteLine("Seul les chiffres sont autorisé.");
                    Reset = true;
                }
                else
                {
                    if (UserChoiceNumber2 == 1 || UserChoiceNumber2 == 2 || UserChoiceNumber2 == 3 || UserChoiceNumber2 == 4 || UserChoiceNumber2 == 5 || UserChoiceNumber2 == 6 || UserChoiceNumber2 == 7 || UserChoiceNumber2 == 8)
                    {
                        Reset = false;
                    }
                    else
                    {
                        Console.WriteLine("Seul les chiffres entre 1 et 8 sont autorisé.");
                        Reset = true;
                    }
                }
            } while (Reset);
            if (UserChoiceNumber2 == 1)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre décimal : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Decimal", "Binaire", UserInput);
            }
            if (UserChoiceNumber2 == 2)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre binaire : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                    else
                    {
                        if (UserChoiceNumber == 1 || UserChoiceNumber == 0 )
                        {
                            Reset = false;
                        }
                        else
                        {
                            Console.WriteLine("Seul les chiffres 1 et 0 sont autorisé.");
                            Reset = true;
                        }
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Binaire", "Decimal", UserInput);
            }
            if (UserChoiceNumber2 == 3)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre décimal : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Decimal", "Octal", UserInput);
            }
            if (UserChoiceNumber2 == 4)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre octal : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                    else
                    {
                        if (UserChoiceNumber2 == 1 || UserChoiceNumber2 == 2 || UserChoiceNumber2 == 3 || UserChoiceNumber2 == 4 || UserChoiceNumber2 == 5 || UserChoiceNumber2 == 6 || UserChoiceNumber2 == 7 || UserChoiceNumber2 == 0)
                        {
                            Reset = false;
                        }
                        else
                        {
                            Console.WriteLine("Seul les chiffres entre 0 et 7 sont autorisé.");
                            Reset = true;
                        }
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Octal", "Decimal", UserInput);
            }
            if (UserChoiceNumber2 == 5)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre binaire : ");
                UserInput = Console.ReadLine();
                if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                {
                    Console.WriteLine("Seul les chiffres sont autorisé.");
                    Reset = true;
                }
                else
                {
                    if (UserChoiceNumber == 1 || UserChoiceNumber == 0)
                    {
                        Reset = false;
                    }
                    else
                    {
                        Console.WriteLine("Seul les chiffres 1 et 0 sont autorisé.");
                        Reset = true;
                    }
                }
            } while (Reset) ;
            Console.Write("Résultat : ");
                Convertiondebase("Binaire", "Octal", UserInput);
            }
            if (UserChoiceNumber2 == 6)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre octal : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                    else
                    {
                        if (UserChoiceNumber2 == 1 || UserChoiceNumber2 == 2 || UserChoiceNumber2 == 3 || UserChoiceNumber2 == 4 || UserChoiceNumber2 == 5 || UserChoiceNumber2 == 6 || UserChoiceNumber2 == 7 || UserChoiceNumber2 == 0)
                        {
                            Reset = false;
                        }
                        else
                        {
                            Console.WriteLine("Seul les chiffres entre 0 et 7 sont autorisé.");
                            Reset = true;
                        }
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Octal", "Binaire", UserInput);
            }
            if (UserChoiceNumber2 == 7)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre décimal : ");
                    UserInput = Console.ReadLine();
                    if (!(int.TryParse(UserInput, out UserChoiceNumber)))
                    {
                        Console.WriteLine("Seul les chiffres sont autorisé.");
                        Reset = true;
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Decimal", "Hexadecimal", UserInput);
            }
            if (UserChoiceNumber2 == 8)
            {
                do
                {
                    Reset = false;
                    Console.Write("Nombre hexadecimal : ");
                    UserInput = Console.ReadLine();
                    for (int i = 0; i <= UserInput.Length - 1; i++)
                    {
                        if (hexa.TryGetValue(UserInput[i], out valueint))
                        {
                            Reset = false;
                        }
                        else
                        {
                            Console.WriteLine("Seul les chiffres entre 0 et 9 et les lettres entre a et f sont autorisé.");
                            Reset = true;
                        }
                    }
                } while (Reset);
                Console.Write("Résultat : ");
                Convertiondebase("Hexadecimal", "Decimal", UserInput);
            }
            break;

        case 0:
            continue;
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
        if (texte.TryGetValue(UserInput[i], out valuestring))
        {
            Translation += valuestring + " ";
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
        valuestring = "";
        if (!(UserInput[i].Equals(' ')))
        {
            FragUserInput += UserInput[i];
        }

        if (UserInput.Length - 1 <= i || UserInput[i].Equals(' '))
        {
            space = true;
        }


        if (morse.TryGetValue(FragUserInput, out valuestring) && space)
        {
            Translation += valuestring;
            FragUserInput = "";
            space = false;
        }

        if (valuestring == null && space)
        {
            NoCharactere++;
            FragUserInput = "";
            space = false;
        }
    }
    Console.WriteLine(Translation);
    Console.WriteLine("Nombre de caractère non reconnu : " + NoCharactere);
}


void Convertiondebase(string initial, string finale, string codeInitial)
{
    int coderestant = 0;
    string codetraduit = "";
    int valueint = 0;
    char valuechar = ' ';
    double codefinal = 0;

    if (initial != "hexa")
        int.TryParse(codeInitial, out coderestant);

    if (initial == "Decimal")
    {
        //
        if (finale == "Binaire")
        {
            do
            {
                codetraduit = (coderestant % 2) + codetraduit;
                coderestant = (coderestant - (coderestant % 2)) / 2;
            } while (coderestant > 0);
            Console.WriteLine(codetraduit);
        }

        //
        if (finale == "Octal")
        {
            do
            {
                codetraduit = (coderestant % 8) + codetraduit;
                coderestant = (coderestant - (coderestant % 8)) / 8;
            } while (coderestant >= 8);
            codetraduit = coderestant + codetraduit;
            Console.WriteLine(codetraduit);
        }

        //
        if (finale == "Hexadecimal")
        {
            do
            {
                do
                {
                    coderestant = int.Parse(codeInitial.ToString()) % 16;
                    if (coderestant == 0)
                    {
                        coderestant = int.Parse(codeInitial.ToString()) / 16;
                        codeInitial = (int.Parse(codeInitial.ToString()) - coderestant * 16).ToString();
                    }
                    else
                    {
                        codeInitial = (int.Parse(codeInitial.ToString()) - coderestant).ToString();
                    }
                } while (coderestant > 15);
                if (hexadec.TryGetValue(coderestant, out valuechar))
                    codetraduit = valuechar + codetraduit;
            } while (int.Parse(codeInitial.ToString()) > 0);
            Console.WriteLine(codetraduit);
        }
    }

    if (initial == "Binaire")
    {
        //
        if (finale == "Decimal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(2, codeInitial.Length - i - 1));
            }
            Console.WriteLine(codefinal);
        }

        //
        if (finale == "Octal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(2, codeInitial.Length - i - 1));
            }
            Convertiondebase("Decimal", "Octal", codefinal.ToString());
        }

        if (finale == "Hexadecimal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(2, codeInitial.Length - i - 1));
            }
            Convertiondebase("Decimal", "Octal", codefinal.ToString());
        }
    }

    if (initial == "Octal")
    {
        //
        if (finale == "Decimal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(8, codeInitial.Length - i - 1));
            }
            Console.WriteLine(codefinal);
        }

        //
        if (finale == "Binaire")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(8, codeInitial.Length - i - 1));
            }
            Convertiondebase("Decimal", "Binaire", codefinal.ToString());
        }

        if (finale == "Hexadecimal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                codefinal = codefinal + (int.Parse(codeInitial[i].ToString()) * Math.Pow(8, codeInitial.Length - i - 1));
            }
            Convertiondebase("Decimal", "Binaire", codefinal.ToString());
        }
    }

    if (initial == "Hexadecimal")
    {
        //
        if (finale == "Decimal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                if (hexa.TryGetValue(codeInitial[i], out valueint))
                    codefinal = codefinal + valueint * Math.Pow(16, codeInitial.Length - i - 1);
            }
            Console.WriteLine(codefinal);
        }

        if (finale == "Binaire")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                if (hexa.TryGetValue(codeInitial[i], out valueint))
                    codefinal = codefinal + valueint * Math.Pow(16, codeInitial.Length - i - 1);
            }
            Console.WriteLine(codefinal);
            Convertiondebase("Decimal", "Binaire", codefinal.ToString());
        }

        if (finale == "Octal")
        {
            for (int i = 0; i <= codeInitial.Length - 1; i++)
            {
                if (hexa.TryGetValue(codeInitial[i], out valueint))
                    codefinal = codefinal + valueint * Math.Pow(16, codeInitial.Length - i - 1);
            }
            Console.WriteLine(codefinal);
            Convertiondebase("Decimal", "Octal", codefinal.ToString());
        }
    }
}