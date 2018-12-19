using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePlayerBullet : MonoBehaviour
{

    public float projectileSpeed;
    public float fireRate;
    public float fireRateCounter;
    public Rigidbody2D bullet;
    public float bulletUpRotation;
    public float bulletDownRotation;
    public float bulletRightRotation;
    public float bulletLeftRotation;
    public float bulletUpOffset;
    public float bulletDownOffset;
    public float bulletRightOffset;
    public float bulletLeftOffset;
    Animator anim;
    private Vector2 lastFiredPosition;
    private bool isAttacking;

    // Use this for initialization
    void Start()
    {

        fireRateCounter = fireRate;
        fireRate = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }
        if (fireRate <=0) { 
        fireBullet();
        if (isAttacking)
           {
             fireRate = fireRateCounter;
           }
        
        }
        anim.SetBool("isAttacking",isAttacking);
        anim.SetFloat("LastFiredPositionX", lastFiredPosition.x);
        anim.SetFloat("LastFiredPositionY", lastFiredPosition.y);
    }

    void fireBullet()
    {

        Rigidbody2D clone;


       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            clone = Instantiate(bullet, transform.position + new Vector3(0f,bulletUpOffset), Quaternion.Euler(0, 0, bulletUpRotation)) as Rigidbody2D;
            clone.velocity = new Vector2(0f, 1f * projectileSpeed);
            lastFiredPosition = new Vector2(0f, 1f);
            isAttacking = true;
        }


        else if (Input.GetKey(KeyCode.DownArrow))
        {

            clone = Instantiate(bullet, transform.position + new Vector3(0f, bulletDownOffset), Quaternion.Euler(0, 0, bulletDownRotation)) as Rigidbody2D;
            clone.velocity = new Vector2(0f, -1f * projectileSpeed);
            lastFiredPosition = new Vector2(0f, -1f);
            isAttacking = true;

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            clone = Instantiate(bullet, transform.position + new Vector3(bulletLeftOffset, 0f), Quaternion.Euler(0, 0, bulletLeftRotation)) as Rigidbody2D;
            clone.velocity = new Vector2(-1f * projectileSpeed, 0f);
            lastFiredPosition = new Vector2(-1f, 0f);
            isAttacking = true;


        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {

            clone = Instantiate(bullet, transform.position + new Vector3(bulletRightOffset, 0f), Quaternion.Euler(0, 0, bulletRightRotation)) as Rigidbody2D;
            clone.velocity = new Vector2(1f * projectileSpeed, 0f);
            lastFiredPosition = new Vector2(1f, 0f);
            isAttacking = true;

        }
        else
        {
            isAttacking = false;
        }
        

    }
}
