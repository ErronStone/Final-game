using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public AudioSource Source;
    public AudioClip gamemusic;
    public AudioClip winmusic;

    // Start is called before the first frame update
    void Start()
    {
        Source.clip = gamemusic;
        Source.Play();
    }

    public void win()
    {
        Source.clip = winmusic;
        Source.Play();
    }
}
