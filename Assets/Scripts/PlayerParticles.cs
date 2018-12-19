using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public Transform deathPoint;
    public GameObject deathBurst;
    public GameObject damageBurst;
    private PlayerHealthController playerHealthController;
    private SpriteRenderer sr;
    private float colorValue = 1f;
    private float colorChangeRate = 1f;
    private int changeDirection = -1;




    // Use this for initialization
    void Start()
    {
        playerHealthController = GetComponent<PlayerHealthController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        colorValue += colorChangeRate * Time.deltaTime*changeDirection;
        colorValue = Mathf.Clamp01(colorValue);
 

        if (playerHealthController.playerCurrentHealth < playerHealthController.oldHealth)
        {
            Debug.Log("Player Hit");
            Instantiate(damageBurst, deathPoint.position, transform.rotation);
            playerHealthController.oldHealth = playerHealthController.playerCurrentHealth;
        }

            if (playerHealthController.playerCurrentHealth <= 0)
        { 
            Instantiate(deathBurst, deathPoint.position, transform.rotation);
            playerHealthController.DestroyPlayer();
        }
    }
}
