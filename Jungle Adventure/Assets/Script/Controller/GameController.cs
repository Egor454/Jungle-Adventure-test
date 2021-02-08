using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] groundEnemyPrefab;
    [SerializeField] private GameObject[] flyingEnemyPrefab;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
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
        playerView.Iniinitialization(this);
    }
    public void ChangeHp(int hp)
    {
        if(hp == 2)
        {
            heart1.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
        if(hp == 1)
        {
            heart2.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
        if(hp == 0)
        {
            heart3.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
    }
     public void DeathPlayer()
    {
        heart1.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        heart2.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        heart3.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
        

}
