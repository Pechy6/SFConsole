namespace ConsoleSF;

public class EnemyClass
{
    private int enemyChoice;

    /// <summary>
    /// Provides a mechanism for the user to select an enemy character from a predefined list of options.
    /// The user can choose from Warrior, Mage, or Archer. Returns the selected enemy character.
    /// </summary>
    /// <returns>A Character object representing the chosen enemy.</returns>
    public Character ChooseYourEnemy()
    {
        Character enemy = null;
        do
        {
            Console.WriteLine("Choose your enemy (wisely)\n");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Archer");
            while (!int.TryParse(Console.ReadLine(), out enemyChoice))
                Console.WriteLine("Wrong input! Please try again. (1-3)");
            if (enemyChoice == 1)
            {
                enemy = new Warrior("Ork Dementator", 125, 20, 30, new MessageManager());
                Console.WriteLine(enemy);
            }

            else if (enemyChoice == 2)
            {
                enemy = new Mage("Dark Mage", 80, 40, 5, 80, 100, new MessageManager());
                Console.WriteLine(enemy);
            }

            else if (enemyChoice == 3)
            {
                enemy = new Archer("Dark Elf", 100, 30, 10, new MessageManager());
                Console.WriteLine(enemy);
            }
            else
            {
                Console.WriteLine("Wrong input! Please try again. (1-3)\n");
            }
        } while (enemyChoice < 1 || enemyChoice > 3);

        return enemy;
    }

    /// <summary>
    /// Generates and returns a random enemy character of type Warrior, Mage, or Archer,
    /// each with predefined attributes. The selected enemy type is displayed to the console.
    /// </summary>
    /// <returns>A Character object representing the generated enemy.</returns>
    public Character GetEnemyCharacter()
    {
        Character enemy;
        int randomEnemyType = RandomGenerator.GetRandomEnemy();
        
        if (randomEnemyType == 0)
        {
            enemy = new Warrior("Ork Dementator", 125, 20, 30, new MessageManager());
            Console.WriteLine($"Name: {enemy.Name}\nClass: {enemy.ClassName}\n");
        }

        else if (randomEnemyType == 1)
        {
            enemy = new Mage("Dark Mage", 80, 40, 5, 80, 100, new MessageManager());
            Console.WriteLine($"Name: {enemy.Name}\nClass: {enemy.ClassName}\n");
        }

        else 
        {
            enemy = new Archer("Dark Elf", 100, 30, 10, new MessageManager());
            Console.WriteLine($"Name: {enemy.Name}\nClass: {enemy.ClassName}\n");
        }

        return enemy;
    }
}