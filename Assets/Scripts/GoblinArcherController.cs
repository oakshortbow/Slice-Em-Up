using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcherController : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    private Transform target;
    public float distanceToStop;
    public float retreatDistance;
    public float timePerShot;
    private float timePerShotCounter;
    public Rigidbody2D arrow;
    public float minDistancetoShoot;
    private Animator anim;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timePerShotCounter = timePerShot;
        timePerShot = Random.Range(0, timePerShot);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject.activeInHierarchy) 
            {
            timePerShot -= Time.deltaTime;
            Vector2 directPosition = transform.position - target.position;
            Vector2 directionFacing = directPosition / Vector2.Distance(transform.position, target.position);
            Vector2 distance = transform.position - target.position;

            Rigidbody2D clone;

            if (Vector2.SqrMagnitude(distance) < minDistancetoShoot*minDistancetoShoot && timePerShot <= 0)
            {
                clone = Instantiate(arrow, transform.position, transform.rotation) as Rigidbody2D;
                timePerShot = timePerShotCounter;
                
            }

            if (Vector2.SqrMagnitude(distance) > distanceToStop*distanceToStop)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetFloat("MoveX", -directionFacing.x);
                anim.SetFloat("MoveY", -directionFacing.y);

            }

            else if (Vector2.SqrMagnitude(distance) > retreatDistance*retreatDistance && Vector2.SqrMagnitude(distance) < distanceToStop*distanceToStop)
            {
                transform.position = this.transform.position;
                anim.SetFloat("MoveX", 0);
                anim.SetFloat("MoveY", 0);
            }

            else if (Vector2.SqrMagnitude(distance) < retreatDistance*retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
                anim.SetFloat("MoveX", -directionFacing.x);
                anim.SetFloat("MoveY", -directionFacing.y);
            }

           
          

            
        }
    }
}


