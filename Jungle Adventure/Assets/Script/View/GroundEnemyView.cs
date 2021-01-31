using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundEnemyView : MonoBehaviour
{
    [SerializeField] private Transform firstBorder, secondBorder;
    [SerializeField] private Transform startPos;
    private bool groundEnemy = true;
    public event UnityAction<bool> MoveEnemy;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }
    void Update()
    {
        MoveEnemy?.Invoke(groundEnemy);
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
