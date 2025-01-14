// See https://aka.ms/new-console-template for more information

using ConsoleSF;

Console.WriteLine("Hello, World!");
Character warrior = new Character("Warrior", 100, 20, 30);
Character mage = new Character("Mage", 100, 50, 10);
Console.WriteLine(warrior);
Console.WriteLine(mage);
Console.WriteLine();
warrior.Attack(mage);
mage.Attack(warrior);
Console.WriteLine(mage);
Console.WriteLine(warrior);
warrior.Attack(mage);
mage.Attack(warrior);
Console.WriteLine(mage);
Console.WriteLine(warrior);
warrior.Attack(mage);
mage.Attack(warrior);
Console.WriteLine(mage);
Console.WriteLine(warrior);