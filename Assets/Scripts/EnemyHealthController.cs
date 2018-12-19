using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyHealthController : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public int oldHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hurtEnemy(int damageToGive)
    {
        oldHealth = currentHealth;
        currentHealth -= damageToGive;
        

    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void healEnemy(int healAmount)
    {

        currentHealth += healAmount;

        if (currentHealth + healAmount > maxHealth)
        {
            setMaxHealth();
        }
    }

    public void DestroyEnemy()
    {
        CameraShaker.Instance.ShakeOnce(8f, 4f, .1f, .1f);
        Destroy(gameObject);
    }

}
