using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletTowardsPlayer : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;
    private Vector3 bulletDirection;
   

    // Use this for initialization
    void Start()
    {
      
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            bulletDirection = (player.transform.position - transform.position).normalized;
            Vector3 position = player.position;
            Vector3 difference = player.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 45);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(bulletDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
