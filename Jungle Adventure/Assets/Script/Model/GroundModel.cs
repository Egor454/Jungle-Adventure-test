using UnityEngine.Events;

public class GroundModel
{
    #region Private Methods

    private int health = 3;
    private bool living = true;

    #endregion Private Methods

    #region UnityAction

    public event UnityAction<bool> Destroyed;
    public event UnityAction<int> SendHealth;

    #endregion UnityAction

    #region Public Methods

    public void ChangeHealth()
    {
        health -= 1;
        SendHealth?.Invoke(health);
        if (health == 0)
        {
            living = false;
            Destroyed?.Invoke(living);
        }
    }

    #endregion Public Methods
}
