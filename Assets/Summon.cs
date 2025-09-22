using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Enemy
{
    public float minx;
    public float miny;
    public float maxx;
    public float maxy;
    public Vector3 offset;
    public Enemy enemyToSummon;
    public float stopDistance;
    public GameObject SummonEffect;
    public float attackspeed;
    public GameObject draculaEffect;

    private Vector2 TargetPosition;
    private Animator anim;
    public float timeBetweenSummon;
    private float summonTime;
    private float attackTime;
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minx, maxx);
        float randomY = Random.Range(miny, maxy);
        TargetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, TargetPosition) > 0.5)
            {
                transform.position = Vector2.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }else
            {
                anim.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummon;
                    anim.SetTrigger("summon");
                }
            }

            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttack;
                }
            }
        }
    }

    public void summon()
    {
    
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position + offset, transform.rotation);
            Instantiate(SummonEffect, transform.position + offset, Quaternion.identity);
        }
    }
    
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;
        float percent= 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackspeed;
            float Formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, Formula);
            yield return null;
        }
    }
    public void SpawnEffect()
    {
        Instantiate(draculaEffect, transform.position, Quaternion.identity);
    }
}
