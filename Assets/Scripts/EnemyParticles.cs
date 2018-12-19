using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticles : MonoBehaviour {
    public Transform deathPoint;
    public GameObject deathBurst;
    public GameObject damageBurst;
    private EnemyHealthController enemyHealthController;
    

    // Use this for initialization
    void Start () {
        enemyHealthController = GetComponent<EnemyHealthController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyHealthController.currentHealth < enemyHealthController.oldHealth)
        {
           Instantiate(damageBurst, deathPoint.position, transform.rotation);
            enemyHealthController.oldHealth = enemyHealthController.currentHealth;
        }
       if (enemyHealthController.currentHealth <= 0)
       {
         Instantiate(deathBurst, deathPoint.position, transform.rotation);
         enemyHealthController.DestroyEnemy();
       }
    }
}
