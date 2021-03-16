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

    [SerializeField] private Text amountCoin_text;

    private PlayerController playerController;
    private PlayerModel playerModel;
    private GroundEnemyModel groundEnemyModel;
    private GroundEnemyController groundenemyController;
    private FlyingEnemyModel flyingEnemyModel;
    private FlyingEnemyController FlyingEnemyController;
    private int coin;

    public void Start()
    {
        playerModel = new PlayerModel();

        var playerView = playerPrefab.GetComponent<PlayerView>();
        foreach (GameObject objet in groundEnemyPrefab){
            groundEnemyModel = new GroundEnemyModel();
            var groundEnemyView = objet.GetComponent<GroundEnemyView>();
            groundenemyController = new GroundEnemyController(groundEnemyView, groundEnemyModel);
        }
        foreach (GameObject objet in flyingEnemyPrefab)
        {
            flyingEnemyModel = new FlyingEnemyModel();
            var flyingEnemyView = objet.GetComponent<FlyingEnemyView>();
            FlyingEnemyController = new FlyingEnemyController(flyingEnemyView, flyingEnemyModel);
        }
        playerController = new PlayerController(playerView, playerModel);
        playerView.Iniinitialization(this);
    }
    private void Update()
    {
        amountCoin_text.text = coin.ToString();
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
    public void ChangeHeartOnScreen(int hp)
    {
        if( hp == 3)
        {
            heart1.color = new Color(1f, 1f, 1f, 1f);
        }
        if (hp == 2)
        {
            heart2.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    public void DestroyHealthPotion(Collider2D collision)
    {
        Destroy(collision.gameObject, 0.1f);
    }
    public void DeathPlayer()
    {
        heart1.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        heart2.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        heart3.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void СollectingСoins(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject, 0.1f);
            coin++;
        }
        if (collision.gameObject.tag == "Chest")
        {
            coin += 5;
        }

    }
    public void KillTheEnemy(Collision2D collision)
    {
        GameObject enemy = collision.transform.parent.gameObject;
        //enemy.SetActive(false);
        Destroy(enemy, 0.1f);
    }
}
