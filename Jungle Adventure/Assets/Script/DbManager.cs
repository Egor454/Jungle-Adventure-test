using System.Collections;
using System.Collections.Generic;
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
    public IEnumerator SendLevel(string level_name, string comlited)
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
            form.AddField("Complited", comlited);
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
    public IEnumerator SendUser(string player_name, int money)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");

            WWWForm form = new WWWForm();
            form.AddField("Player_Set", player_name);
            form.AddField("Money_Set", money);
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.Log("Ошибка: " + uwr.error);
            }
            else
            {
                Debug.Log("Сервер ответил: " + uwr.downloadHandler.text);
                if(uwr.downloadHandler.text == "Успех. Пользователь добавлен")
                {
                    playerHasBeenAdded = true;
                }
            }
        }

    }
    public void ClearData()
    {
        level.Clear();
    }
}
