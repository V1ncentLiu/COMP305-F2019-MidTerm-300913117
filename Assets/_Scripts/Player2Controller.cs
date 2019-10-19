using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Player2Controller : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        Move2();
        BoundaryCheck();
    }

    public void Move2()
    {
        Vector2 newPos = transform.position;
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPos += new Vector2(0.0f, speed.max);
        }
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPos += new Vector2(0.0f, speed.min);
        }
    }
    public void BoundaryCheck()
    {
        // check Top boundary
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
        // check Bottom boundary
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Cloud":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }
}
