using System.Text.RegularExpressions;

namespace ConsoleSF;

public class CharacterSelector
{
    // Character class name zaridit aby class name nebyla uknown ktera je definovana v Character.cs 


    private string name;
    private int characterChoice;
    Character yourCharacter;

    /// <summary>
    /// Allows the user to choose a character type (Warrior, Mage, or Archer) and set a valid name for the character.
    /// The created character will have specific attributes based on the chosen type.
    /// </summary>
    /// <returns>A Character object representing the user's chosen character type with initialized attributes.</returns>
    /// <exception cref="InvalidOperationException">Thrown if an unknown character type is encountered during selection.</exception>
    public Character ChooseYourCharacter()
    {
        do
        {
            Console.WriteLine("Choose your character:\n");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Archer");

            if (!int.TryParse(Console.ReadLine(), out characterChoice) || characterChoice < 1 || characterChoice > 3)
            {
                Console.WriteLine("Prosim zadejte cislo v rozsahu 1-3.");
                continue;
            }

            switch (characterChoice)
            {
                case 1:
                    Console.Clear();
                    MakeValidName("Warrior");
                    yourCharacter = new Warrior(name, 125, 20, 30, new MessageManager());
                    yourCharacter.SetClassName("Warrior");
                    break;
                case 2:
                    Console.Clear();
                    MakeValidName("Mage");
                    ;
                    yourCharacter = new Mage(name, 80, 40, 5, 80, 100, new MessageManager());
                    yourCharacter.SetClassName("Mage");
                    break;
                case 3:
                    Console.Clear();
                    MakeValidName("Archer");
                    yourCharacter = new Archer(name, 100, 30, 10, new MessageManager());
                    yourCharacter.SetClassName("Archer");
                    break;
                default:
                    throw new InvalidOperationException("Unknown character type.");
            }
        } while (characterChoice < 1 || characterChoice > 3);

        Console.WriteLine($"You choose character: {yourCharacter.ClassName}\nYour name is: {yourCharacter.Name}");
        return yourCharacter;
    }

    /// <summary>
    /// Ensures the validity of a character name entered by the user based on specific criteria.
    /// The name must be at least 3 characters long, contain no digits, only include alphabetical characters,
    /// and will have its first letter capitalized if valid.
    /// </summary>
    /// <param name="typeOfCharacter">The type of character being created, used for display purposes.</param>
    /// <returns>A valid character name with the first letter capitalized.</returns>
    private string MakeValidName(string typeOfCharacter)
    {
        bool isValidName = false;
        do
        {
            Console.Write($"Zadejte jmeno vaseho characteru ({typeOfCharacter}) : ");
            name = Console.ReadLine().Trim().ToLower();
            if (name.Length <= 2 || name == null)
            {
                Console.WriteLine(
                    "Vase jmeno je prilis kratke, zadejte prosim znovu. (Jmeno musi obsahovat alespon 3 znaky)");
                isValidName = false;
                continue;
            }

            // kontroluje zda uzivatel zadal jmeno vyssi nebo rovno 3 znaku 
            if (name.Length >= 3)
            {
                // kontroluje zda uzivatel nezadal cislo
                if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Prosim zadejte jmeno bez cisel.");
                    isValidName = false;
                    continue;
                }

                // kontroluje zda uzivatel nezadal nejaky jiny znak krom a-z z anglicke abecedy 
                if (!Regex.IsMatch(name, @"^[a-z]+$"))
                {
                    Console.WriteLine("Jmeno musi obsahovat pouze pismena, zadejte prosim znovu.");
                    isValidName = false;
                    continue;
                }

                isValidName = true;
            }
        } while (!isValidName);

        // zajisti aby prvni pismeno bylo velke 
        if (!string.IsNullOrEmpty(name))
        {
            // substring vrati zbytek retezce 
            name = char.ToUpper(name[0]) + name.Substring(1);
        }

        return name;
    }
}