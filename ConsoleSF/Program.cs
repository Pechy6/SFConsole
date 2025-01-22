// See https://aka.ms/new-console-template for more information

// Implementace zpravy pres novou tridu a list
// pridani trid Warrior*, Mage*, Archer* a Assasin
// priradit ridici tridu souboje at mame program.cs hezky cisty

using System.Threading.Channels;
using ConsoleSF;

// inicializace 
Character archer = new Archer("Adam", 100, 10, 10, new MessageManager());
Character Mage = new Mage("Mage", 80, 10, 10, 80, 100, new MessageManager());
CharacterSelector myCharacter = new CharacterSelector();
Character me = myCharacter.ChooseYourCharacter();
Console.WriteLine("\n\n" + archer + "\n" + Mage + "\n" + me);
