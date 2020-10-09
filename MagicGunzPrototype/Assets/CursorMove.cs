using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
    // rigid body associated with cursor
    public Rigidbody2D rbCursor;

    // rigid body associated with player
    public Rigidbody2D rbPlayer;

    // relative distance between player and old position of player over one frame
    private Vector2 dRel;

    // mouse delta
    private Vector2 mdelta;

    // mouse sensitivity factor
    public float sens;

    // old position of player
    private Vector2 playerPosOld;

    // current position of player;
    private Vector2 playerPosNew;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the old position of the player in world coordinates
        playerPosOld = rbPlayer.position;

        // initialize the relative position of the player to themselves over one frame in world coordinates
        dRel = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // get the new position of the player in world coordinates
        playerPosNew = rbPlayer.position;

        // check to see if the player is moving
        if(!playerPosNew.Equals(playerPosOld))
        {
            // if player is moving get position of player relative to old position and update the relative cursor distance
            dRel = playerPosNew - playerPosOld;

            // update the curent position of the cursor in world coordinates
            rbCursor.position = rbCursor.position + dRel;
        }

        // get mouse delta
        mdelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        // check to see if mouse is moving
        if(mdelta.magnitude > 0)
        {
            rbCursor.position = rbCursor.position + (mdelta * sens);
        }

        // update the old position of the player
        playerPosOld = playerPosNew;
    }

}
