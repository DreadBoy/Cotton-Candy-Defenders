using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreateLevel : MonoBehaviour
{


    [SerializeField]
    public TextAsset Level;

    // Use this for initialization
    void Start()
    {
        String[] lines = Level.text.Split('\n').ToArray().Select(s => s.Trim()).ToArray();
        Int32 mapIndex = Array.FindIndex(lines, l => l.Contains("---------------MAP---------------"));
        Int32 pathIndex = Array.FindIndex(lines, l => l.Contains("---------------PATHS---------------"));
        String[][] mapTemp = lines.Skip(mapIndex + 1).Take(pathIndex - mapIndex - 1).Select(l => l.Split(' ').ToArray()).ToArray();
        String[,] map = new String[mapTemp[0].Length, mapTemp.Length];
        for (int j = 0; j < mapTemp.Length; j++)
            for (int r = 0; r < mapTemp[j].Length; r++)
                map[r, j] = mapTemp[j][r];

        var material = Resources.Load<Material>("TileMaterial");

        for (int x = 0; x < map.GetLength(0); x++)
            for (int y = 0; y < map.GetLength(1); y++)
            {
                var texture = Resources.Load<Texture2D>("Landscape/" + map[x, y]);
                GameObject tile = new GameObject(map[x, y] + "_dyn");
                SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
                renderer.sortingOrder = x + y;
                renderer.material = material;
                tile.transform.position = new Vector2((x - y) * 0.64f, (y + x) * -0.32f);
            }

    
    }
}

