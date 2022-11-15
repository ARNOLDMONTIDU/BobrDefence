using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _mapTile;
    private  List<GameObject> _mapTiles = new List<GameObject>();

    [SerializeField] private int _mapHeight;
    [SerializeField] private int _mapWidth;


    private void Start()
    {
        SpawnMap();
    }

    public void SpawnMap()
    {
        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                GameObject newTile = Instantiate(_mapTile);

                _mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x, y);
            }
        }
    }
    
}
