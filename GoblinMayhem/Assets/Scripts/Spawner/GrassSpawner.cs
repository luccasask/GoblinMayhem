using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassSpawner : MonoBehaviour
{
    public Tilemap grassTilemap;
    public Tilemap grassTuftTilemap;
    public TileBase grassTile;
    public TileBase grassTuftTile;
    void Start()
    {
        SpawnGrassTufts();
    }

    void SpawnGrassTufts()
    {
        foreach (var cell in grassTilemap.cellBounds.allPositionsWithin)
        {

            if (grassTilemap.GetTile(cell) == grassTile && Random.value < .33f)
            {
                // 1/3 of grass tiles will receive grass tuft on top
                grassTuftTilemap.SetTile(cell, grassTuftTile);
                print("Print grass tuft");
            }
        }
    }
}
