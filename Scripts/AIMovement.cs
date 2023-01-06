using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public float speed;
    public Transform ball;

    void Awake()
    {
        ball = GameObject.Find("Ball").transform;
    }

    void Start()
    {
        if (Settings.difficulty == Difficulty.normal)
            speed *= 2f;
        else if (Settings.difficulty == Difficulty.hard)
            speed *= 2.8f;
    }

        // Update is called once per frame
        void Update ()
    {
        if (!MasterScript.gameEnded && transform.position.y != ball.position.y)
        {
            float moveAmount = speed * Time.deltaTime;
            if (!CheckIfMovingTooMuch(moveAmount))
            {

                if (transform.position.y < ball.position.y)
                {
                    transform.Translate(0f, moveAmount, 0f);
                }
                else
                {
                    transform.Translate(0f, -moveAmount, 0f);
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, ball.position.y, 0);
            }
        }
	}

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 4.4f), 0);
    }

    bool CheckIfMovingTooMuch(float moveAmount)
    {
        if(Mathf.Abs(transform.position.y - ball.position.y) < moveAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
