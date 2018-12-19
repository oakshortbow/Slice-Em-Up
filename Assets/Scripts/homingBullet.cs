using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingBullet : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public float speed;
    public float rotateSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.position - rb.position;

        direction.Normalize();

        Vector3.Cross(direction, transform.up);

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        
            rb.angularVelocity = -rotateAmount * Random.Range(rotateSpeed*0.75F,rotateSpeed*1.25F);
            rb.velocity = transform.up * Random.Range(speed*0.75F,speed*1.25F);
    }

}
