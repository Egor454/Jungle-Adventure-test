using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController 
{
    private BossEnemyView bossEnemyView { get; set; }
    private BossEnemyModel bossEnemyModel { get; set; }
    private GameController game;

    public BossEnemyController(BossEnemyView bossEnemyViews, BossEnemyModel bossEnemyModels, GameController game)
    {

        this.bossEnemyView = bossEnemyViews;
        this.bossEnemyModel = bossEnemyModels;
        this.game = game;


        bossEnemyView.ColisionPlayer += ColisionPlayerModel;
        bossEnemyModel.SendDamagePlayer += SendDamagePlayer;

        bossEnemyView.BossDeath += BossDeath;

        bossEnemyView.BossAttacked += BossAttackedModel;
        bossEnemyView.BossBackPosition += BossBackPositionModel;

        bossEnemyModel.SendSpeedBoss += SendSpeedBossView;

    }
    private void ColisionPlayerModel()
    {
        bossEnemyModel.CollisonPlayerGet();
    }
    private void SendDamagePlayer(int damage)
    {
        game.SendDamageToPlayer(damage);
    }
    private void BossDeath(GameObject gameObject)
    {
        game.DeathBoss(gameObject);
    }
    private void BossAttackedModel()
    {
        bossEnemyModel.SendSpeedToMoving();
    }
    private void BossBackPositionModel()
    {
        bossEnemyModel.SendSpeedToMoving();
    }
    private void SendSpeedBossView(float speed)
    {
        bossEnemyView.MovingBoss(speed);
    }
}
