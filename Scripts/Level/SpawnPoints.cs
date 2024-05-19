using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //boş nokta arıyor spawn pointlerde yoksa NULL dönüyor buna dikkat
    public GameObject FindClosestSpawnPoint()
    {
        foreach(GameObject gameObject in _spawnPoints)
        {        
            if (!gameObject.GetComponent<SpawnPointStatus>().GetSpawnPointStatus())
            {
                return gameObject;
            }
            
        }
        return null;
    }
    public void ResetAllSpawnPointsStatus()
    {
        foreach (GameObject spawnpoint in _spawnPoints)
        {
            spawnpoint.GetComponent<SpawnPointStatus>().SetSpawnPointStatus(false);
        }
    }
}
