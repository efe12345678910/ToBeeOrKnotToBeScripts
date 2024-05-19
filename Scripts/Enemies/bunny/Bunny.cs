using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Enemy
{
    private void Awake()
    {
        points = 70;
    }
    private void OnDestroy()
    {
        if (!RoundManager.Instance.GetIsGameOver())
        {
            VFXManager.Instance.CreateExplosionVFX(0, transform.position);

        }

    }
}
