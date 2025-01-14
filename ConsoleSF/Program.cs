// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// kontrola funkcnosti utoku *
// pridani zivota a smrti 
// pridani trid Warrior, Mage, Archer a Assasin


using System.Threading.Channels;
using ConsoleSF;

Console.WriteLine("Hello, Arena");
Character warrior = new Character("Warrior", 100, 20, 30);
Character mage = new Character("Mage", 100, 50, 10);
while (warrior.isAlive())
{
    mage.Attack(warrior);
    Console.WriteLine(warrior.HealthBar());
}
Console.WriteLine("\n\n\n");
MessageManager.PrintRecordedMessages();
