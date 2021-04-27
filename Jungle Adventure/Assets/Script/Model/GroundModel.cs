using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundModel 
{
    private int health = 3;
    public event UnityAction<bool> Destroyed;
    private bool living = true;

    public void ChangeHealth()
    {
        health -= 1;
        if(health == 0)
        {
            living = false;
            Destroyed?.Invoke(living);
        }
    }
}
