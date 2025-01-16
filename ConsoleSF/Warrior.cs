namespace ConsoleSF;

public class Warrior: Character
{
    int Shield {get; set;}
    int Posture {get; set;}

    public Warrior(string name, int health, int attackDamage, int defense, MessageManager messageManager, int shield,
        int posture) : base(name, health, attackDamage, defense, messageManager)
    {
        Shield = shield;
        Posture = posture;
    }

    public override void Defend(int damage, bool isMageSpecialAttack)
    {
        // if isnt special attack from mage 
        if (!isMageSpecialAttack)
        {
            // chance to block all damage by shield
            if (RandomGenerator.GetResetAttackAndBlockAttack() == 1)
            {
                damage = 0;
                Console.WriteLine($"{Name} block all damage by shield!");
            }
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"{Name} cant cover from mage special attack and take {damage} damage!");
        }
    }
}