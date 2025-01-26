namespace ConsoleSF;

public static class CharacterDescription
{
    private static readonly Dictionary<string, string> descriptions = new()
    {
        {
            "Warrior",
            "Have strong armor and shield. His fighting posture added him bonus for attack and deffend. And so on he have shield with which can block attack. But dosen't work for special attacks."
        },
        {
            "Mage",
            "Have mana for his special attacks. Mage have light armor and his posture gave him attack and deffend bonus. Also when he have full mana he use his special attack and if he is lucky his mana reset to full."
        },
        {
            "Archer",
            "He is really good with his dexterity. When he is under attack can avoid it. But he can't block special attacks. Archer have light armor and his posture dosen't work for him."
        }
    };

    public static string GetCharacterDescription(string characterClassName)
    {
        if (string.IsNullOrEmpty(characterClassName))
        {
                throw new ArgumentNullException(nameof(characterClassName), "Character class name can't be null");
        }

        return descriptions.GetValueOrDefault(characterClassName, "Unknown character");
    }

    public static void ClassesDescription()
    {
        foreach (var playerClass in descriptions)
        {
            Console.WriteLine($"{playerClass.Key}:\n{playerClass.Value}\n");
        }
    }
}