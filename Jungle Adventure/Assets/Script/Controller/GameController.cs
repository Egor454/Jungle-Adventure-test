using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject groundEnemyPrefab;
    private PlayerController playerController;
    private PlayerModel playerModel;
    private EnemyModel enemyModel;
    private EnemyController enemyController;
    //private PlayerView playerView;

    public void Start()
    {
        enemyModel = new EnemyModel();
        playerModel = new PlayerModel();


        var playerView = playerPrefab.GetComponent<PlayerView>();
        var groundEnemyView = groundEnemyPrefab.GetComponent<GroundEnemyView>();

        playerController = new PlayerController(playerView, playerModel);
        enemyController = new EnemyController(groundEnemyView, enemyModel);
    }

}
