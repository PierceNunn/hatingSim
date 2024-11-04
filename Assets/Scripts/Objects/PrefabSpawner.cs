using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjectsToSpawn;
    [SerializeField] private bool _spawnOnAwake = true;
    // Start is called before the first frame update
    void Awake()
    {
        if(_spawnOnAwake)
        {
            SpawnGameObjects();
        }
        
    }
    public void SpawnGameObjects()
    {
        foreach (GameObject g in _gameObjectsToSpawn)
        {
            Instantiate(g, transform.position, Quaternion.identity);
        }
    }
}
