using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBulletRandom : MonoBehaviour
{

    public float moveSpeed;
    private float posX;
    private float posY;

    // Use this for initialization
    void Start()
    {
       posX = (Random.Range(-1F, 1F));
       posY = (Random.Range(-1F, 1F));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + ((posX * moveSpeed) * Time.deltaTime), transform.position.y + ((posY*moveSpeed)* Time.deltaTime), transform.position.z);
    }
}
