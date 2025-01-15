// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// pridani trid Warrior, Mage, Archer a Assasin
// opravit text aby mel spravne poradi 
// priradit ridici tridu souboje at mame program.cs hezky cisty

// poupravit utok aby se prohodil s obranou pri volani, jelikoz mi to prvne vyvola zpravu z obrany. 


using System.Threading.Channels;
using ConsoleSF;
// inicializace 
MessageManager sharedMessageManager = new MessageManager();
Character warrior = new Character("Warrior", 100, 20, 30, sharedMessageManager);
Character mage = new Character("Mage", 100, 35, 10, sharedMessageManager);

// hra 
Console.WriteLine("Hello, Arena\n\n\n");
while (warrior.isAlive() && mage.isAlive())
{
    mage.Attack(warrior);
    Console.WriteLine(warrior.HealthBar() + "\n");
    warrior.Attack(mage);
    Console.WriteLine(mage.HealthBar() + "\n");
    Console.WriteLine(!warrior.isAlive()
        ? $"{mage.Name} win againts {warrior.Name}!"
        : $"{warrior.Name} win againts {mage.Name}!");
}

Console.WriteLine("\n");
Console.WriteLine(warrior);
Console.WriteLine(warrior.HealthBar() + "\n");
Console.WriteLine(mage);
Console.WriteLine(mage.HealthBar() + "\n");
Console.WriteLine("\n\n\n");
Console.Write(warrior._messageManager.PrintRecordedMessages());
