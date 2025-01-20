// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// pridani trid Warrior*, Mage*, Archer* a Assasin
// priradit ridici tridu souboje at mame program.cs hezky cisty

using System.Threading.Channels;
using ConsoleSF;
// inicializace 
MessageManager sharedMessageManager = new MessageManager();
Character archer = new Archer("Archer", 100, 20, 30, sharedMessageManager);
Character mage = new Mage("Mage", 100, 25, 10, 50, 50, sharedMessageManager);

// explicitni pretipovani 
Mage mageClass = (Mage)mage;

// hra 
Console.WriteLine("Hello, Arena\n\n\n");
while (archer.isAlive() && mage.isAlive())
{
    // archer.Attack(mage);
    mage.Attack(archer);
    Console.WriteLine(archer.HealthBar() + "\n");
    archer.Attack(mage);
    Console.WriteLine(mage.HealthBar() + "\n");
    Console.WriteLine((mageClass.ManaBar()) + "\n");
}

Console.WriteLine("\n");
Console.WriteLine(archer);
Console.WriteLine(archer.HealthBar() + "\n");
Console.WriteLine(mage);
Console.WriteLine(mage.HealthBar() + "\n");
Console.WriteLine("\n\n\n");
