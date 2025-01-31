using System.Threading.Channels;

namespace ConsoleSF;

// Vyresit problem s pristupem charakteru do boje 
public class Arena()
{
    private Character MyCharacter { get; set; }
    private Character Enemy { get; set; }
    readonly CharacterSelector _characterSelector = new();
    private readonly EnemyClass _enemyClass = new();

    public void Start()
    {
        Console.WriteLine("Welcome to Arena!");
        Console.WriteLine("Press enter to continue...");
        PressEnter();
        Console.Clear();

        bool playAgain = true;
        do
        {
            bool validChoice;
            do
            {
                Console.WriteLine("1. Start game");
                Console.WriteLine("2. End game");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wrong choice, please try again.");
                }
                switch (choice)
                {
                    case 1:
                        validChoice = true;
                        // Sett Your character
                        GetYourCharacter();

                        // Sett enemy
                        GetEnemy();

                        // Fight 
                        Fight(MyCharacter, Enemy);
                        Console.WriteLine("Press enter to continue...");
                        PressEnter();
                        Console.Clear();
                        
                        // Play again
                        Console.WriteLine("1. New game");
                        Console.WriteLine("2. Write the previous fight");
                        Console.WriteLine("3. Exit game");
                        int playAgainChoice;
                        while (!int.TryParse(Console.ReadLine(), out playAgainChoice))
                            Console.WriteLine("Wrong input! Please try again. (1-2)");
                        switch (playAgainChoice)
                        {
                            case 1:
                                playAgain = true;
                                MyCharacter = null;
                                Enemy = null;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Your messages:");
                                Console.WriteLine(MyCharacter._messageManager.PrintRecordedMessages());
                                Console.WriteLine();
                                Console.WriteLine("Enemy messages:");
                                Console.WriteLine(Enemy._messageManager.PrintRecordedMessages());
                                break;
                            case 3:
                                playAgain = false;
                                break;
                            default:
                                Console.WriteLine("Wrong choice. Please try again.");
                                // validChoice = false; // zde dodelat kod
                                break;
                        }
                        break;
                    case 2:
                        validChoice = true;
                        playAgain = false;
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Please try again.");
                        validChoice = false;
                        break;
                
                }

            } while (!validChoice);
        } while (playAgain);
        
    }

    /// <summary>
    /// Initializes and sets up the player's character by allowing them to choose
    /// from available character classes. Displays class descriptions to assist in the selection.
    /// Prompts the user to confirm their choice and provides the option to proceed
    /// after completing the setup.
    /// </summary>
    private void GetYourCharacter()
    {
        // introductin
        Console.WriteLine("Welcome to the game ConsoleSF\nPress enter to start");
        PressEnter();

        // Classes to choose
        Console.WriteLine("Classes to choose:\n");
        CharacterDescription.ClassesDescription();

        // Choose your character
        MyCharacter = _characterSelector.ChooseYourCharacter(MyCharacter);
        // characterSelector.ChooseYourCharacter(myCharacter);
        Console.WriteLine("Continue with pressing enter");
        PressEnter();
        Console.Clear();
    }

    /// <summary>
    /// Sets up the enemy character for the player's battle. Allows the player to either choose an enemy class
    /// manually or generate a random enemy class. Validates the player's input and ensures the setup process
    /// is completed before proceeding.
    /// </summary>
    private void GetEnemy()
    {
        Console.WriteLine("1. Choose your enemy class");
        Console.WriteLine("2. Random enemy class");
        bool isCorrectChoice;

        do
        {
            int enemyChoice;
            while (!int.TryParse(Console.ReadLine(), out enemyChoice))
            {
                Console.WriteLine("Wrong input! Please try again. (1-2)");
            }

            if (enemyChoice == 1)
            {
                Enemy = _enemyClass.ChooseYourEnemy();
                isCorrectChoice = true;
            }

            else if (enemyChoice == 2)
            {
                Enemy = _enemyClass.GetEnemyCharacter();
                isCorrectChoice = true;
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

    private void Fight(Character character1, Character character2)
    {
        Console.WriteLine($"Fight between {character1.Name} and {character2.Name}");
        Console.WriteLine("Press enter to start roll");
        PressEnter();
        Console.Clear();

        // Roll
        if (RandomGenerator.GetFiftyFifty() == 0)
        {
            character1 = MyCharacter;
            character2 = Enemy;
            Console.WriteLine($"You starting fight");
        }
        else
        {
            character1 = Enemy;
            character2 = MyCharacter;
            Console.WriteLine("Your opponent starting fight");
        }

        Console.WriteLine("Press enter to start fight");
        do
        {
            if (character1.isAlive())
            {
                character1.Attack(character2);
                Console.WriteLine($"{character2}");
                Thread.Sleep(1000);
                // Console.Clear();
            }

            if (character2.isAlive())
            {
                character2.Attack(character1);
                Console.WriteLine($"{character1}");
                Thread.Sleep(1000);
                // Console.Clear();
            }
        } while (character1.isAlive() && character2.isAlive());
        if (character1.isAlive())
        {
            Console.WriteLine($"{character1.Name} won !");
        }
        else
        {
            Console.WriteLine($"{character2.Name} won !");
        }
    }
}