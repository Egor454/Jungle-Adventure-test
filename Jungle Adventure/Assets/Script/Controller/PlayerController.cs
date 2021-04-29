using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView { get; set; }
    private PlayerModel playerModel { get; set; }

    public PlayerController(PlayerView view, PlayerModel model)
    {
        this.playerView = view;
        this.playerModel = model;

        playerView.DeathPlayer += DeathPlayerModel;

        playerView.ChangedPosition += ChangePositionModel;
        playerModel.ChangedPositionModel += ChangePositionView;

        playerView.GetDamagePlatform += GetDamagePlatformModel;
        playerModel.GetHealth += GetHealthView;

        playerView.HealPlayer += HealPlayerModel;
        playerModel.UpgradeTheAmountOfHealth += UpgradeTheAmountOfHealthView;

        playerModel.PlayerDeath += PlayerDeathView;
    }

    private void DeathPlayerModel()
    {
        playerModel.Death();
    }
    private void ChangePositionModel(float moveInput)
    {
        playerModel.ChangePosition(moveInput);
    }
    private void ChangePositionView(float playerMove)
    {
        playerView.ChangePositionView(playerMove);
    }
    public void ChangeHealthModel(int damage)
    {
        playerModel.ChangeHealth(damage);
    }
    private void GetDamagePlatformModel()
    {
        playerModel.GetDamagePlatform();
    }
    private void GetHealthView(int hp)
    {
        playerView.GetHealth(hp);
    }
    private void HealPlayerModel()
    {
         playerModel.GetHealthPotion();
    }
    private void UpgradeTheAmountOfHealthView(int hp)
    {
        playerView.UpdateHealth(hp);
    }
    private void PlayerDeathView()
    {
        playerView.Death();
    }
}
