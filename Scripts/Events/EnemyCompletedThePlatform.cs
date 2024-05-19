using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyCompletedThePlatform
{
    public static event Action<GameObject,int> EnemyCompletedPlatform;
    public static void OnEnemyCompletedPlatform(GameObject enemy, int platformCompleted)
    {
        if(EnemyCompletedPlatform != null)
        {
            EnemyCompletedPlatform.Invoke(enemy, platformCompleted);
        }
    }
}
