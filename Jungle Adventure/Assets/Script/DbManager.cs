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
    public IEnumerator SendLevelCompleted(string level_name, string player_name)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("Level", level_name);
            form.AddField("NamePlayer", player_name);
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
    public IEnumerator GetLevel()
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
                string level_name = "level" + i;
                WWWForm form = new WWWForm();
                form.AddField("LevelGet", level_name);
                UnityWebRequest uwr = UnityWebRequest.Post(url, form);
                yield return uwr.SendWebRequest();
                if (uwr.isNetworkError)
                {
                    Debug.Log("Ошибка: " + uwr.error);
                }
                else
                {
                    Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                    level.Add(uwr.downloadHandler.text);
                }
            }
          
        }
        
    }
   
    public void ClearData()
    {
        level.Clear();
    }
    
}
