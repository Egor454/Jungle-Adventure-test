using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;

public class DbManager : MonoBehaviourSingleton<DbManager>
{
    string url = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Index.php";

    private List<string> level;
    private bool playerHasBeenAdded = false;

    public List<string> Level => level;
    public bool PlayerHasBeenAdded => playerHasBeenAdded;

    private void Start()
    {
        level = new List<string>();
    }
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
}
