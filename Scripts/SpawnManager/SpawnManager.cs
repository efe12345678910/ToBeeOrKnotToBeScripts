using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnList = new List<GameObject>();
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<SpawnManager>();
                if (_instance == null)
                {
                    _instance= new GameObject("SpawnManager").AddComponent<SpawnManager>();
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance != null && _instance!=this)
        {
            Destroy(gameObject);
        }
    }
    public GameObject GetARandomEnemyFromList()
    {

        int index = Random.Range(0, _spawnList.Count-1);
        return _spawnList[index];

    }
    private void Update()
    {
    }
    private void Start()
    {
        
    }
}
