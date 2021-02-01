using UnityEngine;

public class GroundEnemyController
{
    private GroundEnemyView groundEnemyView { get; set; }
    private GroundEnemyModel enemyModel { get; set; }


    public GroundEnemyController(GroundEnemyView groundEnemyView, GroundEnemyModel model)
    {
        this.groundEnemyView = groundEnemyView;
        this.enemyModel = model;

        groundEnemyView.MoveGroundEnemy += MoveEnemyModel;
        enemyModel.ChangedEnemyPositionModel += MoveEnemyView;
    }
    private void MoveEnemyModel(bool enemy)
    {
        enemyModel.ChangePositionEnemy(enemy);
    }
    private void MoveEnemyView(float enemyMove)
    {
        groundEnemyView.MoveEnemyPosition(enemyMove);
    }
}
