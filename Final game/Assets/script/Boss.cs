using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public PlayerScript player;
    public GameController control;

    private int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }
    public void hit()
    {
        health -= 1;

        if (health == 0)
        {
            Destroy(gameObject);
            player.win();
            control.win();
        }
    }
}
