using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in _gameObjectsToSpawn)
        {
            Instantiate(g, transform.position, Quaternion.identity);
        }
    }
}
