namespace ConsoleSF;

// Vyresit problem s pristupem charakteru do boje 
public class Arena()
{
    private Character myCharacter;
    private Character Enemy { get; }
    CharacterSelector characterSelector = new CharacterSelector();
    private EnemyClass _enemyClass = new EnemyClass();

    public void Start()
    {
        // Sett Your character
        GetYourCharacter();

        // Sett enemy
        GetEnemy();
        
        // Fight (problem is here!!!) 
        myCharacter.Attack(Enemy);
        Enemy.Attack(myCharacter);
    }

    private void GetYourCharacter()
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
    }

    private void GetEnemy()
    {
        Console.WriteLine("1. Choose your enemy class");
        Console.WriteLine("2. Random enemy class");
        bool isCorrectChoice = false;
        
        do
        {
            int enemyChoice;
            while (!int.TryParse(Console.ReadLine(), out enemyChoice))
            {
                Console.WriteLine("Wrong input! Please try again. (1-2)");
            }

            if (enemyChoice == 1)
            {
                isCorrectChoice = true;
                _enemyClass.ChooseYourEnemy(Enemy);
            }

            else if (enemyChoice == 2)
            {
                isCorrectChoice = true;
                _enemyClass.GetEnemyCharacter(Enemy);
            }
            else
            {
                Console.WriteLine("Wrong input! Please try again. (1-2)");
                isCorrectChoice = false;
            }
        } while (!isCorrectChoice);
        PressEnter();
        Console.Clear();
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