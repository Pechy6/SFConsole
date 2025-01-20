namespace ConsoleSF;

public class Archer : Character
{
    public Archer(string name, int health, int attackDamage, int defense, MessageManager messageManager) : base(name, health, 
        attackDamage, 
        defense,
        messageManager)
    {
    }

    public override void Attack(Character target)
    {
        int damage = NormalizeAttack();
        Console.WriteLine($"{Name} attacking for {damage} damage!");
        target.Defend(damage, false, true);
    }

    public override void Defend(int damage, bool isMageSpecialAttack, bool doubleProtection)
    {
        int damageTaken = damage - Defense;
        if (RandomGenerator.GetFiftyFifty() == 0 || isMageSpecialAttack)
        {
            HandleDamageCalculation(isMageSpecialAttack, doubleProtection, damage, damageTaken, Defense);
        }
        else
        {
            damageTaken = 0;
            Console.WriteLine($"{Name} avoid attack so his health is not affected");
        }
    }
}