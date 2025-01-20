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

    public override void Defend(int damage, bool isMageSpecialAttack, bool doubleProtection)
    {
        if (isMageSpecialAttack)
        {
            SpecialAttack(damage);
            return;
        }

        if (RandomGenerator.GetResetAttackAndBlockAttack() == 1 && damage > 0)
        {
            damage = 0;
            base.Defend(damage, false, false);
            Console.WriteLine($"Message about defend:\n{Name} block all damage by shield!");
            return;
        }
        else
        {
            base.Defend(damage, false, true);
        }
    }
}