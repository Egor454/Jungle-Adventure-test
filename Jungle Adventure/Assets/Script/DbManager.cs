using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DbManager : MonoBehaviour
{
    string url = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Index.php";
    public string level_name;
    public string comlited;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Send());
    }

    private IEnumerator Send()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet access");
        }
        else
        {
            Debug.Log("internet connection");
        }
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
