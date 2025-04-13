using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth = 10; // Width of the map
    public int mapHeight = 10; // Height of the map
    public float tileSize = 1.732f; // Size of each tile
    public GameObject tilePrefab; // Prefab for the hex tile
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createMap();
    }
    

    private Vector2 getHexOffset(int x, int z)
    {
        var zOffset = z * tileSize + ((x % 2 == 1) ? tileSize * 0.5f : 0); // Vertical offset for hex tiles
        
        return new Vector2(0, zOffset);
    }
    void createMap()
    {
        var first = 6;
        var second = 6;

        for (var x = 0; x < 6; x++) 
        {
            for (var z = 0; z < first; z++)
            {
                var offset = getHexOffset(x, z);
                
                var pos = new Vector3(x * 1.5f, 0, offset.y - (Mathf.Ceil((x+1)/2)*tileSize));
                var tile = Instantiate(tilePrefab, pos, Quaternion.Euler(new Vector3(90,0,90)));
            }
            first++;
        }
        
        for (var x = 10; x > 5; x--) 
        {
            for (var z = 0; z < second; z++)
            {
                var offset = getHexOffset(x, z);
                
                var pos = new Vector3(x * 1.5f, 0, offset.y + (Mathf.Ceil(x/2)*tileSize) - (5*tileSize));
                var tile = Instantiate(tilePrefab, pos, Quaternion.Euler(new Vector3(90,0,90)));
            }
            second++;
        }
    }
}
