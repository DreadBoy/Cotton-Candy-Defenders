using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class LevelStats : MonoBehaviour {

    public DoorSpawn[] doors;
    public Boolean ready = false;

    void Start()
    {
        //find all doors and assign spawn points to them
        doors = GameObject.FindGameObjectsWithTag("Door").Select<GameObject, DoorSpawn>(g => new DoorSpawn(g.transform.position, "Vrata")).ToArray<DoorSpawn>();
        doors[0].monsters.Add(new Monster(Monster.Type.Spider));
        doors[0].monsters.Add(new Monster(Monster.Type.Spider));
        doors[0].monsters.Add(new Monster(Monster.Type.Spider));
        ready = true;
    }

    public class DoorSpawn
    {
        public Vector3 position = Vector3.zero;
        public List<Monster> monsters;
        public String name = "";

        public DoorSpawn(Vector3 position, String name)
        {
            this.position = position;
            this.name = name;
            monsters = new List<Monster>();
        }
    }

    public class Monster{
        public enum Type{
            Spider,
            Knight,
            Mage
        }
        public Type type;

        public Monster(Type t)
        {
            type = t;
        }
    }
}
