﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEnemyView : MonoBehaviour
{
    #region SerializedField

    [SerializeField] private Transform firstBorder, secondBorder;
    [SerializeField] private Transform startPos;

    #endregion SerializedField

    #region Private Fields

    private bool flyingEnemy = true;
    private Transform transforms;
    Vector3 nextPos;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction<bool> MoveFlyingEnemy;
    public event UnityAction DamageToPlayer;

    #endregion unityAction

    #region private Methods

    void Start()
    {
        nextPos = startPos.position;
        transforms = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        MoveFlyingEnemy?.Invoke(flyingEnemy);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DamageToPlayer?.Invoke();
        }
    }

    #endregion Private Methods

    #region Public Methods

    public void MoveEnemyPosition(float speed)
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

    #endregion Public Methods
}
