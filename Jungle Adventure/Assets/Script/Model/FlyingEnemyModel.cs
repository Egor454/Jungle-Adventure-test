using UnityEngine.Events;

public class FlyingEnemyModel 
{
    private float speed = 3f;
    public event UnityAction<float> ChangedEnemyPositionModel;

    public void ChangePositionEnemy(bool enemy)
    {
        if (enemy)
        {
            ChangedEnemyPositionModel?.Invoke(speed);
        }

    }
}
