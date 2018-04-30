using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region Variables

    private int playerDirection;
    public int nPlayer;
    bool canJump = true;
    private float playerSpeed;
    private float speed = 5f;

    #endregion Variables


    // Use this for initialization
    void Start ()
    {

       
    }

	// Update is called once per frame
	void Update ()
    {
        if (nPlayer == 1) //Controls P1
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
                canJump = false;
            }

            if (Input.GetAxis("P1xAxis") >= 0.80f)
            {
                playerDirection = 2;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (Input.GetAxis("P1xAxis") <= -0.80f)
            {
                playerDirection = 1;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            else
            {
                playerDirection = 0;
            }
        }
    }

    void FixedUpdate()
    {
        Deplacement();
    }

    void Deplacement()
    {
        if (playerDirection == 1)
        {
            playerSpeed = -speed;
        }
        if (playerDirection == 2)
        {
            playerSpeed = speed;
        }
        if (playerDirection == 0)
        {
            speed = 0;
        }

        gameObject.transform.Translate(playerSpeed, 0, 0);
        gameObject.transform = new Vector2(transform.position.x + playerSpeed, transform.position.y);
    }
}
