using UnityEditor;
using UnityEngine.Events;

public class PlayerModel 
{
    private   float playerMove;
    private  float horizontalSpeed = 0.1f;
    public  event UnityAction <float> ChangedPositionModel;
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
}
