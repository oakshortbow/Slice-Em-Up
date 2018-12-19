using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject environmentBurst;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
        collision.gameObject.GetComponent<EnemyHealthController>().hurtEnemy(damageToGive);
        Destroy(gameObject); 
        }

        if(collision.gameObject.tag == "World")
        {
            Instantiate(environmentBurst, hitPoint.position, hitPoint.rotation);
            Destroy(gameObject);
        }
    }
}
