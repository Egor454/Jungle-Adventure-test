using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class PlayerInitialization : MonoBehaviour
{
    #region UserInit

    string url = "http://a81985.hostru06.fornex.host/jungledb.ru/DB/Index.php";
    void Start()
    {
        //PlayerPrefs.DeleteKey("PlayerRegister");
        if (!PlayerPrefs.HasKey("PlayerRegister"))
        {
            System.Random rnd = new System.Random();
            int value = rnd.Next(0, 100000);
            string namePlayer = "Player" + value;
            StartCoroutine(SendUser(namePlayer, 0));
            PlayerPrefs.SetString("SelectNowSkin", "Default");
        }

    }
    public IEnumerator SendUser(string playerName, int money)
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
                if (uwr.downloadHandler.text == "Пользователь существует")
                {
                    System.Random rnd = new System.Random();
                    int value = rnd.Next(0, 100000);
                    string namePlayer = "Player" + value;
                    StartCoroutine(SendUser(namePlayer, 0));
                }
                else
                {
                    PlayerPrefs.SetString("PlayerRegister", playerName);
                }
            }
        }

    }

    #endregion UserInit
}
