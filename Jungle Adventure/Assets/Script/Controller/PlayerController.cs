using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView { get; set; }
    private PlayerModel playerModel { get; set; }

    public PlayerController(PlayerView view, PlayerModel model)
    {
        this.playerView = view;
        this.playerModel = model;
        playerView.GetHelthPlayer += GetHealthModel;
        playerModel.SetHealth += GetHealthView;

        playerView.ChangedPosition += ChangePositionModel;
        playerModel.ChangedPositionModel += ChangePositionView;
        playerView.GetDamage += ChangeHealthModel;
        playerModel.GetHealth += GetHealthView;
    }
    private void GetHealthModel()
    {
        playerModel.GetHealthModel();
    }

    private void ChangePositionModel(float moveInput)
    {
        playerModel.ChangePosition(moveInput);
    }
    private void ChangePositionView(float playerMove)
    {
        playerView.ChangePositionView(playerMove);
    }
    private void ChangeHealthModel()
    {
        playerModel.ChangeHealth();

    }
    private void GetHealthView(int health)
    {
        playerView.GetHealth(health);
    }
}
