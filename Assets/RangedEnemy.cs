using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public Transform shotPoint;

    public GameObject Knife;
    public GameObject RKnife;


    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttack;
                anim.SetTrigger("attack");
            }
        }
    }

    public void RangedAttack()
    {
        if (player != null)
        {
            
            Vector2 direction = player.position -shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shotPoint.rotation = rotation;   

            Instantiate(Knife, shotPoint.position, shotPoint.rotation);
        }
    }
    public void RangedAttack2()
    {
        if (player != null)
        {
            
            Vector2 direction = player.position -shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shotPoint.rotation = rotation;   

            Instantiate(RKnife, shotPoint.position, shotPoint.rotation);
        }
    }
    

}
