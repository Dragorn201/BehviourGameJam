using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public float tileSize = 1.732f; // Size of each tile

    [Header("Tile Prefabs")] public GameObject grassPrefab;
    public GameObject woodPrefab;
    public GameObject coalPrefab;
    public GameObject waxPrefab;
    public GameObject batteryPrefab;

    [Header("Tile Counts")] public int grassCount = 62;
    public int woodCount = 12;
    public int coalCount = 9;
    public int waxCount = 5;
    public int batteryCount = 3;

    private Transform _tileParent;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tileParent = new GameObject("Tile Parent").transform;
        _tileParent.SetParent(this.transform);
        
        GenerateMap();

    }

    void GenerateMap()
    {
        var tilePositions = CreateTilePositions();
        var tilesList = CreateTilesList();
        ShuffleTilesList(tilesList);
        
        for (var i = 0; i < tilePositions.Count; i++)
        {
            var tile = Instantiate(tilesList[i], tilePositions[i], Quaternion.Euler(new Vector3(90, 0, 90)));

            if (_tileParent != null)
            {
                tile.transform.SetParent(_tileParent);
            }
        }
    }

    // Connecting the tiles in the hexagonal grid

    private Vector2 GetHexOffset(int x, int z)
    {
        var zOffset = z * tileSize + ((x % 2 == 1) ? tileSize * 0.5f : 0); // Vertical offset for hex tiles

        return new Vector2(0, zOffset);
    }

    // List of tile positions so I can use them when randomizing the map

    List<Vector3> CreateTilePositions()
    {
        var tilePositions = new List<Vector3>();

        for (var x = 0; x < 11; x++)
        {
            var numRows = 11 - Mathf.Abs(x - 5);

            for (var z = 0; z < numRows; z++)
            {
                var offset = GetHexOffset(x, z);

                var zOffset = (x < 6)
                    ? offset.y - (Mathf.Ceil((x + 1) / 2) * tileSize)
                    : offset.y + (Mathf.Ceil((x) / 2) * tileSize) - (5 * tileSize);

                tilePositions.Add(new Vector3(x * 1.5f, 0, zOffset));
            }
        }
        return tilePositions;
    }

    // Store the tile prefabs in a list

    List<GameObject> CreateTilesList()
    {
        var tilesList = new List<GameObject>();
        
        AddTilesToList(tilesList, grassPrefab, grassCount);
        AddTilesToList(tilesList, woodPrefab, woodCount);
        AddTilesToList(tilesList, coalPrefab, coalCount);
        AddTilesToList(tilesList, waxPrefab, waxCount);
        AddTilesToList(tilesList, batteryPrefab, batteryCount);
        
        return tilesList;
    }

    // Helper function to add tile prefabs to the list

    private static void AddTilesToList(List<GameObject> tilesList, GameObject tilePrefab, int prefabCount)
    {
        for (var i = 0; i < prefabCount; i++)
        {
            tilesList.Add(tilePrefab);
        }
    }

    // Shuffling the list of tile prefabs

    void ShuffleTilesList(List<GameObject> tilesList) 
    {
        var rng = new System.Random();
        
        var n = tilesList.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (tilesList[k], tilesList[n]) = (tilesList[n], tilesList[k]);
        }
    }

    // Instantiating tiles in the scene
    void PlaceTiles(List<Vector3> positions, List<GameObject> tilesList)
    {
        for (var i = 0; i < 91; i++)
        {
            var prefab = tilesList[i];
            var position = positions[i];
            
            var tile = Instantiate(prefab, position, Quaternion.Euler(new Vector3(90, 0, 90)));

            if (_tileParent != null)
            {
                tile.transform.SetParent(_tileParent);
            }
        }
    }
}
    
    