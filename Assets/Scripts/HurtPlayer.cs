using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class HurtPlayer : MonoBehaviour {
    public int damageToGive;
    public float DelayBetweenHits;
    private float DelayBetweenHitsCounter;
    // Use this for initialization
    void Start() {
        DelayBetweenHitsCounter = DelayBetweenHits;
    }

    // Update is called once per frame
    void Update() {
     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthController>().hurtPlayer(damageToGive);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        DelayBetweenHits -= Time.deltaTime;
        if (collision.gameObject.name == "Player"  && DelayBetweenHits <= 0)
        {
            collision.gameObject.GetComponent<PlayerHealthController>().hurtPlayer(damageToGive);
            DelayBetweenHits = DelayBetweenHitsCounter;
        }
    }

  

}
