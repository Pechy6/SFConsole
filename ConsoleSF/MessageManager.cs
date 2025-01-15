using System.Text;

namespace ConsoleSF;

public class MessageManager
{
    private List<string> messages = new List<string>();

    /// <summary>
    /// Prints all recorded messages stored in the internal message list to the console.
    /// Each message is displayed on a new line in the order they were recorded.
    /// </summary>
    public string PrintRecordedMessages()
    {
        var stringBuilder = new StringBuilder();
        foreach (string message in messages)
        {
            stringBuilder.AppendLine(message);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Prints the specified message to the console and adds it to the internal message list.
    /// </summary>
    /// <param name="currentMessage">The message to be printed and added to the list.</param>
    public void PrintMessageAndAddToList(string currentMessage)
    {
        messages.Add(currentMessage);
        Console.WriteLine(currentMessage);
    }
}