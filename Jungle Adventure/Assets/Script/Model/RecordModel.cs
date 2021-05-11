using UnityEngine.Events;

public class RecordModel
{
    #region Private Fields

    private RecordPlayer recordPlayer;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction<RecordPlayer> SendRecord;

    #endregion UnityAction

    #region Public Methods

    public RecordModel()
    {
        recordPlayer = DbManager.Instance.RecordPlayer;
    }

    public void SendRecordPlayer()
    {
        SendRecord?.Invoke(recordPlayer);
    }

    #endregion Public Methods
}
