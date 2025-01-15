namespace ConsoleSF;

public class Mage : Character
{
    MessageManager _messageManager;
    int Mana { get; set; }
    int MaxMana { get; set; }

    public Mage(string name, int health, int attackDamage, int defense, MessageManager messageManager, int mana,
        int maxMana)
        : base(name, health, attackDamage, defense, messageManager)
    {
        Mana = mana;
        MaxMana = maxMana;
    }

    public override void Attack(Character target)
    {
        Mana += 10;
        if (Mana >= MaxMana)
        {
            int specialAttack = AttackDamage * 2;
            if (RandomGenerator.GetFiftyFifty() > 0)
            {
                specialAttack += AttackDamage / 3;
                if (RandomGenerator.GetResetAttack() == 0)
                {
                    Console.WriteLine($"{Name} special attack was really powerful! {Name} has full mana!");
                    Mana = MaxMana;
                }
            }
            Console.WriteLine($"{Name} attacking with special attack for {specialAttack}");
            Mana = 0;
            target.Defend(specialAttack);
        }
        base.Attack(target);
    }

    public string ManaBar()
    {
        string bar = $"{Name}: Mana [";
        int countOfBar = 5;
        if (Mana > 0)
        {
            double countOfPices = Math.Round((Mana / (double)MaxMana) * countOfBar);
            for (int i = 0; i < countOfPices; i++)
            {
                bar += "#";
            }
        }
        bar += "]";
        return bar;
    }
}