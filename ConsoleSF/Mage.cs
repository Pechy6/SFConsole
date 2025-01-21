namespace ConsoleSF;

public class Mage : Character
{
    
    /// <summary>
    /// Represents the current mana level of the Mage.
    /// Mana is consumed or regenerated based on the Mage's actions,
    /// such as performing special attacks or other mana-related abilities.
    /// </summary>
    /// <value>
    /// An integer representing the Mage's current mana level.
    /// Values range between 0 and MaxMana, inclusive.
    /// </value>
    int Mana { get; set; }

    /// <summary>
    /// Represents the maximum mana capacity of the Mage.
    /// This value determines the upper limit of mana the Mage can hold at any time,
    /// influencing abilities and the triggering of special attacks.
    /// </summary>
    /// <value>
    /// An integer representing the Mage's maximum mana.
    /// This value is fixed upon initialization and is used to constrain the Mana property.
    /// </value>
    int MaxMana { get; set; }
    bool luckyShot = false;

    public Mage(string name, int health, int attackDamage, int defense, int mana, int maxMana, MessageManager messageManager)
        : base(name, health, attackDamage, defense, messageManager)
    {
        Mana = mana;
        MaxMana = maxMana;
    }

    /// <summary>
    /// Performs an attack on a target character. Increases mana with each attack, and when the mage's mana
    /// reaches or exceeds its maximum value, a special attack is triggered. The special attack
    /// deals a higher damage amount based on the mage's attack damage.
    /// </summary>
    /// <param name="target">The target character to attack.</param>
    public override void Attack(Character target)
    {
        string message = "";
        if (Mana >= MaxMana)
        {
            int specialAttack = AttackDamage * 2;
            Mana = 0;
            if (RandomGenerator.GetFiftyFifty() > 0)
            {
                specialAttack += AttackDamage / 3;
                if (RandomGenerator.GetResetAttackAndBlockAttack() == 1)
                {
                    luckyShot = true;
                    Mana = MaxMana;
                }
                else
                    Mana = 0;
            }

            message = $"Message about attack:\n{Name} attacking with special attack for {specialAttack}";
            if (luckyShot)
                message += "Lucky shot! My mana was reset !";
            _messageManager.PrintMessageAndAddToList(message + "\n");
            // Console.WriteLine($"Message about attack:\n{Name} attacking with special attack for {specialAttack}");
            target.Defend(specialAttack, true, true);
        }
        else
        {
            base.Attack(target);
            Mana += 10;
        }
    }

    /// <summary>
    /// Generates a graphical representation of the mage's current mana as a progress bar.
    /// Each segment of the bar represents a portion of the mage's maximum mana.
    /// </summary>
    /// <returns>A string displaying the mana bar with filled segments proportional to the mage's current mana.</returns>
    public string ManaBar()
    {
        string bar = $"{Name}: Mana [";
        int countOfBar = 5;
        if (Mana > 0)
        {
            double countOfPices = Math.Round((Mana / (double)MaxMana) * countOfBar);
            for (int i = 0; i < countOfPices; i++)
            {
                bar += "#";
            }
        }

        bar += "]";
        return bar;
    }
}