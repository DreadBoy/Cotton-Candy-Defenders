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
		doors[0].addLevel(new Monster[]{new Monster(Monster.Type.Spider)});
		doors[0].addLevel(new Monster[]{new Monster(Monster.Type.Spider), new Monster(Monster.Type.Spider), new Monster(Monster.Type.Spider)});
        ready = true;
    }

	public struct DoorSpawnByLevel{
		public readonly List<Monster> monsters;

		public DoorSpawnByLevel (Monster[] monsters)
		{
			this.monsters = new List<Monster>(monsters);
		}
	}

    public class DoorSpawn
    {
        public Vector3 position = Vector3.zero;
		public List<DoorSpawnByLevel> levels;
        public String name = "";

        public DoorSpawn(Vector3 position, String name)
        {
            this.position = position;
            this.name = name;
			levels = new List<DoorSpawnByLevel>();
        }

		public void addLevel(Monster[] monsters){
			levels.Add(new DoorSpawnByLevel(monsters));
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
