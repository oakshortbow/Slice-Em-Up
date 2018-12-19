using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    private Transform target;
    public float distanceToStop;
    private Animator anim;
    
    

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    

    }

    // Update is called once per frame
    void Update()
    {


        if (target.gameObject.activeInHierarchy)
        {
            Vector2 directPosition = transform.position - target.position;
            Vector2 directionFacing = directPosition / Vector2.Distance(transform.position, target.position);
            Vector2 distance = transform.position - target.position;


            if (Vector2.SqrMagnitude(distance) > distanceToStop*distanceToStop)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            anim.SetFloat("MoveX", -directionFacing.x);
            anim.SetFloat("MoveY", -directionFacing.y);
        }
    }
}
