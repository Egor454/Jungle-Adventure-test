using UnityEngine;

public class PlayerController
{
    #region Private Fields

    private PlayerView playerView { get; set; }
    private PlayerModel playerModel { get; set; }
    private GameController game;

    #endregion Private Fields

    #region Public Methods

    public PlayerController(PlayerView view, PlayerModel model, GameController games)
    {
        this.playerView = view;
        this.playerModel = model;
        this.game = games;

        playerView.DeathPlayer += DeathPlayerModel;

        playerView.ChangedPosition += ChangePositionModel;
        playerModel.ChangedPositionModel += ChangePositionView;

        playerView.GetDamagePlatform += GetDamagePlatformModel;
        playerModel.GetHealth += GetHealthView;

        playerView.HealPlayer += HealPlayerModel;
        playerModel.UpgradeTheAmountOfHealth += UpgradeTheAmountOfHealthView;

        playerModel.PlayerDeath += PlayerDeathView;

        playerView.PlayerTakeCoin += TakeCoinPlayer;
        playerView.PlayerEnteredThePortal += PlayerComplitedLevel;
        playerView.PlayerKillEnemy += DestroyEnemy;
    }

    public void ChangeHealthModel(int damage)
    {
        playerModel.ChangeHealth(damage);
    }

    public void DownRightButton()
    {
        playerView.OnRightButtonDown();
    }

    public void DownLeftButton()
    {
        playerView.OnLeftButtonDown();
    }

    public void UpButton()
    {
        playerView.OnButtonUp();
    }

    public void JumpButton()
    {
        playerView.ButtonJump();
    }

    #endregion Public Methods

    #region Private Methods

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

    private void GetDamagePlatformModel()
    {
        playerModel.GetDamagePlatform();
    }

    private void GetHealthView(int hp)
    {
        game.ChangeHp(hp);
        playerView.EnableInvulnerability();
    }

    private void HealPlayerModel(Collider2D collision)
    {
        playerModel.GetHealthPotion(collision);
    }

    private void UpgradeTheAmountOfHealthView(int hp, Collider2D collision)
    {
        game.ChangeHeartOnScreen(hp);
        game.DestroyHealthPotion(collision);
    }

    private void PlayerDeathView()
    {
        game.DeathPlayer();
    }

    private void TakeCoinPlayer(Collider2D collider)
    {
        game.СollectingСoins(collider);
    }
    private void PlayerComplitedLevel()
    {
        game.LevelComplited();
    }

    private void DestroyEnemy(Collision2D other)
    {
        game.KillTheEnemy(other);
    }

    #endregion Private Methods
}
