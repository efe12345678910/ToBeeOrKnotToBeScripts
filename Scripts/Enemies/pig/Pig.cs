using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Enemy
{
    private void Awake()
    {
        points = 20; 
    }
    private void OnDestroy()
    {
        if (!RoundManager.Instance.GetIsGameOver())
        {
            VFXManager.Instance.CreateExplosionVFX(0, transform.position);

        }
    }
}
