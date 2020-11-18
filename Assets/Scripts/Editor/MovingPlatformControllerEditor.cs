using UnityEngine;
using UnityEditor; //access to editor stuff

[CustomEditor(typeof(MovingPlatformController))] //accociate this script with MovingPlatformController script
public class MovingPlatformControllerEditor : Editor //inherits Editor class
{
    public override void OnInspectorGUI() //the things drawn in the inspector box
    {
        MovingPlatformController controller = (MovingPlatformController)target; //the target is the instance of the MovingPlatformController script

        // Draw some stuff in the editor
        // Waypoint prefab 
        controller.waypointPrefab = (GameObject)EditorGUILayout.ObjectField("Waypoint Object", controller.waypointPrefab, typeof(GameObject), false); //drag in the waypoint prefab to copy

        // Speed value
        controller.moveSpeed = EditorGUILayout.FloatField("Speed: ", controller.moveSpeed); //shows the speed value, and you can change it
        
        // Label for waypoints
        EditorGUILayout.LabelField("Waypoints", EditorStyles.boldLabel);

        //if there are waypoints, add them 
        if (controller.waypoints != null && controller.waypoints.Count != 0) //it matters to check null before the count. 
        {
            for (int i = 0; i < controller.waypoints.Count; i++) //loop through waypoints
            {
                // Create horizontal groupings for each waypoint
                EditorGUILayout.BeginHorizontal();

                // Get the name of the game object for the label
                controller.waypoints[i].gameObject.name = EditorGUILayout.TextField(controller.waypoints[i].gameObject.name);

                controller.waypoints[i].position = EditorGUILayout.Vector2Field("", controller.waypoints[i].position);

                // Add a button to delete waypoint
                if (GUILayout.Button("Delete?")) //if you click on the button, perform action
                {
                    // Remove a specific waypoint (call controller for this)
                    controller.RemoveWaypoint(i);
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        // Button to add waypoint
        if (GUILayout.Button("Add Waypoint")) //if you click on the button, perform action
        {
            // Add new waypoint to the waypoints list (tell the controller to add the waypoint)
            controller.AddNewWaypoint();
        }

        // Button to clear waypoints
        if (GUILayout.Button("Clear Waypoints"))
        {
            controller.ClearWaypoints(); //clears the list of waypoints
        }
    }
}
