namespace ConsoleSF;

public class Warrior(string name, int health, int attackDamage, int defense, MessageManager messageManager)
    : Character(name, health, attackDamage, defense, messageManager)
{
    public override string ClassName { get; protected set; } = "Warrior";

    public override void Defend(int damage, bool isMageSpecialAttack, bool protectionFromDoubleAttack)
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
            _messageManager.PrintMessageAndAddToList($"Message about defend:\n{Name} block all damage by shield!\n");
            // Console.WriteLine($"Message about defend:\n{Name} block all damage by shield!");
        }
        else
        {
            base.Defend(damage, false, true);
        }
    }

    public override string ToString()
    {
        return string.Format(
            $"Character description:\nClass name: Warrior\nName: {Name}\nHealth: {MaxHealth}\nAttack damage: {AttackDamage}\nDefense: {Defense}\nDescription: Warrior have shield and can block attack with it. Dosen't work for special attacks.\n");
    }
}