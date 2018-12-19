using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerHealthController : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int oldHealth;


    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;	

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hurtPlayer(int damageToGive)
    {
        oldHealth = playerCurrentHealth;
        playerCurrentHealth -= damageToGive;
        CameraShaker.Instance.ShakeOnce(10f, 5f, .1f, .2f);
    }

    public void setMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void healPlayer(int healAmount)
    {
        
        playerCurrentHealth += healAmount;

        if (playerCurrentHealth + healAmount > playerMaxHealth)
        {
            setMaxHealth();
        }
    }

    public void healPlayerOverMax(int healAmount)
    {
        playerCurrentHealth += healAmount;
    }

    public void DestroyPlayer()
    {
        
        CameraShaker.Instance.ShakeOnce(10f, 10f, .1f, 1.5f);
        gameObject.SetActive(false);
    }

}
