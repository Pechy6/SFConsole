using System.Threading.Channels;

namespace ConsoleSF;

// Vyresit problem s pristupem charakteru do boje 
public class Arena()
{
    private Character MyCharacter { get; set; }
    private Character Enemy { get; set; }
    readonly CharacterSelector _characterSelector = new();
    private readonly EnemyClass _enemyClass = new();

    /// <summary>
    /// Manages the main gameplay loop and user interaction for the arena combat system.
    /// Displays the main menu with options to start a game or end the application.
    /// Responsible for initializing the character setup, enemy setup,
    /// and executing the combat sequence.
    /// After completing a session, allows the user to choose whether to play again
    /// or exit the application.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Welcome to Arena!");
        Console.WriteLine("Press Enter to continue...");
        PressEnter();
        Console.Clear();

        bool playAgain = true;

        do
        {
            bool validChoice = false;

            // Hlavní menu
            do
            {
                Console.WriteLine("1. Start game");
                Console.WriteLine("2. End game");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wrong choice, please try again.");
                    continue; // Znovu na začátek menu
                }

                switch (choice)
                {
                    case 1:
                        validChoice = true;

                        // Nastav hlavní postavu
                        GetYourCharacter();

                        // Nastav nepřítele
                        GetEnemy();

                        // Boj
                        Fight(MyCharacter, Enemy);
                        Console.WriteLine("Press Enter to continue...");
                        PressEnter();
                        Console.Clear();

                        // Nabídka "Play Again"
                        bool playAgainMenu = true;
                        while (playAgainMenu)
                        {
                            Console.WriteLine("1. New game");
                            Console.WriteLine("2. Write the previous fight");
                            Console.WriteLine("3. Exit game");

                            int playAgainChoice;
                            if (!int.TryParse(Console.ReadLine(), out playAgainChoice))
                            {
                                Console.WriteLine("Wrong input! Please try again. (1-3)");
                                continue; // Znovu zobraz menu
                            }

                            switch (playAgainChoice)
                            {
                                case 1: // Nová hra
                                    MyCharacter = null;
                                    Enemy = null;
                                    playAgainMenu = false; // Opuštění menu
                                    break;

                                case 2: // Výpis předchozího boje
                                    Console.Clear();
                                    Console.WriteLine("Your messages:");
                                    Console.WriteLine(MyCharacter?._messageManager.PrintRecordedMessages() ??
                                                      "No messages recorded.");
                                    Console.WriteLine();
                                    Console.WriteLine("Enemy messages:");
                                    Console.WriteLine(Enemy?._messageManager.PrintRecordedMessages() ??
                                                      "No messages recorded.");
                                    break; // Zobraz menu znovu

                                case 3: // Konec hry
                                    Console.WriteLine("Exiting the game...");
                                    playAgain = false;
                                    playAgainMenu = false; // Zastav play again menu
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice. Please try again.");
                                    break; // Špatný výběr - znovu do menu
                            }
                        }

                        break;

                    case 2: // Konec hry
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        validChoice = true;
                        playAgain = false; // Ukonči hlavní cyklus
                        break;

                    default:
                        Console.WriteLine("Wrong choice. Please try again.");
                        break; // Špatná volba - znovu na začátek
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
        Console.WriteLine("The enemy is set\nContinue with pressing enter");
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

    /// <summary>
    /// Executes a combat sequence between two characters.
    /// Allows users to observe a turn-based battle between the two participants,
    /// where each character takes turns attacking the other until one is defeated.
    /// The winner is determined when one of the characters' health points reaches zero.
    /// The sequence includes setting up the turn order based on a random roll and displaying the battle progress.
    /// </summary>
    /// <param name="character1">The first character involved in the combat, representing one participant in the fight.</param>
    /// <param name="character2">The second character involved in the combat, representing the opponent in the fight.</param>
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
                Thread.Sleep(1500);
                Console.Clear();
            }

            if (character2.isAlive())
            {
                character2.Attack(character1);
                Console.WriteLine($"{character1}");
                Thread.Sleep(1500);
                Console.Clear();
            }
        } while (character1.isAlive() && character2.isAlive());

        Console.WriteLine(character1.isAlive() ? $"{character1.Name} won !" : $"{character2.Name} won !");
    }
}