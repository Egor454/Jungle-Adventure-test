
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

        shopView.SkinWasBuy += SkinWasBuyModel;
        shopModel.SendDataskinWasBuy += BuySkinView;

    }

    public void GetSkinDataModel()
    {
        shopModel.SendSkinData();
    }

    public void SendSkinDataView(Skins skin)
    {
        shopView.LoadData(skin);
    }

    public void SkinWasBuyModel(string nameSkin)
    {
        shopModel.SendIdSkin(nameSkin);
    }

    public void BuySkinView(int idSkin, int costSkin)
    {
        shopView.SendDataAboutBuySkin(costSkin, idSkin);
    }

    #endregion Public Methods
}
