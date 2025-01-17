namespace ConsoleSF;

public class Archer: Character
{
    // bude se umet vyhnout obycejnym utokum
    // postoj priceteny k obrane na nej nefunguje ale zaroven ignoruje i u oponenta postoj 
    
    public Archer(string name, int health, int attackDamage, int defense) : base(name, health, attackDamage, defense)
    {
        // sem vlozim vnitrni logiku
    }

    public override void Attack(Character target)
    {
        int damage = NormalizeAttack();
        target.Defend(damage, false, true);
    }

    public override void Defend(int damage, bool isMageSpecialAttack, bool doubleProtection)
    {
        base.Defend(damage, isMageSpecialAttack, doubleProtection);
    }
}