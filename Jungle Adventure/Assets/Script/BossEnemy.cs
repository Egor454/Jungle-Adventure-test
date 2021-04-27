using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossEnemy : MonoBehaviour
{

    private float speed = 3f;
    private Transform target;
    private Transform transforms;
    private float timeLeft = 5f;
    private float timeWait = 5f;
    private bool attacked = false;
    Vector2 br;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transforms = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft > 0 && !attacked)
        {
            float x = target.position.x;
            float y = transforms.position.y;
            transforms.position = new Vector2(x, y);
            
        }
        else if(timeLeft < 0)
        {
            if (attacked)
            {
                transforms.position = Vector2.MoveTowards(transform.position, br, speed * Time.deltaTime);
            }
            else
            {
                HeroAttack();
            }
        }
        
    }
    private void HeroAttack()
    {
        float x = target.position.x;
        float y = target.position.y;
        br = new Vector2(x, y);
        attacked = true;
    }
}
