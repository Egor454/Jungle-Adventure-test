using UnityEngine;
using UnityEngine.Events;

public class GroundView : MonoBehaviour
{
    #region UnityAction

    public event UnityAction GetDamage;

    #endregion UnityAction

    #region Private Fields

    private GameController game;
    private SpriteRenderer sprite;

    #endregion Private Fields

    #region Private Methods

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            GetDamage?.Invoke();
        }
    }

    #endregion Private Methods

    #region Public Methods

    public void Iniinitialization(GameController game)
    {
        this.game = game;
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
        if (hp == 2)
        {
            sprite.sprite = (Sprite)Resources.Load("Image/ImageBossFight/HeartGround" + hp, typeof(Sprite));
        }
        else if (hp == 1)
        {
            sprite.sprite = (Sprite)Resources.Load("Image/ImageBossFight/HeartGround" + hp, typeof(Sprite));
        }
    }

    #endregion Public Methods
}
