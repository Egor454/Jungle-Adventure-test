using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopView : MonoBehaviour
{

    #region SerializedField

    [SerializeField] private Text[] skinName;
    [SerializeField] private Text[] costSkin;
    [SerializeField] private Image[] imageSkin;
    [SerializeField] private Button[] buySkin;
    [SerializeField] private Button[] selectSkin;
    [SerializeField] private Toggle[] skinWasSelect;
    [SerializeField] private Text coinPlayerText;

    #endregion SerializedField

    #region Private Fields



    #endregion Private Fields

    #region UnityAction

    public event UnityAction GetSkinData;
    public event UnityAction<string> SkinWasBuy;

    #endregion UnityAction

    #region Private Methods

    void Start()
    {
        GetSkinData?.Invoke();
    }

    void Update()
    {
        coinPlayerText.text = DbManager.Instance.CoinPlayer.ToString();
    }

    #endregion Private Methods

    #region Public Methods

    public void LoadData(Skins skin)
    {
        for (int i = 0; i < skinName.Length;i++)
        {
            for ( int j = 0; j < skinName.Length; j++)
            {
                string name = skinName[i].name.ToString();
                if (name == skin.skin[j].Name)
                {
                    skinName[i].text = skin.skin[j].Name;
                    costSkin[i].text = skin.skin[j].Cost.ToString();
                    imageSkin[i].GetComponent<Image>().sprite = (Sprite)Resources.Load("Image/ImageForShop/ForShop" + skin.skin[j].Name, typeof(Sprite));
                }
            }
        }
        coinPlayerText.text = DbManager.Instance.CoinPlayer.ToString();

        if (DbManager.Instance.PlayerBuythisSkin.buySkin.Length != 0)
        {
            for (int i = 0; i < DbManager.Instance.PlayerBuythisSkin.buySkin.Length; i++)
            {
                for (int j = 0; j < skin.skin.Length; j++)
                {
                    if (DbManager.Instance.PlayerBuythisSkin.buySkin[i].magazin_id == skin.skin[j].id.ToString())
                    {
                        buySkin[j].gameObject.SetActive(false);
                        selectSkin[j].gameObject.SetActive(true);
                    }
                }
            }
        }

        if (PlayerPrefs.HasKey("SelectNowSkin"))
        {
            for(int i = 0; i < selectSkin.Length; i++)
            {
                if(PlayerPrefs.GetString("SelectNowSkin") == skinName[i].name)
                {
                    selectSkin[i].interactable = false;
                    skinWasSelect[i].gameObject.SetActive(true);

                }
            }
        }

        for (int i = 0; i < skin.skin.Length; i++)
        {
            if (DbManager.Instance.CoinPlayer <= skin.skin[i].Cost)
            {
                buySkin[i].interactable = false;
            }
        }

    }

    public void BuySkin(string nameSkin)
    {
        for(int i = 0; i < buySkin.Length; i++)
        { 
            if(nameSkin == skinName[i].text)
            {
                buySkin[i].gameObject.SetActive(false);
                selectSkin[i].gameObject.SetActive(true);
                SkinWasBuy?.Invoke(nameSkin);
            }
        }
    }

    public void SendDataAboutBuySkin(int costSkins,int idSkin)
    {
        StartCoroutine(DbManager.Instance.BuySkin(PlayerPrefs.GetString("PlayerRegister"),idSkin));
        StartCoroutine(DbManager.Instance.ChangeMoneyPlayer(PlayerPrefs.GetString("PlayerRegister"), costSkins));
    }

    public void SelectSkin(string nameSkin)
    {
        for (int i = 0; i< selectSkin.Length; i++)
        {
            if(nameSkin == skinName[i].name)
            {
                selectSkin[i].interactable = false;
                skinWasSelect[i].gameObject.SetActive(true);
                PlayerPrefs.SetString("SelectNowSkin", nameSkin);
            }
            else
            {
                selectSkin[i].interactable = true;
                skinWasSelect[i].gameObject.SetActive(false);
            }
        }
    }

    #endregion Public Methods

}
