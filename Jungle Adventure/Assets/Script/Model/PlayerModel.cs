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
    public void ChangeHealth()
    {
        health -= 1;
        GetHealth?.Invoke(health);

    }
    public void Death()
    {
        health = 0;
        GetHealth?.Invoke(health);
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
