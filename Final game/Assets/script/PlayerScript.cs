using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    //public Transform Bossspawn;
    //public GameObject Boss;
    public float speed;
    public Text score;
    public Text life;
    GameController sounds;

    private int scoreValue = 0;

    public int lifeValue = 3;

    public Text winText;

    private bool facingRight = true;

    public AudioSource musicSource;
    public AudioClip catnoise;
    public AudioClip jump;
    Animator Anim;
    private int MoveHorizontal;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Cats Saved: " + scoreValue.ToString();
        life.text = "Life: " + lifeValue.ToString();
        winText.text = "";
        Anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Anim.SetInteger("state", 1);
            MoveHorizontal = 1;
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Anim.SetInteger("state", 1);
            MoveHorizontal = -1;  
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Anim.SetInteger("state", 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetInteger("state", 0);
        }

        if (facingRight == false && MoveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && MoveHorizontal < 0)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "foes")
        {
            Destroy(collision.collider.gameObject);
        }


        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Cats Saved: " + scoreValue.ToString();
            musicSource.clip = catnoise;
            musicSource.Play();
            Destroy(collision.collider.gameObject);

            if (scoreValue == 4)
            {
                transform.position = new Vector2(51.0f, 1.0f);
                lifeValue = 3;
                life.text = "Life: " + lifeValue.ToString();
            }

            if (scoreValue == 8)
            {
                transform.position = new Vector2(103.0f, -1.0f);
                lifeValue = 3;
                life.text = "Life: " + lifeValue.ToString();

            }
        }

        if (collision.collider.tag == "enemy")
        {
            lifeValue -= 1;
            life.text = "Life: " + lifeValue.ToString();
            Destroy(collision.collider.gameObject);

            if (lifeValue == 0)
            {
                winText.text = "The Dogs have defeated you! Game created by Wyatt Amorin";
                gameObject.SetActive(false);
            }
        }

        if (collision.collider.tag == "Ground")
        {
            Anim.SetInteger("state", 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                Anim.SetInteger("state", 2);
                musicSource.clip = jump;
                musicSource.Play();
            }
        }

        if (collision.collider.tag == "death")
        {
            transform.position = new Vector2(51.0f, 1.0f);
            lifeValue -= 1;
            life.text = "Life: " + lifeValue.ToString();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.Rotate(0f, 180f, 0f);
    }

        public void health()
    {
        lifeValue -= 1;
        life.text = "Life: " + lifeValue.ToString();

        if (lifeValue == 0)
        {
            winText.text = "The Dogs have defeated you! Game created by Wyatt Amorin";
            gameObject.SetActive(false);
        }
    }

    public void win()
    {
        winText.text = "You saved all the cats! Game created by Wyatt Amorin";
        speed = 0;
    }
}
