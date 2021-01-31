using UnityEngine;

public class EnemyController
{
    private GroundEnemyView groundEnemyView { get; set; }
    private EnemyModel enemyModel { get; set; }

    public EnemyController(GroundEnemyView view, EnemyModel model)
    {
        this.groundEnemyView = view;
        this.enemyModel = model;

        groundEnemyView.MoveEnemy += MoveEnemyModel;
        enemyModel.ChangedEnemyPositionModel += MoveEnemyView;
    }
    private void MoveEnemyModel(bool enemy)
    {
        enemyModel.ChangePositionEnemy(enemy);
    }
    private void MoveEnemyView(float playerMove)
    {
        groundEnemyView.MoveEnemyPosition(playerMove);
    }
}
