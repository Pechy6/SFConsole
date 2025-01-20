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

        // specialni utok kteremu se nelze vyhnout a ignoruje kompletni ochranu 
        HandleDamageCalculation(isMageSpecialAttack, doubleProtection, incomingDamage, damageTaken, defense);
    }

    /// <summary>
    /// Handles the calculation of damage during a character defense event. It considers special attack behavior,
    /// double protection status, incoming damage, damage taken, and character defense to determine the final outcome of the attack.
    /// Updates the character's health and processes final hit logic if necessary.
    /// </summary>
    /// <param name="isMageSpecialAttack">Indicates whether the incoming attack is a mage's special attack that cannot be defended against.</param>
    /// <param name="doubleProtection">Indicates whether the character has double protection enabled for the defense.</param>
    /// <param name="incomingDamage">The total damage coming from the attacker before any defense calculations.</param>
    /// <param name="damageTaken">The calculated damage to be taken by the character after accounting for defense.</param>
    /// <param name="defense">The defense rating of the character, including any random posture modifiers, used to mitigate incoming damage.</param>
    protected void HandleDamageCalculation(bool isMageSpecialAttack, bool doubleProtection, int incomingDamage,
        int damageTaken, int defense)
    {
        if (isMageSpecialAttack)
        {
            SpecialAttack(incomingDamage);
            return;
        }
        
        if (!doubleProtection)
        {
            return;
        }

        if (damageTaken <= 0)
        {
            Console.WriteLine($"Message about defend:\n{Name} block the attack!");
            return;
        }

        Console.WriteLine(
            $"Message about defend:\n{Name} defending against {incomingDamage} damage but cover {defense} damage and taking {damageTaken} damage!");

        if (!isAlive())
        {
            return;
        }

        Health -= damageTaken;
        LastHit();
    }

    /// <summary>
    /// Updates the character's health to zero if it has dropped to or below zero,
    /// and outputs a message indicating that the character has died.
    /// </summary>
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

    /// <summary>
    /// Calculates and returns the normalized attack damage based on the character's attack damage,
    /// potentially applying a critical attack bonus if a random condition is met.
    /// </summary>
    /// <returns>The normalized attack damage value.</returns>
    protected int NormalizeAttack()
    {
        int damage = AttackDamage;
        // pokud je cislo vyssi nez nula tak se vyvola kriticky attack s pridanym bonusem
        if (RandomGenerator.GetFiftyFifty() > 0)
            damage += AttackDamage / 2;
        return damage;
    }

    /// <summary>
    /// Executes a special attack that ignores all defenses and directly reduces the character's health.
    /// </summary>
    /// <param name="incomingDamage">The amount of damage inflicted that cannot be blocked or mitigated.</param>
    protected void SpecialAttack(int incomingDamage)
    {
        Health -= incomingDamage;
            Console.WriteLine($"This kind of damage cant be blocked by {Name} and take {incomingDamage} damage!");
    }
    
    public override string ToString()
    {
        return string.Format("{0} - {1} HP, {2} Strength, {3} Defense", Name, Health, Attack, Defense);
    }
}