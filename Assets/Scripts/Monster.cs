public class Monster
{
    public enum Type
    {
        Elephant,
        Panda,
        Snake
    }
    public Type type;

    public Monster(Type t)
    {
        type = t;
    }
}