namespace ConsoleSF;

public class EnemyClass
{
    Character Enemy { get; set; }
    private int enemyChoice;
    
    public Character ChooseYourEnemy(Character enemy)
    {
        Enemy = enemy;
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

    public Character GetEnemyCharacter(Character enemy)
    {
        Enemy = enemy;
        if (RandomGenerator.GetRandomEnemy() == 0)
        {
            enemy = new Warrior("Ork Dementator", 125, 20, 30, new MessageManager());
            Console.WriteLine(enemy);
        }

        if (RandomGenerator.GetRandomEnemy() == 1)
        {
            enemy = new Mage("Dark Mage", 80, 40, 5, 80, 100, new MessageManager());
            Console.WriteLine(enemy);
        }

        if (RandomGenerator.GetRandomEnemy() == 2)
        {
            enemy = new Archer("Dark Elf", 100, 30, 10, new MessageManager());
            Console.WriteLine(enemy);
            
        }
        return enemy;
    }
}