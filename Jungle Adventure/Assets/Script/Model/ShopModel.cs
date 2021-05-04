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

    #endregion Public Methods
}
