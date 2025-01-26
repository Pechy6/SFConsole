namespace ConsoleSF;

public class Arena()
{
    Character myCharacter;
    Character Enemy { get; set; }
    private int enemyChoice;
    CharacterSelector characterSelector = new CharacterSelector();

    public void Start()
    {
        Console.WriteLine("Welcome to the game ConsoleSF\nPress enter to start");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            Console.WriteLine("\"Invalid key! Please press Enter to continue...\"\n");
        }

        Console.WriteLine("Classes to choose:\n");
        CharacterDescription.ClassesDescription();
        characterSelector.ChooseYourCharacter(myCharacter);
    }

    public Character ChooseYourEnemy(Character enemy)
    {
        Enemy = enemy;
        do
        {
            Console.WriteLine("Choose your enemy (wisely)\n");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Archer");
            while (int.TryParse(Console.ReadLine(), out enemyChoice))
                Console.WriteLine("Wrong input! Please try again. (1-3)");
            if (enemyChoice == 1)
            {
                enemy = new Warrior("Ork Dementator", 125, 20, 30, new MessageManager());
            }

            if (enemyChoice == 2)
            {
                enemy = new Mage("Dark Mage", 80, 40, 5, 80, 100, new MessageManager());
            }

            if (enemyChoice == 3)
            {
                enemy = new Archer("Dark Elf", 100, 30, 10, new MessageManager());
            }
        } while (enemyChoice < 1 || enemyChoice > 3);

        return enemy;
    }

    public Character GetEnemyCharacter(Character enemy)
    {
        Enemy = enemy;
        if (RandomGenerator.GetRandomEnemy() == 0)
        {
            enemy = new Warrior("Ork Dementator", 125, 20, 30, new MessageManager());
            return enemy;
        }

        if (RandomGenerator.GetRandomEnemy() == 1)
        {
            enemy = new Mage("Dark Mage", 80, 40, 5, 80, 100, new MessageManager());
            return enemy;
        }

        if (RandomGenerator.GetRandomEnemy() == 2)
        {
            enemy = new Archer("Dark Elf", 100, 30, 10, new MessageManager());
            return enemy;
        }
    }
}