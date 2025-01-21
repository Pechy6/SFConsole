namespace ConsoleSF;

public class Warrior : Character
{
    public Warrior(string name, int health, int attackDamage, int defense, MessageManager messageManager
    ) : base(name, health, attackDamage, defense, messageManager)
    {
    }
    
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
}