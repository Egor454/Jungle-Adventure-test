using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopView : MonoBehaviour
{

    #region SerializedField

    [SerializeField] private Text[] skinname;
    [SerializeField] private Text[] costSkin;
    [SerializeField] private Image[] imageSkin;
    [SerializeField] private Text coinPlayerText;

    #endregion SerializedField

    #region Private Fields



    #endregion Private Fields

    #region UnityAction

    public event UnityAction GetSkinData;

    #endregion UnityAction

    #region Private Methods

    void Start()
    {
        GetSkinData?.Invoke();
    }

    void Update()
    {

    }

    #endregion Private Methods

    #region Public Methods

    public void LoadData(Skins skin)
    {
        for(int i = 0; i < skinname.Length;i++)
        {
            for ( int j = 0; j < skinname.Length; j++)
            {
                string name = skinname[i].name.ToString();
                if (name == skin.skin[j].Name)
                {
                    skinname[i].text = skin.skin[j].Name;
                    costSkin[i].text = skin.skin[j].Cost.ToString();
                    imageSkin[i].GetComponent<Image>().sprite = (Sprite)Resources.Load("Image/ImageForShop/ForShop" + skin.skin[j].Name, typeof(Sprite));
                }
            }
        }
        coinPlayerText.text = DbManager.Instance.CoinPlayer.ToString();
    }

    #endregion Public Methods

}
