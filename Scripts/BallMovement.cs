using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float maxVerticalSpeed;

    private MasterScript masterScript;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        masterScript = GameObject.Find("Canvas").GetComponent<MasterScript>();
    }

    // Use this for initialization
    void Start()
    {

        if (Settings.difficulty == Difficulty.normal)
        {
            speed *= 2f;
            maxVerticalSpeed *= 2f;
        }
        else if (Settings.difficulty == Difficulty.hard)
        {
            speed *= 2.8f;
            maxVerticalSpeed *= 2.8f;
        }

        if (Random.Range(0, 2) == 1)
        {
            speed = -speed;
        }
        rb.velocity = new Vector2(speed, 0);
    }


    void Update ()
    {
        if (transform.position.y > 4.8 && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(speed, -rb.velocity.y);
        }
        else if (transform.position.y < -4.8 && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(speed, -rb.velocity.y);
        }

        if(transform.position.x > 9)
        {
            masterScript.AddScore(false);
            ResetBall();
        }
        else if(transform.position.x < -9)
        {
            masterScript.AddScore(true);
            ResetBall();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.position.x > -8.075 && transform.position.x < 8.155)
        {
            speed = -speed;
            float difference = Mathf.Clamp(transform.position.y - other.transform.position.y, -0.4f, 0.4f) * 2.5f;
            rb.velocity = new Vector2(speed, maxVerticalSpeed * difference);
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
        if (!MasterScript.gameEnded)
            rb.velocity = new Vector2(speed, 0);
        else
            rb.velocity = Vector2.zero;
    }
}
