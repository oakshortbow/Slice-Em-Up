using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnHit : MonoBehaviour
{
    SpriteRenderer sr;
    public float DelayBetweenHits;
    private float DelayBetweenHitsCounter;
    void Start()
    {
        DelayBetweenHitsCounter = DelayBetweenHits;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        DelayBetweenHits -= Time.deltaTime;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag =="Bullet" && DelayBetweenHits <=0)
        {
            sr.color = new Color(2, 0, 0); //set this object's red color to 200 percent
            DelayBetweenHits = DelayBetweenHitsCounter;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
        {
           sr.color = new Color(2, 0, 0);//set this object's red color to 200 percent
        }
    }

    void Update()
    {
        //linear interpolation brings two values closer together proportional to a given third value(time)
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 0.5f);//slowly linear interpolate. takes about 3 seconds to return to white
    }
}
