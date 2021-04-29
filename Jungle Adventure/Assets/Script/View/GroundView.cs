using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundView : MonoBehaviour
{
    public event UnityAction GetDamage;
    private GameController game;
    public void Iniinitialization(GameController game)
    {
        this.game = game;
    }
    private void OnCollisionEnter2D(Collision2D other)
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
            game.DestroyGround(gameObject);
        }
    }
}
