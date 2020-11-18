using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    // Will move the platform from a starting position to a waypoint. There may be multiple waypoints.
    public GameObject waypointPrefab; //what to instatiate for the waypoint
    public float moveSpeed = 5f;
    public List<Transform> waypoints; //a list of waypoints

    private int currentTargetIndex = 0; //keep track of the current waypoint index

    // Start is called before the first frame update
    private void Awake()
    {
        waypoints = new List<Transform>(); //new list
        //add already created waypoints incase they weren't deleted before
        foreach (Transform t in transform.parent.GetChild(1)) //GetChild(1) = Waypoints empty object
        {
            waypoints.Add(t); //add the waypoint to the list
        }

        if (waypoints.Count > 0) //if there are any prexisting waypoints
            transform.position = waypoints[0].position; //put the platform on the first position
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 1) //if there is at least one waypoint start moving
        {
            // Move the object
            // Going to manipulate the transform instead of using rigidbody.
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed); //current position, current waypoint, speed

            if (Vector2.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.01f) //if the platform gets very close to the target, true
            {
                // Change the target to the next
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count; //will loop through the list over and over!
            }
        }
    }

    public void AddNewWaypoint()
    {
        // Editor will call this
        // Create a new waypoint from the prefab
        GameObject newWaypoint = Instantiate(waypointPrefab, Vector2.zero, Quaternion.identity);
        newWaypoint.transform.SetParent(transform.parent.GetChild(1)); //transform.parent.GetChild(1) = the Waypoints empty on the hierarchy
        newWaypoint.name = "Waypoint " + waypoints.Count; //name the new object
        waypoints.Add(newWaypoint.transform);
    }

    public void RemoveWaypoint(int index)
    {
        // Editor will call this
        // Remove a waypoint from the list
        waypoints.RemoveAt(index);
        //waypoints.TrimExcess(); //recount the amount of things in list
        DestroyImmediate(transform.parent.GetChild(1).GetChild(index).gameObject);
    }

    public void ClearWaypoints()
    {
        // Delete the waypoint game objects
        for (int i = 0; i < waypoints.Count; i++)
        {
            DestroyImmediate(waypoints[i].gameObject);
        }

        waypoints.Clear(); //clears the list of waypoints
    }
}