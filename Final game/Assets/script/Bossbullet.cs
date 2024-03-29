﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.health();
        }
        Destroy(gameObject);
    }
}
