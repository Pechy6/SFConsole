namespace ConsoleSF;

public class Warrior : Character
{
    int Shield { get; set; }
    int Posture { get; set; }

    public Warrior(string name, int health, int attackDamage, int defense
    ) : base(name, health, attackDamage, defense)
    {
        // sem vlozim vnitrni logiku 
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
                base.Defend(damage, false);
                Console.WriteLine($"Message about defend:\n{Name} block all damage by shield!");
            }
            else
            {
                base.Defend(damage, false);
            }
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"{Name} cant cover from mage special attack and take {damage} damage!");
        }

    }
}