﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{

    //private bool facingRight = false;
   // private int MoveHorizontal;
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers and pingpong the movement.
        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

        /*if (facingRight == false)
        {
            Flip();
        }
        else if (facingRight == true)
        {
            Flip();
        }*/

    }

    /*private void FixedUpdate()
    {
        if (facingRight == false)
        {
            Flip();
        }
        else if (facingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.Rotate(0f, 180f, 0f);
    }*/
}