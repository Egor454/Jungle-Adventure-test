using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopModel
{
    #region Private Fields

    private Skins skin;

    #endregion Private Fields

    #region UnityAction

    public event UnityAction<Skins> SendSkin;
    public event UnityAction<int,int> SendDataskinWasBuy;

    #endregion UnityAction

    #region Public Methods

    public ShopModel()
    {
        skin = DbManager.Instance.Skins;
    }

    public void SendSkinData()
    {
        SendSkin?.Invoke(skin);
    }

    public void SendIdSkin(string nameSkin)
    {
        for(int i = 0; i <skin.skin.Length; i++)
        {
            if(nameSkin == skin.skin[i].Name)
            {
                SendDataskinWasBuy?.Invoke(skin.skin[i].id, skin.skin[i].Cost);
            }
        }
    }

    #endregion Public Methods
}
