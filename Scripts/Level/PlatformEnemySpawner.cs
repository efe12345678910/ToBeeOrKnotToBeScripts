using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject _spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateAnEnemy()
    {
        GameObject spawnPoint= _spawnPoints.GetComponent<SpawnPoints>().FindClosestSpawnPoint();
        Instantiate(SpawnManager.Instance.GetARandomEnemyFromList(), spawnPoint.transform.position, Quaternion.identity);
        spawnPoint.GetComponent<SpawnPointStatus>().SetSpawnPointStatus(true);
    }
    public void CreateARandomNumberOfEnemies()
    {
        int a = Random.Range(1, 4);
        for(int i = 0; i < a; i++)
        {
            CreateAnEnemy();
        }
    }
}
