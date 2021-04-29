using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] groundEnemyPrefab;
    [SerializeField] private GameObject[] flyingEnemyPrefab;
    [SerializeField] private GameObject[] groundPrefab;
    [SerializeField] private GameObject bossPrefab;

    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [SerializeField] private Text amountCoin_text;
    [SerializeField] private Text amountScore_text;

    [SerializeField] private Text endLevelCoin_text;
    [SerializeField] private Text endLevelScore_text;
    [SerializeField] private Text endLevelTime_text;

    [SerializeField] private Text dieCoin_text;
    [SerializeField] private Text dieScore_text;
    [SerializeField] private Text dieTime_text;

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject uiGame;
    [SerializeField] private GameObject massageBoxGameOver;
    [SerializeField] private GameObject massageBoxCompliteLevel;

    private PlayerController playerController;
    private PlayerModel playerModel;
    private GroundEnemyModel groundEnemyModel;
    private GroundEnemyController groundEnemyController;
    private FlyingEnemyModel flyingEnemyModel;
    private FlyingEnemyController flyingEnemyController;
    private GroundController groundController;
    private GroundModel groundModel;
    private GroundView groundView;

    private int coin;
    private int score;
    private int sceneIndex;

    private float gameSeconds = 0.0f;
    private float gameMinutes = 0.0f;

    private bool enemyWasKill = false;
    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        playerModel = new PlayerModel();

        var playerView = playerPrefab.GetComponent<PlayerView>();
        foreach (GameObject objet in groundEnemyPrefab)
        {
            groundEnemyModel = new GroundEnemyModel();
            var groundEnemyView = objet.GetComponent<GroundEnemyView>();
            groundEnemyController = new GroundEnemyController(groundEnemyView, groundEnemyModel,this);
        }
        foreach (GameObject objet in flyingEnemyPrefab)
        {
            flyingEnemyModel = new FlyingEnemyModel();
            var flyingEnemyView = objet.GetComponent<FlyingEnemyView>();
            flyingEnemyController = new FlyingEnemyController(flyingEnemyView, flyingEnemyModel,this);
        }
        playerController = new PlayerController(playerView, playerModel);
        playerView.Iniinitialization(this);

        if(sceneIndex == 4)
        {
            foreach (GameObject objet in groundPrefab)
            {
                groundModel = new GroundModel();
                groundView = objet.GetComponent<GroundView>();
                groundController = new GroundController(groundView, groundModel);
                groundView.Iniinitialization(this);
            }
            var bossEnemy = bossPrefab.GetComponent<BossEnemy>();
            bossEnemy.Iniinitialization(this);
        }
    }
    private void Update()
    {
        amountCoin_text.text = coin.ToString();
        amountScore_text.text = score.ToString();
        gameSeconds = gameSeconds + Time.deltaTime;
        if (gameSeconds >= 60.0f)
        {
            gameMinutes = gameMinutes + 1.0f;
            gameSeconds = 0.0f;
        }

    }
    public void ChangeHp(int hp)
    {
        if (hp == 2)
        {
            heart1.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
        if (hp == 1)
        {
            heart2.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
        if (hp == 0)
        {
            heart3.color = new Color(0.12f, 0.6f, 0.35f, 1f);
        }
    }
    public void ChangeHeartOnScreen(int hp)
    {
        if (hp == 3)
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
        Destroy(playerPrefab, 0.1f);
        GameOver();
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
        if (collision.gameObject.name == "Crab_Enemy" || collision.gameObject.name == "Thing_Enemy" || collision.gameObject.name == "Skeleton_Enemy")
        {
            score += 100;
        }
        else if (collision.gameObject.name == "Octopus_Enemy" || collision.gameObject.name == "Ghost_Enemy" || collision.gameObject.name == "GhostNight_Enemy")
        {
            score += 200;
        }
        Destroy(enemy);
        enemyWasKill = true;
    }
    public void GameOver()
    {
        camera.transform.position = new Vector2(transform.position.x + 100.5f, transform.position.y + 50.5f);
        uiGame.SetActive(false);
        massageBoxGameOver.SetActive(true);

        dieTime_text.text = gameMinutes + ":" + gameSeconds;
        dieCoin_text.text = coin.ToString();
        dieScore_text.text = score.ToString();
    }
    public void LevelComplited()
    {
        camera.transform.position = new Vector2(transform.position.x + 100.5f, transform.position.y + 50.5f);
        uiGame.SetActive(false);
        massageBoxCompliteLevel.SetActive(true);

        endLevelTime_text.text = gameMinutes + ":" + gameSeconds;
        endLevelCoin_text.text = coin.ToString();
        endLevelScore_text.text = score.ToString();
        string playerName = PlayerPrefs.GetString("PlayerRegister");
        //StartCoroutine(DbManager.Instance.SendLevelCompleted("Level" + sceneIndex , playerName)); 
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackMainScreen()
    {
        if (massageBoxCompliteLevel.activeSelf)
        {
            StartCoroutine(DbManager.Instance.SendRecord("Level" + sceneIndex, PlayerPrefs.GetString("PlayerRegister"), gameMinutes + ":" + gameSeconds, coin, score));
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

    }
    public void NextLevel()
    {
        StartCoroutine(DbManager.Instance.SendRecord("Level" + sceneIndex, PlayerPrefs.GetString("PlayerRegister"), gameMinutes + ":" + gameSeconds, coin, score));
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void DestroyGround(GameObject grounds)
    {
        GameObject ground = grounds.transform.parent.gameObject;
        Destroy(ground, 0.1f);
    }
    public void DeathBoss(GameObject boss)
    {
        Destroy(boss, 0.1f);
        LevelComplited();
    }
    public void SendDamageToPlayer(int damage)
    {
        if (!enemyWasKill)
        {
            playerController.ChangeHealthModel(damage);
        }
        enemyWasKill = false;
    }

}
