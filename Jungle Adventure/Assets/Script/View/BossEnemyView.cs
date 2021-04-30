﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BossEnemyView : MonoBehaviour
{

    private float speed = 4f;
    private Transform target;
    private Transform transforms;
    private float timeLeft = 5f;
    private float timeWait = 2f;
    private bool attacked = false;
    private bool moveBackposition = false;
    private float homeX;
    private float homeY;
    Vector2 positionAttacked;
    Vector2 homePosition;
    public event UnityAction ColisionPlayer;
    public event UnityAction<GameObject> BossDeath;
    public event UnityAction BossAttacked;
    public event UnityAction BossBackPosition;

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
        else if(timeLeft < 0 && !moveBackposition)
        {
            if (attacked)
            {
                BossAttacked?.Invoke();
            }
            else
            {
                HeroAttack();
            }
        }
        if (moveBackposition)
        {
            timeWait -= Time.deltaTime;
            if (attacked)
            {
                BossAttacked?.Invoke();
            }
            if (timeWait < 0)
            {
                homeX = target.position.x;
                homeY = 10.5f;
                homePosition = new Vector2(homeX, homeY);
                attacked = false;
                BossBackPosition?.Invoke();
            }
            if(transforms.position.y == homeY)
            {
                moveBackposition = false;
                timeLeft = 5f;
                timeWait = 2f;
            }
        }
        
    }
    public void MovingBoss(float speed)
    {
        if (attacked)
        {
            transforms.position = Vector2.MoveTowards(transform.position, positionAttacked, speed * Time.deltaTime);
        }
        if (moveBackposition && timeWait < 0)
        {
            transforms.position = Vector2.MoveTowards(transform.position, homePosition, speed * Time.deltaTime);
        }
    }
    private void HeroAttack()
    {
        float x = target.position.x;
        float y = -10f;
        positionAttacked = new Vector2(x, y);
        attacked = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            moveBackposition = true;
        }
        if (other.gameObject.tag == "Death")
        {
            BossDeath?.Invoke(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            ColisionPlayer?.Invoke();
            gameObject.SetActive(false);
        }
    }
}