using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundView : MonoBehaviour
{
    public event UnityAction GetDamage;
    GameController game;
    public void Iniinitialization(GameController game)
    {
        this.game = game;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Boss")
        {
            GetDamage?.Invoke();
        }
    }
    public void DestroyedGroundView(bool living)
    {
        if (!living)
        {

        }
    }
}
