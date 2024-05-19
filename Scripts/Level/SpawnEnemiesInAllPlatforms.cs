using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesInAllPlatforms : MonoBehaviour
{
    [SerializeField] GameObject[] _platforms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnAllEnemiesInAllPlatforms()
    {
        foreach(GameObject platform in _platforms)
        {
            platform.GetComponent<PlatformEnemySpawner>().CreateARandomNumberOfEnemies();
        }
    }
}
