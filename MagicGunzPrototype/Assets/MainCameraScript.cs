using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public int movespeed = 5;
    public int diffdistance = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get player position in game world
        Vector3 p_pos = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Compute the measured distance between camera and player using x,y position
        Vector3 difference = p_pos - transform.position;
        float measdistance = Mathf.Sqrt((difference.x * difference.x) + (difference.y * difference.y));

        // Check to see if camera is too far away from player and move towards player if this is the case
        if (measdistance > diffdistance)
        {
            // Normalize difference to get direction towards player
            Vector3 dir = Vector3.Normalize(difference);
            // Translate in direction towards player
            transform.Translate(movespeed * Time.deltaTime * new Vector3(dir.x,dir.y,0));
        }
        
    }
}
