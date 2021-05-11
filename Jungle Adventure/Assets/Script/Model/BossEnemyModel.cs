using UnityEngine.Events;

public class BossEnemyModel
{
    #region Private Fields

    private float speed = 4f;
    private int damage = 3;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction<int> SendDamagePlayer;
    public event UnityAction<float> SendSpeedBoss;

    #endregion UnityAction

    #region Public Methods

    public void CollisonPlayerGet()
    {
        SendDamagePlayer?.Invoke(damage);
    }

    public void SendSpeedToMoving()
    {
        SendSpeedBoss?.Invoke(speed);
    }

    #endregion Public Methods
}
