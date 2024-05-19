using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    private void Awake()
    {
        points = 40;
    }
    private void OnDestroy()
    {
        if (!RoundManager.Instance.GetIsGameOver())
        {
            VFXManager.Instance.CreateExplosionVFX(0, transform.position);

        }
    }
}
