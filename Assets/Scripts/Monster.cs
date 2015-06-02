using System;
using System.Collections.Generic;
using System.Linq;

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