using UnityEditor;
using UnityEngine.Events;

public class GroundEnemyModel
{
    #region Private Fields

    private float speed = 2f;
    private int damage = 1;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction<float> ChangedEnemyPositionModel;
    public event UnityAction<int> SendDamageToPlayer;

    #endregion UntiyAction

    #region Public Methods

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

    #endregion Public Methods

}

