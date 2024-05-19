using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IsThereAMenuActive
{
    private static bool _isThereAMenuActive = false;
    public static bool GetIsThereAMenuActive()
    {
        return _isThereAMenuActive;
    }
    public static void SetIsThereAMenuActive(bool value)
    {
        _isThereAMenuActive = value;
    }
}
