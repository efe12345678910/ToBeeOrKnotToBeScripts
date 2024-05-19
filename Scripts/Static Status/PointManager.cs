using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointManager
{
    private static int _currentPoints;
    public static int GetCurrentPoints()
    {
        return _currentPoints;
    }
    public static void AddToCurrentPoints(int value)
    {
        _currentPoints += value;
    }
    public static void ResetPointsToZero()
    {
        _currentPoints = 0;
    }
}
