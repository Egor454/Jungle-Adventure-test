using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    private float speed = 0.1f;
    private Transform target;
    private Transform transforms;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transforms = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        float x = target.position.x;
        float y = transforms.position.y;
        transforms.position = new Vector2(x, y);

        //transforms.position = Vector2.MoveTowards(transform.position, target.position, speed );
    }
}
