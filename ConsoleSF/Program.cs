// See https://aka.ms/new-console-template for more information

// Uvodni nabidka = 1. zvolte si tridu, 2. Description trid, 3. Nahodny souboj 
// priradit ridici tridu souboje at mame program.cs hezky cisty

using System.Threading.Channels;
using ConsoleSF;

// inicializace 
CharacterDescription characterDescription = new();

Character archer = new Archer("Adam", 100, 10, 10, new MessageManager());
Character mage = new Mage("Mage", 80, 10, 10, 80, 100, new MessageManager());
Character warrior = new Warrior("Warrior", 125, 10, 10, new MessageManager());
Console.WriteLine(characterDescription.GetCharacterDescription(mage.GetClassName()));
// Console.WriteLine(characterDescription.GetCharacterDescription(archer.GetClassName()));
// Console.WriteLine(characterDescription.GetCharacterDescription(warrior.GetClassName()));
// CharacterSelector myCharacter = new CharacterSelector();
// Character me = myCharacter.ChooseYourCharacter();
// Console.WriteLine("\n\n" + archer + "\n" + Mage + "\n" + me);
