﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundEnemyView : MonoBehaviour
{
    [SerializeField] private Transform firstBorder, secondBorder;
    [SerializeField] private Transform startPos;
    private bool groundEnemy = true;
    public event UnityAction<bool> MoveGroundEnemy;
    private Transform transforms;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
        transforms = GetComponent<Transform>();
    }
    void FixedUpdate()
    {

        MoveGroundEnemy?.Invoke(groundEnemy);
    }

    public void MoveEnemyPosition(float speed)
    {
        if(this != null)
        {
            transforms.position = Vector3.MoveTowards(transforms.position, nextPos, speed * Time.deltaTime);
            Vector3 Scaler = transforms.localScale;
            if (transforms.position.x == firstBorder.position.x)
            {
                nextPos = secondBorder.position;
                Scaler.x = -7;
                transforms.localScale = Scaler;
            }
            if (transforms.position.x == secondBorder.position.x)
            {
                nextPos = firstBorder.position;
                Scaler.x = 7;
                transforms.localScale = Scaler;
            }

        }
    }

}
