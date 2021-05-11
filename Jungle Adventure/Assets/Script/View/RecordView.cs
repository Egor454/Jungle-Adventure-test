using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RecordView : MonoBehaviour
{
    #region SerializedField

    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform rowParent;

    #endregion SerializedField

    #region Private Fields



    #endregion Private Fields

    #region UnityAction

    public event UnityAction GetRecordPlayer;

    #endregion UnityAction

    #region Private Methods

    void Start()
    {
        GetRecordPlayer?.Invoke();
    }

    void Update()
    {

    }

    #endregion Private Methods

    #region Public Methods

    public void LoadRecords(RecordPlayer recordPlayer)
    {
        int i = 0;
        foreach (var record in recordPlayer.recordPlayer)
        {
            i++;
            if (i > 6)
            {
                break;
            }
            else
            {
                GameObject newRecord = Instantiate(rowPrefab, rowParent);
                Text[] texts = newRecord.GetComponentsInChildren<Text>();
                texts[0].text = i.ToString();
                texts[1].text = record.Name;
                texts[2].text = record.Time;
                texts[3].text = record.Coin.ToString();
                texts[4].text = record.Score.ToString();
            }

        }
    }

    #endregion Public Methods

}
