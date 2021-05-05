using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;

public class DbManager : MonoBehaviourSingleton<DbManager>
{
    string url = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Index.php";
    string urlGetShop = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/shopGet.php";
    string urlShop = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Shop.php";

    #region Private Fields

    private List<string> level;
    private bool playerHasBeenAdded = false;
    private Skins skin;
    private int coinPlayer;
    private List<string> playerBuythisSkin;

    #endregion Private Fields

    #region Public Fields

    public List<string> Level => level;
    public bool PlayerHasBeenAdded => playerHasBeenAdded;
    public Skins Skins => skin;
    public int CoinPlayer => coinPlayer;
    public List<string> PlayerBuythisSkin => playerBuythisSkin;

    #endregion Public Fields

    #region Private Methods

    private void Start()
    {
        level = new List<string>();
        skin = new Skins();
        playerBuythisSkin = new List<string>();
    }

    #endregion Private Methods

    #region Public Methods

    public IEnumerator SendLevelCompleted(string levelName, string playerNname)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("Level", levelName);
            form.AddField("NamePlayer", playerNname);
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
            }
        }

    }
    public IEnumerator GetLevel( string playerName)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");
            for (int i = 1; i < 5; i++)
            {
                string levelName = "level" + i;
                WWWForm form = new WWWForm();
                form.AddField("PlayerCompletedLevel", playerName);
                form.AddField("CompletedLevelName", levelName);
                UnityWebRequest uwr = UnityWebRequest.Post(url, form);
                yield return uwr.SendWebRequest();
                if (uwr.isNetworkError)
                {
                    Debug.Log("Ошибка: " + uwr.error);
                }
                else
                {
                    Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                    if(uwr.downloadHandler.text == "Уровень пройден")
                    {
                        level.Add("1");
                    }
                    else
                    {
                        level.Add("0");
                    }
                }
            }
          
        }
        
    }
    public IEnumerator SendRecord(string levelName, string playerName ,string time, int coin, int score)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("SendLevelRecord", levelName);
            form.AddField("SendPlayerRecord", playerName);
            form.AddField("SendTimeRecord", time);
            form.AddField("SendCoinRecord", coin);
            form.AddField("SendScoreRecord", score); 
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
            }
        }

    }
    public void ClearData()
    {
        level.Clear();
    }
    public IEnumerator UpdateMoneyPlayer(string playerName, int money)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("playerNameForMoney", playerName);
            form.AddField("Money", money);
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);  
            }
        }

    }

    public IEnumerator GetAllSkin()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            UnityWebRequest uwr = UnityWebRequest.Get(urlGetShop);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                skin = JsonUtility.FromJson<Skins>(uwr.downloadHandler.text);
            }
        }

    }
    public IEnumerator GetCoinPlayer(string playerName)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("Player_Set", playerName);
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                coinPlayer = int.Parse(uwr.downloadHandler.text);
            }
        }

    }

    public IEnumerator GetSkinBuyPlayer(string playerName)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");
            for (int i = 0; i < 2; i++)
            {
                WWWForm form = new WWWForm();
                form.AddField("PlayerName", playerName);
                UnityWebRequest uwr = UnityWebRequest.Post(urlShop, form);
                yield return uwr.SendWebRequest();
                if (uwr.isNetworkError)
                {
                    Debug.Log("Ошибка: " + uwr.error);
                }
                else
                {
                    Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                    if(uwr.downloadHandler.text != "" )
                    {
                        if (playerBuythisSkin.Count == 0)
                        {
                            playerBuythisSkin.Add(uwr.downloadHandler.text);
                        }
                        else
                        {
                            for (int j = 0; j < playerBuythisSkin.Count; j++)
                            {
                                if (playerBuythisSkin[j] != uwr.downloadHandler.text)
                                    playerBuythisSkin.Add(uwr.downloadHandler.text);
                            }
                        }
                    }
                }
            }
        }

    }

    public IEnumerator BuySkin(string playerName, int idSkin)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");
            for (int i = 0; i < 2; i++)
            {
                WWWForm form = new WWWForm();
                form.AddField("PlayerNameWhoBuy", playerName);
                form.AddField("IdSkin", idSkin);
                UnityWebRequest uwr = UnityWebRequest.Post(urlShop, form);
                yield return uwr.SendWebRequest();
                if (uwr.isNetworkError)
                {
                    Debug.Log("Ошибка: " + uwr.error);
                }
                else
                {
                    Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                   
                }
            }
        }

    }

    #endregion Public Methods
}
