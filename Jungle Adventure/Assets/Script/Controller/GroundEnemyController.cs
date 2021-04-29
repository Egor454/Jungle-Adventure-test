using UnityEngine;

public class GroundEnemyController
{
    private GroundEnemyView groundEnemyView { get; set; }
    private GroundEnemyModel enemyModel { get; set; }
    private GameController game;

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
}
