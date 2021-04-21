﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] groundEnemyPrefab;
    [SerializeField] private GameObject[] flyingEnemyPrefab;

    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [SerializeField] private Text amountCoin_text;
    [SerializeField] private Text amountScore_text;

    [SerializeField] private Text EndLevelCoin_text;
    [SerializeField] private Text EndLevelScore_text;
    [SerializeField] private Text EndLevelTime_text;

    [SerializeField] private Text DieCoin_text;
    [SerializeField] private Text DieScore_text;
    [SerializeField] private Text DieTime_text;

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject UiGame;
    [SerializeField] private GameObject MassageBoxGameOver;
    [SerializeField] private GameObject MassageBoxCompliteLevel;

    private PlayerController playerController;
    private PlayerModel playerModel;
    private GroundEnemyModel groundEnemyModel;
    private GroundEnemyController groundenemyController;
    private FlyingEnemyModel flyingEnemyModel;
    private FlyingEnemyController FlyingEnemyController;
    private int coin;
    private int score;
    private int sceneIndex;

    private float GameSeconds = 0.0f;
    private float GameMinutes = 0.0f;
    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        playerModel = new PlayerModel();

        var playerView = playerPrefab.GetComponent<PlayerView>();
        foreach (GameObject objet in groundEnemyPrefab)
        {
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
        amountScore_text.text = score.ToString();
        GameSeconds = GameSeconds + Time.deltaTime;
        if (GameSeconds >= 60.0f)
        {
            GameMinutes = GameMinutes + 1.0f;
            GameSeconds = 0.0f;
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
        if (collision.gameObject.name == "Crab_Enemy" || collision.gameObject.name == "Thing_Enemy")
        {
            score += 100;
        }
        else if (collision.gameObject.name == "Octopus_Enemy" || collision.gameObject.name == "Ghost_Enemy")
        {
            score += 200;
        }
        Destroy(enemy, 0.1f);
    }
    public void GameOver()
    {
        camera.transform.position = new Vector2(transform.position.x + 100.5f, transform.position.y + 50.5f);
        UiGame.SetActive(false);
        MassageBoxGameOver.SetActive(true);

        DieTime_text.text = GameMinutes + ":" + GameSeconds;
        DieCoin_text.text = coin.ToString();
        DieScore_text.text = score.ToString();
    }
    public void LevelComplited()
    {
        camera.transform.position = new Vector2(transform.position.x + 100.5f, transform.position.y + 50.5f);
        UiGame.SetActive(false);
        MassageBoxCompliteLevel.SetActive(true);

        EndLevelTime_text.text = GameMinutes + ":" + GameSeconds;
        EndLevelCoin_text.text = coin.ToString();
        EndLevelScore_text.text = score.ToString();
        //StartCoroutine(DbManager.Instance.SendLevel("level" + (sceneIndex + 1), "1")); 
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackMainScreen()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
