using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

    private PlayerHealthController playerHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<PlayerHealthController>().playerCurrentHealth < collision.gameObject.GetComponent<PlayerHealthController>().playerMaxHealth)
        {
            collision.gameObject.GetComponent<PlayerHealthController>().setMaxHealth();
            Destroy(gameObject);
        }

    }
}
