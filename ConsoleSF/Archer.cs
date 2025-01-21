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
        int damage = BasicAttack();
        _messageManager.PrintMessageAndAddToList($"Message about attack:\n{Name} attacking {target.Name} for {damage} damage!\n");
        // Console.WriteLine($"{Name} attacking for {damage} damage!");
        target.Defend(damage, false, true);
    }

    public override void Defend(int damage, bool isMageSpecialAttack, bool protectionFromDoubleAttack)
    {
        int incomingDamage = damage;
        int damageTaken = damage - Defense;
        if (RandomGenerator.GetFiftyFifty() == 0 || isMageSpecialAttack)
        {
            HandleDamageCalculation(isMageSpecialAttack, protectionFromDoubleAttack, damage, damageTaken, Defense);
        }
        else
        {
            damageTaken = 0;
            _messageManager.PrintMessageAndAddToList($"Message about defend:\n{Name} defending against {incomingDamage} damage but avoid attack so his health is not affected");
            // Console.WriteLine($"{Name} avoid attack so his health is not affected");
        }
    }
}