using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    /// VARIABLES 

    //added to player vector3 to always be -10units away
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    //how fast/slow the camera repositions to the player
    public float smoothTime = 0.25f;

    //
    Vector3 camVel = Vector3.zero;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // 
        Vector3 targetPosition = player.transform.position + offset;

        //Sets the cameras movement using SmoothDamp to smoothly move it over.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camVel, smoothTime);

    }


}
