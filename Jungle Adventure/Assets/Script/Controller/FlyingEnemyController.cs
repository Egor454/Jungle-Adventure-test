using UnityEngine;

public class FlyingEnemyController 
{
    #region Private Fields

    private FlyingEnemyView flyingEnemyView { get; set; }
    private FlyingEnemyModel enemyModel { get; set; }
    private GameController game;

    #endregion Private Fields

    #region Public Methods

    public FlyingEnemyController(FlyingEnemyView flyingEnemyViews,FlyingEnemyModel model,GameController game)
    {

        this.flyingEnemyView = flyingEnemyViews;
        this.enemyModel = model;
        this.game = game;


        flyingEnemyView.MoveFlyingEnemy += MoveEnemyModel;
        enemyModel.ChangedEnemyPositionModel += MoveEnemyView;

        flyingEnemyView.DamageToPlayer += DamageToPlayerModel;
        enemyModel.SendDamageToPlayer += SendDamageToPlayerModel;
    }

    #endregion Public Methods

    #region Private Methods

    private void MoveEnemyModel(bool enemy)
    {
        enemyModel.ChangePositionEnemy(enemy);
    }

    private void MoveEnemyView(float enemyMove)
    {
        flyingEnemyView.MoveEnemyPosition(enemyMove);
    }

    private void DamageToPlayerModel()
    {
        enemyModel.SendDamageEnemy();
    }

    private void SendDamageToPlayerModel(int damage)
    {
        game.SendDamageToPlayer(damage);
    }

    #endregion Private Methods
}
