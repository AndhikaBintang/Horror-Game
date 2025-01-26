using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints
    [SerializeField]
    private bool alwaysDrawPath = true; // Always show the path
    [SerializeField]
    private bool drawAsLoop = false; // Connect the last point to the first
    [SerializeField]
    private bool drawNumbers = true; // Option to display waypoint numbers
    public Color debugColour = Color.white; // Path line color
    public float waypointRadius = 0.2f; // Radius for waypoint spheres

    private void OnDrawGizmos()
    {
        if (alwaysDrawPath)
        {
            DrawPath();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!alwaysDrawPath)
        {
            DrawPath();
        }
    }

    private void DrawPath()
    {
        if (waypoints == null || waypoints.Count < 2) return;

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i] == null) continue;

            // Draw a sphere for each waypoint
            Gizmos.color = debugColour;
            Gizmos.DrawWireSphere(waypoints[i].position, waypointRadius);

            // Draw lines between waypoints
            if (i > 0)
            {
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
            }

            // If drawAsLoop is enabled, connect the last waypoint to the first
            if (drawAsLoop && i == waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            }
        }
    }
}
