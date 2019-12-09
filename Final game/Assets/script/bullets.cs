using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Foes foe = hitInfo.GetComponent<Foes>();
        if (foe != null)
        {
            foe.Destroy();
        }

        Boss boss = hitInfo.GetComponent<Boss>();
        if (boss != null)
        {
            boss.hit();
        }

        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if  (player !=null)
        {
            player.health();
        }
        Destroy(gameObject);
    }

}
