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
        int damageTaken = damage - Defense;
        if (RandomGenerator.GetFiftyFifty() == 0)
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