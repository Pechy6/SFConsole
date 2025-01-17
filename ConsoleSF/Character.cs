namespace ConsoleSF;

public class Character(string name, int health, int attackDamage, int defense)
{
    // public readonly MessageManager _messageManager = messageManager;
    // string zprava = "";

    /// <summary>
    /// Gets or sets the name of the character.
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// Gets or sets the health of the character.
    /// Represents the character's current hit points or life.
    /// </summary>
    protected int Health { get; set; } = health;

    /// <summary>
    /// Gets or sets the Maximum health
    /// </summary>
    protected int MaxHealth { get; set; } = health;

    /// <summary>
    /// Gets or sets the strength attribute of the character, representing their physical power.
    /// </summary>
    protected int AttackDamage { get; set; } = attackDamage;

    /// <summary>
    /// Gets or sets the defense value of the character.
    /// Represents the character's ability to reduce damage taken from attacks.
    /// </summary>
    protected int Defense { get; set; } = defense;

    /// <summary>
    /// Performs an attack on a target character, calculates damage based on attacker strength
    /// and random factors, and applies the damage to the target.
    /// </summary>
    /// <param name="target">The target character to attack.</param>
    public virtual void Attack(Character target)
    {
        int damage = NormalizeAttack();
        damage += RandomGenerator.GetRandomPosture();
        Console.WriteLine($"Message about attack\n{Name} attacking {target.Name} for {damage} damage!");
        target.Defend(damage, false, true);
    }

    /// <summary>
    /// Defends against an incoming attack by calculating total defense using the character's defense
    /// attribute and random factors, reduces the incoming damage, and adjusts health accordingly.
    /// </summary>
    /// <param name="damage">The amount of damage inflicted by the attacker.</param>
    public virtual void Defend(int damage, bool isMageSpecialAttack, bool doubleProtection)
    {
        int incomingDamage = damage;
        int defense = Defense + RandomGenerator.GetRandomPosture();
        int damageTaken = damage - defense;

        if (!doubleProtection)
        {
            return; // Pokud není aktivní dvojitá ochrana, logiku přeskočíme
        }

        if (damageTaken <= 0)
        {
            Console.WriteLine($"Message about defend:\n{Name} block the attack!");
            return;
        }

        Console.WriteLine(
            $"Message about defend:\n{Name} defending against {incomingDamage} damage but cover {defense} damage");

        if (!isAlive())
        {
            return; // Pokud postava není naživu, ostatní logiku přeskočíme
        }

        Console.Write($"and taking {damageTaken} damage!");

        Health -= damageTaken;
        LastHit();
       
    }

    protected void LastHit()
    {
        if (Health <= 0)
        {
            Health = 0;
            Console.WriteLine($" But that was too much for {Name} and he is already dead!");
        }
    }
    /// <summary>
    /// Determines whether the character is alive based on its current health.
    /// </summary>
    /// <returns>True if the character's health is greater than zero; otherwise, false.</returns>
    public bool isAlive()
    {
        return Health > 0;
    }

    /// <summary>
    /// Generates a visual representation of the character's current health as a health bar.
    /// The health bar shows "#" to indicate remaining health and "[DEAD]" if the character has no health.
    /// </summary>
    /// <returns>A string representing the character's health bar, including the visual health status or a "[DEAD]" message if the character is not alive.</returns>
    public string HealthBar()
    {
        string bar = $"{Name}: Health [";
        int countOfBar = 20;
        if (isAlive())
        {
            double countOfPices = Math.Round((Health / (double)MaxHealth) * countOfBar);
            for (int i = 0; i < countOfPices; i++)
            {
                bar += "#";
            }

            bar += "]";
        }
        else
        {
            bar = $"{Name}: [DEAD]";
        }

        return bar;
    }

    protected int NormalizeAttack()
    {
        int damage = AttackDamage;
        // pokud je cislo vyssi nez nula tak se vyvola kriticky attack s pridanym bonusem
        if (RandomGenerator.GetFiftyFifty() > 0)
            damage += AttackDamage / 2;
        return damage;
    }
    
    public override string ToString()
    {
        return string.Format("{0} - {1} HP, {2} Strength, {3} Defense", Name, Health, Attack, Defense);
    }
}