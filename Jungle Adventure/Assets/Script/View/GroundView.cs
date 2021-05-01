using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundView : MonoBehaviour
{
    public event UnityAction GetDamage;
    private GameController game;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
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
    public void GetHealth(int hp)
    {
        if(hp == 2)
        {
            sprite.sprite = (Sprite)Resources.Load("Image/ImageBossFight/HeartGround" + hp, typeof(Sprite));
        }
        else if(hp == 1)
        {
            sprite.sprite = (Sprite)Resources.Load("Image/ImageBossFight/HeartGround" + hp, typeof(Sprite));
        }
    }
}
