using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour {

    bool started;
    int[,] grid;
    public int width;
    public int height;


    void Start()
    {
        grid = new int[width, height];
        Generate();
        started = true;
    }

    void Generate () {
        
    }

    void OnDrawGizmos() {
        if (started)
        {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y] != 0)
                    {
                        Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one);
                    }
                }
            }
        }
    }
}


/*public class Generator : MonoBehaviour {

    List<Vector2> open = new List<Vector2>();
    List<Vector2> closed = new List<Vector2>();
    public int width;
    public int height;
    public int maxRooms;
    [Range(0, 1)]
    public float spawnChance;
    int room;
    bool started;

    void Start()
    {
        started = true;
        closed.Add(new Vector2(width / 2, height / 2));
        open.Add(new Vector2(width / 2 - 1,height / 2));
        open.Add(new Vector2(width / 2 + 1, height / 2));
        open.Add(new Vector2(width / 2, height / 2 - 1));
        open.Add(new Vector2(width / 2, height / 2 + 1));
        Generate();
    }

    void Generate () {
        List<Vector2> newOpen = new List<Vector2>(open);
        foreach (var item in open)
        {
            newOpen.Remove(item);
            closed.Add(item);
            if (!closed.Contains(item - new Vector2(-1, 0)) && Random.value < spawnChance) {
                newOpen.Add(item + new Vector2(-1,0));
            }
            if (!closed.Contains(item - new Vector2(1, 0)) && Random.value < spawnChance)
            {
                newOpen.Add(item + new Vector2(1, 0));
            }
            if (!closed.Contains(item - new Vector2(0, -1)) && Random.value < spawnChance)
            {
                newOpen.Add(item + new Vector2(0, -1));
            }
            if (!closed.Contains(item - new Vector2(0, 1)) && Random.value < spawnChance)
            {
                newOpen.Add(item + new Vector2(0, 1));
            }
        }
        open = newOpen;
        room++;
        if (open.Count() > 0 && room < maxRooms) {
            Generate();
        }
    }

    void OnDrawGizmos() {
        if (started)
        {
            foreach (var item in closed)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(new Vector3(item.x, item.y, 0), Vector3.one);
            }
            foreach (var item in open)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawCube(new Vector3(item.x, item.y, 0), Vector3.one);
            }
        }
    }
}*/
