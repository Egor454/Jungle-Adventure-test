using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEnemyView : MonoBehaviour
{
    [SerializeField] private Transform firstBorder, secondBorder;
    [SerializeField] private Transform startPos;
    private bool flyingEnemy = true;
    public event UnityAction<bool> MoveFlyingEnemy;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }
    void Update()
    {
        MoveFlyingEnemy?.Invoke(flyingEnemy);
    }

    public void MoveEnemyPosition(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        Vector3 Scaler = transform.localScale;
        if (transform.position.x == firstBorder.position.x)
        {
            nextPos = secondBorder.position;
            Scaler.x = -7;
            transform.localScale = Scaler;
        }
        if (transform.position.x == secondBorder.position.x)
        {
            nextPos = firstBorder.position;
            Scaler.x = 7;
            transform.localScale = Scaler;
        }
    }
}
