

public class RecordPresenter
{
    #region Private Fields

    private RecordView recordView { get; set; }
    private RecordModel recordModel { get; set; }

    #endregion Private Fields

    #region Public Methods

    public RecordPresenter(RecordView view, RecordModel model)
    {
        this.recordView = view;
        this.recordModel = model;

        recordView.GetRecordPlayer += GetRecordPlayer;
        recordModel.SendRecord += SendRecordView;
    }

    public void GetRecordPlayer()
    {
        recordModel.SendRecordPlayer();
    }

    public void SendRecordView(RecordPlayer recordPlayer)
    {
        recordView.LoadRecords(recordPlayer);
    }

    #endregion Public Methods
}
