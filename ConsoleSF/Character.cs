namespace ConsoleSF;

public class Character
{
    
    // MessageManager messageManager = new MessageManager();
    
    string zprava = "";
    
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
    /// Gets or sets the Maximum health
    /// </summary>
    int MaxHealth { get; set; }

    /// <summary>
    /// Gets or sets the strength attribute of the character, representing their physical power.
    /// </summary>
    int Strength { get; set; }

    /// <summary>
    /// Gets or sets the defense value of the character.
    /// Represents the character's ability to reduce damage taken from attacks.
    /// </summary>
    int Defense { get; set; }
    
    public Character(string name, int health, int strength, int defense)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
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
        if (RandomGenerator.GetFiftyFifty() > 0)
        {
            damage *= 2;
        }

        damage += RandomGenerator.GetRandomPosture();
        target.Defend(damage);
        zprava = $"{Name} attacking {target.Name} for {damage} damage!";
        MessageManager.PrintMessageAndAddToList(zprava);
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
        if (damageTaken <= 0)
        {
            damageTaken = 0;
        }
        
        zprava = $"{Name} defending against {damageTaken} damage!";
        if (damageTaken > 0)
        {
            if (isAlive())
            {
            zprava += $" and taking {damageTaken} damage!";
                Health -= damageTaken;
                if (Health < 0)
                {
                    Health = 0;
                    zprava += $" But that was too much for {Name} and he is already dead!";
                }
            }
            MessageManager.PrintMessageAndAddToList(zprava);
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
        string bar = "[";
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
            bar = "[DEAD]";
        }

        return bar;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1} HP, {2} Strength, {3} Defense", Name, Health, Strength, Defense);
    }
}