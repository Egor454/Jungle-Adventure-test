using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossEnemyModel 
{
    private float speed = 4f;
    private int damage = 3;
    public event UnityAction<int> SendDamagePlayer;
    public event UnityAction<float> SendSpeedBoss;
    public void CollisonPlayerGet()
    {
        SendDamagePlayer?.Invoke(damage);
    }

    public void SendSpeedToMoving()
    {
        SendSpeedBoss?.Invoke(speed);
    }
}
