using UnityEditor;
using UnityEngine.Events;

public class GroundEnemyModel
{
    private float speed = 2f;
    private int damage = 1;
    public event UnityAction<float> ChangedEnemyPositionModel;
    public event UnityAction<int> SendDamageToPlayer;
    public void ChangePositionEnemy(bool enemy)
    {
        if (enemy)
        {
            ChangedEnemyPositionModel?.Invoke(speed);
        }

    }
    public void SendDamageEnemy()
    {
        SendDamageToPlayer?.Invoke(damage);
    }

}
    
