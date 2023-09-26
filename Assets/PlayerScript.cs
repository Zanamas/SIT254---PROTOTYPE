using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //Variables
    public Rigidbody2D pRigid;
    public SpriteRenderer pSprite;
    public BoxCollider2D pGround;
    public CircleCollider2D pCircle;
    public bool isGrounded = false;
    public int speed;
    public int jumpPower;
    Vector2 pMove;
    public int knockBackStr;

    public UnitHealth pHealth;


    public int gold = 0;
    public Text _gold;
    public int plants = 0;
    public Text _plants;

    public bool gameOver = false;
    public GameObject goScreen;

    public GameObject _resText;

    Vector2 resPoint;

    // Start is called before the first frame update
    void Start()
    {

        pHealth = new UnitHealth(6, 6);
    }

    // Fixed update is used for the player character, this code is run every frame of the game.
    private void FixedUpdate()
    {
        //Horizontal player movement
        if (gameOver == false) {
            pRigid.velocity = new Vector2(pMove.x * speed * Time.deltaTime, pRigid.velocity.y);
            pMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        

        //update plant/gold
        _gold.text = gold.ToString();   
        _plants.text = plants.ToString();

        //check to see if palyer is dead
        if (pHealth.Health <= 0)
        {
            gameOver = true;
            goScreen.SetActive(true);
        }

        // Flipping the spirte when changing direction
        if (pRigid.velocity.x > 0.01)
        {
            pSprite.flipX = false;
        }
        else if (pRigid.velocity.x < -0.01)
        {
            pSprite.flipX = true;
        }


        //Player jumping code, a bit dodgy can be fixed up if needed
        Vector2 playerUp;
        playerUp = pRigid.velocity;
        if (isGrounded && Input.GetAxisRaw("Jump") > 0 && gameOver == false)
        {

            //Pushes the player up
            playerUp.y = Input.GetAxisRaw("Jump") * jumpPower;
            pRigid.velocity = playerUp;
        }
    

    }

    //when the player touches an enemy and gets damaged
    void OnCollisionEnter2D(Collision2D collision)
    {

        //        if (collision.gameObject.name == "JumpOnHead")
        //        {
        //       Vector3 knockBack = new Vector3(transform.position.x - collision.gameObject.transform.position.x, transform.position.y - collision.gameObject.transform.position.y, 0);
        //        pRigid.velocity = (knockBack * knockBackStr);
        //
        //        Destroy(collision.gameObject, 0);
        //    }


        if (collision.gameObject.tag == "Enemy")
        {

                Vector3 knockBack = new Vector3(transform.position.x - collision.gameObject.transform.position.x, transform.position.y - collision.gameObject.transform.position.y, 0);
                pRigid.velocity = (knockBack * knockBackStr);

                pHealth.Health -= 1;
        }
        


    }
    // code that uses the box collider on the player character to see if they are grounded
    // if on the ground, they can jump!
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                break;

            case "RespawnPoint":
                resPoint = collision.gameObject.transform.position;
                _resText.SetActive(true);
                break;
            case "Plant":
                Destroy(collision.gameObject, 0);
                plants += 1;
                break;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = false;
                break;

            case "RespawnPoint":
                _resText.SetActive(false);
                break;

        }


    }

    public void Respawn()
    {
        gameOver = false;
        pHealth.healUnit(6);
        transform.position = resPoint;
        goScreen.SetActive(false);

    }
}

