namespace ConsoleSF;

public static class RandomGenerator
{
    static Random random = new Random();
    
    public static int GetFiftyFifty()
    {
        return random.Next(0, 2);
    }

    public static int GetRandomPosture()
    {
        return random.Next(0, 11);
    }
}