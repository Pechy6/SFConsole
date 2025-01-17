// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// pridani trid Warrior*, Mage*, Archer a Assasin
// archer ma moznost vyhnuti pokud je to fyzicky utok a zaroven ignoruje obranu postoje 
// mozna opravit pokud se magovi dostane stesti na 100% manu tak by to melo byt napsano az po utoku 
// priradit ridici tridu souboje at mame program.cs hezky cisty

using System.Threading.Channels;
using ConsoleSF;
// inicializace 
MessageManager sharedMessageManager = new MessageManager();
Character warrior = new Warrior("Warrior", 100, 20, 30);
Character mage = new Mage("Mage", 100, 25, 10, 50, 50);

// explicitni pretipovani 
Mage mageClass = (Mage)mage;

// hra 
Console.WriteLine("Hello, Arena\n\n\n");
while (warrior.isAlive() && mage.isAlive())
{
    mage.Attack(warrior);
    Console.WriteLine(warrior.HealthBar() + "\n");
    // warrior.Attack(mage);
    Console.WriteLine(mage.HealthBar() + "\n");
    Console.WriteLine((mageClass.ManaBar()) + "\n");
}

Console.WriteLine("\n");
Console.WriteLine(warrior);
Console.WriteLine(warrior.HealthBar() + "\n");
Console.WriteLine(mage);
Console.WriteLine(mage.HealthBar() + "\n");
Console.WriteLine("\n\n\n");
