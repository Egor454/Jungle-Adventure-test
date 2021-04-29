using UnityEngine.Events;

public class FlyingEnemyModel 
{
    private float speed = 3f;
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
