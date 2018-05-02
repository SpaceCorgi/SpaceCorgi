using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region Variables

    [Header("Variables du joueur")]

    public int playerDirection;
    public int nPlayer;
    bool canJump = true;
    public float playerSpeed;

    #endregion Variables


    // Use this for initialization
    void Start ()
    {

       
    }

	// Update is called once per frame
	void Update ()
    {
        #region Commandes joueurs 
        if (nPlayer == 1) //Controls P1
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
                //canJump = false;
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
        #endregion Commandes joueurs
    }

    void FixedUpdate()
    {
        Deplacement();

        transform.position = new Vector2(transform.position.x + playerSpeed, transform.position.y);

    }

    void Deplacement()
    {
        //No movement
        if (playerDirection == 0)
        {
            playerSpeed = 0;
        }

        //Left
        else if (playerDirection == 1)
        {
            playerSpeed = -0.05f;
        }

        //Right
        else if (playerDirection == 2)
        {
            playerSpeed = 0.05f;
        }
    }
}
