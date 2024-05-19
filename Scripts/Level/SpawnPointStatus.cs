using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointStatus : MonoBehaviour
{
    private bool _isSpawnPointOccupied = false;
    public bool GetSpawnPointStatus()
    {
        return _isSpawnPointOccupied;
    }
    public void SetSpawnPointStatus(bool value)
    {
        _isSpawnPointOccupied=value;
    }
    private void Update()
    {
    }
    private void OnEnable()
    {
        ResetSpawnPointsEveryTurn.ResetSpawnPoints += ResetSpawnPoint;
    }
    private void OnDisable()
    {
        ResetSpawnPointsEveryTurn.ResetSpawnPoints -= ResetSpawnPoint;

    }
    void ResetSpawnPoint()
    {
        _isSpawnPointOccupied = false;
    }
}
