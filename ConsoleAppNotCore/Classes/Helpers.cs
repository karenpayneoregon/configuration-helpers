namespace ConsoleAppNotCore.Classes
{
    public class Helpers
    {
        public static T GetObject<T>() where T : new() => new T();
    }
}