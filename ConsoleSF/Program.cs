// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// pridani trid Warrior*, Mage*, Archer* a Assasin
// priradit ridici tridu souboje at mame program.cs hezky cisty

using System.Threading.Channels;
using ConsoleSF;

// inicializace 
MessageManager sharedMessageManager = new MessageManager();
Character warr = new Warrior("warr", 100, 20, 30, sharedMessageManager);
Character archer = new Archer("Archer", 100, 25, 10, sharedMessageManager);
Character mage = new Mage("Mage", 100, 35, 5, 100, 100, sharedMessageManager);

// explicitni pretipovani 
Mage mageClass = (Mage)mage;

// hra 
Console.WriteLine("Hello, Arena\n\n\n");
while (archer.isAlive() && warr.isAlive())
{
    // archer.Attack(mage);
    warr.Attack(mage);
    Console.WriteLine(mage.HealthBar() + "\n");
    mage.Attack(warr);
    Console.WriteLine(warr.HealthBar() + "\n");
    // Console.WriteLine((mageClass.ManaBar()) + "\n");
}

Console.WriteLine("\n");
Console.WriteLine(archer);
Console.WriteLine(archer.HealthBar() + "\n");
Console.WriteLine(archer._messageManager.PrintRecordedMessages() + "\n");
Console.WriteLine(warr);
Console.WriteLine(warr.HealthBar() + "\n");
// Console.WriteLine(mageClass.ManaBar() + "\n");
Console.WriteLine(warr._messageManager.PrintRecordedMessages() + "\n");
Console.WriteLine("\n\n\n");