// See https://aka.ms/new-console-template for more information

// Implementace zpravy
// kontrola funkcnosti utoku 
// pridani zivota a smrti 
// pridani trid Warrior, Mage, Archer a Assasin


using ConsoleSF;

Console.WriteLine("Hello, World!");
Character warrior = new Character("Warrior", 100, 20, 30);
Character mage = new Character("Mage", 100, 50, 10);
warrior.Attack(mage);
Console.WriteLine(warrior);
Console.WriteLine(warrior.GetZprava());
Console.WriteLine(mage);
Console.WriteLine(mage.GetZprava());
mage.Attack(warrior);
Console.WriteLine(mage);
Console.WriteLine(mage.GetZprava());
Console.WriteLine(warrior);
Console.WriteLine(warrior.GetZprava());