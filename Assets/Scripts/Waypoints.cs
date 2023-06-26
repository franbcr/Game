using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;


    private void Awake()
    {
        InitializeLevelWaypointsArray();
    }

    private void InitializeLevelWaypointsArray()
    {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    private int GetAmountOfLevelWaypoints()
    {
        return waypoints.Length;
    }

    private void ArrayIterateForward()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
        }
    }

    private void ArrayIterateBackwards()
    {
        for (int i = waypoints.Length - 1; i >= 0; i--)
        {
        }
    }
}
