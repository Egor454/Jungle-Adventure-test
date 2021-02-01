using UnityEngine;

public class FlyingEnemyController 
{
    private FlyingEnemyView flyingEnemyView { get; set; }
    private FlyingEnemyModel enemyModel { get; set; }

    public FlyingEnemyController(FlyingEnemyView flyingEnemyView,FlyingEnemyModel model)
    {

        this.flyingEnemyView = flyingEnemyView;
        this.enemyModel = model;


        flyingEnemyView.MoveFlyingEnemy += MoveEnemyModel;
        enemyModel.ChangedEnemyPositionModel += MoveEnemyView;
    }
    private void MoveEnemyModel(bool enemy)
    {
        enemyModel.ChangePositionEnemy(enemy);
    }
    private void MoveEnemyView(float enemyMove)
    {
        flyingEnemyView.MoveEnemyPosition(enemyMove);
    }
}
