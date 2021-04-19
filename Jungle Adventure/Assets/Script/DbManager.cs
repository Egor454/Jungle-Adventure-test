using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DbManager : MonoBehaviourSingleton<DbManager>
{
    string url = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Index.php";

    private List<string> level;
    private int playerNumbers = 0;
    private int numberPlayers;
    private float lineEnd;
    private float lineEnd2;
    private int scoreEnd2;
    private int playersFinished;


    public List<string> Level => level;
    public int NumberPlayers => numberPlayers;
    public float LineEnd => lineEnd;
    public float LineEnd2 => lineEnd2;
    public int ScoreEnd2 => scoreEnd2;
    public int PlayersFinished => playersFinished;
    public int PlayerNumbers => playerNumbers;

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
    public void ClearData()
    {
        level.Clear();
    }
}
