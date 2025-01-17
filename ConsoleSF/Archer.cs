namespace ConsoleSF;

public class Archer : Character
{
    // bude se umet vyhnout obycejnym utokum
    // postoj priceteny k obrane na nej nefunguje ale zaroven ignoruje i u oponenta postoj 
    // vyresit proc se mi hp pricitaji a tim padem je boj nekonecny 

    public Archer(string name, int health, int attackDamage, int defense) : base(name, health, attackDamage, defense)
    {
        // sem vlozim vnitrni logiku
    }

    public override void Attack(Character target)
    {
        int damage = NormalizeAttack();
        Console.WriteLine($"{Name} attacking for {damage} damage!");
        target.Defend(damage, false, true);
    }

    public override void Defend(int damage, bool isMageSpecialAttack, bool doubleProtection)
    {
        if (isAlive())
        {
            int incomingDamage = damage;
            int damageTaken = Defense - incomingDamage;
            Health -= damageTaken;
            LastHit();
            Console.WriteLine($"{Name} getting hit for {incomingDamage} damage and take {damageTaken} damage!");
        }
    }
}