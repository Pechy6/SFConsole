namespace ConsoleSF;

public static class MessageManager
{
    private static List<string> messages = new List<string>();

    /// <summary>
    /// Prints all recorded messages stored in the internal message list to the console.
    /// Each message is displayed on a new line in the order they were recorded.
    /// </summary>
    public static void PrintRecordedMessages()
    {
        foreach (string message in messages)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Prints the specified message to the console and adds it to the internal message list.
    /// </summary>
    /// <param name="currentMessage">The message to be printed and added to the list.</param>
    public static void PrintMessageAndAddToList(string currentMessage)
    {
        messages.Add(currentMessage);
        Console.WriteLine(currentMessage);
    }
}