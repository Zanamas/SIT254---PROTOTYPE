using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

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
    public UnitHealth pHealth;
    public int knockBackStr;

    // Start is called before the first frame update
    void Start()
    {
        pHealth = new UnitHealth(6, 6);
        Debug.Log("start"); 

    }

    // Fixed update is used for the player character, this code is run every frame of the game.
    private void FixedUpdate()
    {
        //Horizontal player movement
       
        pRigid.velocity = new Vector2(pMove.x * speed * Time.deltaTime, pRigid.velocity.y);
        pMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


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
        if (isGrounded && Input.GetAxisRaw("Jump") > 0)
        {

            //Pushes the player up
            playerUp.y = Input.GetAxisRaw("Jump") * jumpPower;
            pRigid.velocity = playerUp;
        }
    

    }

    //when the player touches an enemy and gets damaged
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 knockBack = new Vector3(transform.position.x - collision.gameObject.transform.position.x, transform.position.y - collision.gameObject.transform.position.y, 0);
            pRigid.velocity = (knockBack * knockBackStr);
        }


    }
    // code that uses the box collider on the player character to see if they are grounded
    // if on the ground, they can jump!
    public void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}

