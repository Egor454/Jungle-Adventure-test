using UnityEditor;
using UnityEngine.Events;
using UnityEngine;

public class PlayerModel 
{
    #region Private Fields

    private float playerMove;
    private int health = 3;
    private  float horizontalSpeed = 0.1f;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction <float> ChangedPositionModel;
    public event UnityAction<int> GetHealth;
    public event UnityAction<int,Collider2D> UpgradeTheAmountOfHealth;
    public event UnityAction PlayerDeath;

    #endregion UnityAction

    #region Public Methods

    public void ChangePosition(float moveInput)
    {
        if(moveInput == 1)
        {
            playerMove = horizontalSpeed;
        }
        else if(moveInput == -1)
        {
            playerMove = -horizontalSpeed;
        }
        ChangedPositionModel?.Invoke(playerMove);
        playerMove = 0;
    }
    public void ChangeHealth(int damage)
    {
        health -= damage;
        if(health == 0)
        {
            PlayerDeath?.Invoke();
        }
        GetHealth?.Invoke(health);

    }
    public void GetDamagePlatform()
    {
        health -= 1;
        if (health == 0)
        {
            PlayerDeath?.Invoke();
        }
        GetHealth?.Invoke(health);
    }
    public void Death()
    {
        health = 0;
        PlayerDeath?.Invoke();
    }
    public void GetHealthPotion(Collider2D collision)
    {
        if (health < 3)
        {
            health++;
            UpgradeTheAmountOfHealth?.Invoke(health, collision);
        }

    }

    #endregion Public Methods
}
