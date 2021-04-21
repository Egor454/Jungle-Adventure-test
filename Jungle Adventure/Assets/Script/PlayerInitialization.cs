using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInitialization : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteKey("PlayerRegister");
        if (!PlayerPrefs.HasKey("PlayerRegister"))
        {
            System.Random rnd = new System.Random();
            int value = rnd.Next(0, 100000);
            string namePlayer = "Player25218";
            StartCoroutine(DbManager.Instance.SendUser(namePlayer, 0));
            if (DbManager.Instance.PlayerHasBeenAdded)
            {
                PlayerPrefs.SetString("PlayerRegister", namePlayer);
            }

        }

    }
}
