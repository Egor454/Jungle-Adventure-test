
public class GroundEnemyController
{
    #region Private Fields

    private GroundEnemyView groundEnemyView { get; set; }
    private GroundEnemyModel enemyModel { get; set; }
    private GameController game;

    #endregion Private Fields

    #region Public Methods

    public GroundEnemyController(GroundEnemyView groundEnemyView, GroundEnemyModel model, GameController game)
    {
        this.groundEnemyView = groundEnemyView;
        this.enemyModel = model;
        this.game = game;

        groundEnemyView.MoveGroundEnemy += MoveEnemyModel;
        enemyModel.ChangedEnemyPositionModel += MoveEnemyView;

        groundEnemyView.DamageToPlayer += DamageToPlayerModel;
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
        groundEnemyView.MoveEnemyPosition(enemyMove);
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
