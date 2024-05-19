using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointResetAll : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetAllSpawnPointsInAllPlatforms()
    {
        foreach(GameObject platform in _platforms)
        {
            platform.GetComponent<SpawnPoints>().ResetAllSpawnPointsStatus();
            
        }
    }
}
