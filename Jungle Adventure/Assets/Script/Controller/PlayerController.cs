using UnityEngine;

public class PlayerController 
{
    private PlayerView playerView { get; set; }
    private PlayerModel playerModel { get; set; }

    public PlayerController(PlayerView view, PlayerModel model)
    {
        this.playerView = view;
        this.playerModel = model;

        playerView.ChangedPosition += ChangePosition;
        playerModel.ChangedPositionModel += ChangePositionView;
    }
    private void ChangePosition(float moveInput)
    {
        playerModel.ChangePosition(moveInput);
    }
    private void ChangePositionView(float playerMove)
    {
        playerView.ChangePositionView(playerMove);
    }
}
