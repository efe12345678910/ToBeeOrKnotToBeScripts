using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class RaisePointModForCutOnly
{
    public static event Action RaisePointModForCut;
    public static void OnRaisePointModForCut()
    {
        if (RaisePointModForCut != null)
        {
            RaisePointModForCut.Invoke();
        }
    }
}
