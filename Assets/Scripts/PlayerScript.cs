using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    #region Variables

    [Header("Global player setting")]

    public int nPlayer;
    public GameObject goPunchPlayer;

    [Header("Player movements variables")]

    public int playerDirection;
    public float playerSpeed;
    public bool canJump;

    [Header("Player Actions variables")]

    public bool canPunch;
    public bool isCollectable;
    public bool isCollectibleInHands;

    #endregion Variables


    void Start()
    {
        //------Variables initialization------
        //Initialisation de la position du poing
        goPunchPlayer.transform.position = new Vector2(transform.position.x + 0.33f, goPunchPlayer.transform.position.y);

        //Variables d'autorisation de saut et de poing
        canPunch = true;
        canJump = true;
    }

	void Update()
    {
        ControllersPlayer();

        PlacementHitboxTaper();
    }

    void FixedUpdate()
    {
        Deplacement();

        transform.position = new Vector2(transform.position.x + playerSpeed, transform.position.y);

    }


    //--------Deplacement---------

    void ControllersPlayer()
    {

        #region Saut
        //Saut avec A
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && canJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
            canJump = false;
        }
        #endregion Saut

        #region Taper

        //Punch avec X
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && canPunch)
        {
            StartCoroutine(HitboxPunch());
            StartCoroutine(ResetPunch());
            canPunch = false;
        }

        #endregion taper

        #region Collectible

        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isCollectable && !isCollectibleInHands)
        {
            isCollectibleInHands = true;
        }

        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isCollectibleInHands)
        {
            isCollectibleInHands = false;
        }

        #endregion


        #region Commandes joueurs 

        //Movement P1 : Blob
        if (nPlayer == 1)
        {
            //Right
            if (Input.GetAxis("P1xAxis") >= 0.80f)
            {
                playerDirection = 2;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            //Left
            else if (Input.GetAxis("P1xAxis") <= -0.80f)
            {
                playerDirection = 1;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            //Ne bouge pas 
            else
            {
                playerDirection = 0;
            }
        }

        //Movement P2 : Flan

        //Movement P3 : Ghost

        //Movement P4 : Micheline

        #endregion Commandes joueurs
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


    //--------Interactions---------

    void PlacementHitboxTaper()
    {
        //Left
        if (playerDirection == 1)
        {
            goPunchPlayer.transform.position = new Vector2(transform.position.x + -0.33f, goPunchPlayer.transform.position.y);
        }

        //Right
        else if (playerDirection == 2)
        {
            goPunchPlayer.transform.position = new Vector2(transform.position.x + 0.33f, goPunchPlayer.transform.position.y);
        }
    }


    
    //------Collision------
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    //-------Trigger-------

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            isCollectable = true;
        }

        if (isCollectibleInHands)
        {
            other.gameObject.transform.position = transform.position;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            isCollectable = false;
        }
    }



    IEnumerator HitboxPunch()
    {
        float hitboxActivationTime = 0.3f;

        goPunchPlayer.SetActive(true);
        yield return new WaitForSeconds(hitboxActivationTime);
        goPunchPlayer.SetActive(false);
    }

    IEnumerator ResetPunch()
    {
        float timeBeforePunch = 0.5f;

        yield return new WaitForSeconds(timeBeforePunch);
        canPunch = true;    
    }
}
