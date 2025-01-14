namespace ConsoleSF;

public class Character
{
    /// <summary>
    /// Gets or sets the name of the character.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the health of the character.
    /// Represents the character's current hit points or life.
    /// </summary>
    int Health { get; set; }

    /// <summary>
    /// Gets or sets the strength attribute of the character, representing their physical power.
    /// </summary>
    int Strength { get; set; }

    /// <summary>
    /// Gets or sets the defense value of the character.
    /// Represents the character's ability to reduce damage taken from attacks.
    /// </summary>
    int Defense { get; set; }

    private string zprava = "";

    public Character(string name, int health, int strength, int defense)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Defense = defense;
    }

    /// <summary>
    /// Performs an attack on a target character, calculates damage based on attacker strength
    /// and random factors, and applies the damage to the target.
    /// </summary>
    /// <param name="target">The target character to attack.</param>
    public void Attack(Character target)
    {
        int damage = Strength;
        string kritZprava = "udelil zasah";
        if (RandomGenerator.GetFiftyFifty() > 0)
        {
            damage *= 2;
            kritZprava = "udelil kriticky zasah";
        }

        damage += RandomGenerator.GetRandomPosture();
        target.Defend(damage);
        zprava += $"Utocici {Name} {kritZprava} za {damage}dmg oponentovi {target.Name}\n";
    }

    /// <summary>
    /// Defends against an incoming attack by calculating total defense using the character's defense
    /// attribute and random factors, reduces the incoming damage, and adjusts health accordingly.
    /// </summary>
    /// <param name="damage">The amount of damage inflicted by the attacker.</param>
    private void Defend(int damage)
    {
        int defense = Defense + RandomGenerator.GetRandomPosture();
        int damageTaken = damage - defense;
        if (damageTaken > 0)
        {
            Health -= damageTaken;
            zprava += $"{Name} byl pod utok v hodnote {damage}dmg ale po castecnem vykriti utoku obrdrzel pouze {damageTaken}, a zbylo mu {Health}HP\n";
        }
        else
        {
            zprava += $"Oponent {Name} neprobil obranu!\n";
        }
    }

    public bool isAlive()
    {
        return Health > 0;
    }

    public string GetZprava()
    {
        return zprava;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1} HP, {2} Strength, {3} Defense\n", Name, Health, Strength, Defense);
    }
}