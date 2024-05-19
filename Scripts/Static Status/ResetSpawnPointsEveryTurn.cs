using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResetSpawnPointsEveryTurn
{
    public static event Action ResetSpawnPoints;
    public static void OnResetSpawnPoints()
    {
        if(ResetSpawnPoints != null) ResetSpawnPoints();
    }
}
