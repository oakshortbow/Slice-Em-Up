using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private PlayerStaminaController playerStamina;
    public float dashSpeed;
    public GameObject dashEffect;
    private bool dashUp = false;
    private bool dashLeft = false;
    private bool dashRight = false;
    private bool dashDown= false;
    private bool run;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerStamina = GetComponent<PlayerStaminaController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerStamina.playerCurrentStamina > 199)
        {
            
            playerStamina.UseStamina(200);
            CameraShaker.Instance.ShakeOnce(4f, 2f, .1f, .1f);
            Instantiate(dashEffect, transform.position, Quaternion.identity);

            if (lastMove.x == 1)
            {
                dashRight = true;
                
            }
            else if (lastMove.x == -1)
            {
                dashLeft = true;
                
            }

            else if (lastMove.y == -1)
            {
                dashDown = true;
                
            }

            else if (lastMove.y == 1)
            {
                dashUp = true;
                
            }

        }

        if (playerStamina.playerCurrentStamina < playerStamina.playerMaxStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            playerStamina.UseStamina(-5);
        }

    }

    private void FixedUpdate()
    {


        playerMoving = false;
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * Time.deltaTime, moveVertical * Time.deltaTime);
        
        movement.Normalize();

        if (movement.x > 0.5f || movement.x < -0.5f)
        {
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (movement.y > 0.5f || movement.y < -0.5f)
        {
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        rb.velocity = movement * moveSpeed;

        if (rb.velocity.magnitude > 0)
        {
            playerMoving = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && playerStamina.playerCurrentStamina > 0 && playerMoving)
        {
            rb.velocity = movement * moveSpeed * 2;
            if (playerStamina.playerCurrentStamina > 0)
            {
                playerStamina.UseStamina(2);
            }
        }

        if (dashUp)
        {
            dashUp = false;
            rb.velocity = (Vector2.up * dashSpeed);
        }

        else if (dashRight)
        {
            dashRight = false;
            rb.velocity = (Vector2.right * dashSpeed);
        }

        else if (dashLeft)
        {
            dashLeft = false;
            rb.velocity = (Vector2.left * dashSpeed);
        }

        else if (dashDown)
        {
            dashDown = false;
            rb.velocity = (Vector2.down * dashSpeed);
        }


        anim.SetFloat("MoveX", moveHorizontal);
        anim.SetFloat("MoveY", moveVertical);

        anim.SetBool("isMoving", playerMoving);

        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

}