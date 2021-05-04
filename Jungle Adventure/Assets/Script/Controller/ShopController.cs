using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController
{
    #region Private Fields

    private ShopView shopView { get; set; }
    private ShopModel shopModel { get; set; }

    #endregion Private Fields

    #region Public Methods

    public ShopController(ShopView view, ShopModel model)
    {
        this.shopView = view;
        this.shopModel = model;

        shopView.GetSkinData += GetSkinDataModel;
        shopModel.SendSkin += SendSkinDataView;
    }

    public void GetSkinDataModel()
    {
        shopModel.SendSkinData();
    }

    public void SendSkinDataView(Skins skin)
    {
        shopView.LoadData(skin);
    }

    #endregion Public Methods
}
