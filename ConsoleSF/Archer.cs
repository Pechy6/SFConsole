namespace ConsoleSF;

public class Archer(string name, int health, int attackDamage, int defense, MessageManager messageManager)
    : Character(name, health,
        attackDamage,
        defense,
        messageManager)
{
    public override string ClassName { get; protected set; } = "Archer";

    public override void Attack(Character target)
    {
        int damage = BasicAttack();
        _messageManager.PrintMessageAndAddToList(
            $"Message about attack:\n{Name} attacking {target.Name} for {damage} damage!\n");
        // Console.WriteLine($"{Name} attacking for {damage} damage!");
        target.Defend(damage, false, true);
    }

    public override void Defend(int damage, bool isMageSpecialAttack, bool protectionFromDoubleAttack)
    {
        int incomingDamage = damage;
        int damageTaken = damage - Defense;
        if (RandomGenerator.GetFiftyFifty() == 0 || isMageSpecialAttack)
        {
            HandleDamageCalculation(isMageSpecialAttack, protectionFromDoubleAttack, damage, damageTaken, Defense);
        }
        else
        {
            damageTaken = 0;
            _messageManager.PrintMessageAndAddToList(
                $"Message about defend:\n{Name} defending against {incomingDamage} damage but avoid attack so his health is not affected");
            // Console.WriteLine($"{Name} avoid attack so his health is not affected");
        }
    }

    public override string ToString()
    {
        return string.Format(
            $"Character description:\nClass name: Archer\nName: {Name}\nHealth: {MaxHealth}\nAttack damage: {AttackDamage}\nDefense: {Defense}\nDescription: Archer can avoid attacks but can't block special attacks. And for his deffense he cant use good posture. He is archer not Warrior!\n");
    }
}