using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] groundEnemyPrefab;
    [SerializeField] private GameObject[] flyingEnemyPrefab;
    private PlayerController playerController;
    private PlayerModel playerModel;
    private GroundEnemyModel groundEnemyModel;
    private GroundEnemyController groundenemyController;
    private FlyingEnemyModel flyingEnemyModel;
    private FlyingEnemyController FlyingEnemyController;

    public void Start()
    {
        groundEnemyModel = new GroundEnemyModel();
        playerModel = new PlayerModel();
        flyingEnemyModel = new FlyingEnemyModel();

        var playerView = playerPrefab.GetComponent<PlayerView>();

        foreach(GameObject objet in groundEnemyPrefab){
            var groundEnemyView = objet.GetComponent<GroundEnemyView>();
            groundenemyController = new GroundEnemyController(groundEnemyView, groundEnemyModel);
        }
        foreach (GameObject objet in flyingEnemyPrefab)
        {
            var flyingEnemyView = objet.GetComponent<FlyingEnemyView>();
            FlyingEnemyController = new FlyingEnemyController(flyingEnemyView, flyingEnemyModel);
        }
        playerController = new PlayerController(playerView, playerModel);
    }

        
        

}
