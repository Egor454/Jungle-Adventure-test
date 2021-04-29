using UnityEditor;
using UnityEngine.Events;

public class PlayerModel 
{
    private   float playerMove;
    private int health = 3;
    private  float horizontalSpeed = 0.1f;
    public  event UnityAction <float> ChangedPositionModel;
    public event UnityAction<int> GetHealth;
    public event UnityAction<int> UpgradeTheAmountOfHealth;
    public event UnityAction PlayerDeath;



    public void ChangePosition(float moveInput)
    {
        if(moveInput == 1)
        {
            playerMove = horizontalSpeed ;
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
    public void GetHealthPotion()
    {
        if (health < 3)
        {
            health++;
            UpgradeTheAmountOfHealth?.Invoke(health);
        }

    }
}
