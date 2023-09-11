using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D pRigid;
    public SpriteRenderer pSprite;
    public BoxCollider2D pGround;
    public bool isGrounded = false;
    public int speed;
    public int jumpPower;
    Vector2 pMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //player movement
       
        pRigid.velocity = new Vector2(pMove.x * speed * Time.deltaTime, pRigid.velocity.y);
        pMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        // Flipping the spirte
        if (pRigid.velocity.x > 0.01)
        {
            pSprite.flipX = false;
        }
        else if (pRigid.velocity.x < -0.01)
        {
            pSprite.flipX = true;
        }


        Vector2 playerUp;
        playerUp = pRigid.velocity;
        if (isGrounded && Input.GetAxisRaw("Jump") > 0)
        {

            //Pushes the player up
            playerUp.y = Input.GetAxisRaw("Jump") * jumpPower;
            pRigid.velocity = playerUp;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}

