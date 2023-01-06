using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    void Start()
    {
        if (Settings.difficulty == Difficulty.normal)
            speed *= 2f;
        else if (Settings.difficulty == Difficulty.hard)
            speed *= 2.8f;
    }

    void Update ()
    {
        float moveAmount;
        if(transform.CompareTag("P1"))
            moveAmount = Input.GetAxis("P1 Vertical") * speed * Time.deltaTime;
        else if(transform.CompareTag("P2"))
            moveAmount = Input.GetAxis("P2 Vertical") * speed * Time.deltaTime;
        else
            moveAmount = Input.GetAxis("SP Vertical") * speed * Time.deltaTime;

        if(!MasterScript.gameEnded)
            transform.Translate(0f, moveAmount, 0f);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 4.4f), 0);
    }
}
