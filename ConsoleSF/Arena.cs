namespace ConsoleSF;


// Vyresit problem s inicializaci enemy 
public class Arena()
{
    private Character myCharacter;
    private Character enemy;
    CharacterSelector characterSelector = new CharacterSelector();
    private EnemyClass _enemyClass;

    public void Start()
    {
        // introductin
        Console.WriteLine("Welcome to the game ConsoleSF\nPress enter to start");
        PressEnter();
        
        // Classes to choose
        Console.WriteLine("Classes to choose:\n");
        CharacterDescription.ClassesDescription();
        
        // Choose your character
        characterSelector.ChooseYourCharacter(myCharacter);
        Console.WriteLine("Continue with pressing enter");
        PressEnter();
        Console.Clear();
        
        // Sett enemy
        Console.WriteLine("1. Random enemy class");
        Console.WriteLine("2. Choose your enemy class");
        int enemyChoice;
        while (!int.TryParse(Console.ReadLine(), out enemyChoice))
        {
            Console.WriteLine("Wrong input! Please try again. (1-2)");
        }

        while (enemyChoice == 1 || enemyChoice == 2)
        {
            if (enemyChoice == 1)
            {
                _enemyClass.GetEnemyCharacter(enemy);
            }

            if (enemyChoice == 2)
            {
                _enemyClass.ChooseYourEnemy(enemy);
            }
        }
    }

    /// <summary>
    /// Waits for the user to press the Enter key before continuing execution.
    /// If a different key is pressed, an error message will be displayed,
    /// prompting the user to press the correct key.
    /// </summary>
    private void PressEnter()
    {
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            Console.WriteLine("\"Invalid key! Please press Enter to continue...\"\n");
        }
    }
}