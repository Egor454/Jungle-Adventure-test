using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject LevelSelection;

    [SerializeField] private Image[] LevelGame;

    int i;
    void Start()
    {
        GetComplitedLevel();
    }
    public void ClickLevelSelection()
    {
        LevelSelection.SetActive(true);
        Menu.SetActive(false);
        for (i = 0; i < DbManager.Instance.Level.Count; i++)
        {
            if (DbManager.Instance.Level[i] == "1")
            {
                if( i == DbManager.Instance.Level.Count - 1)
                {
                    break;
                }
                else
                {
                    LevelGame[i + 1].GetComponent<Image>().sprite = (Sprite)Resources.Load("Image/MenuImage/MenuLevel" + (i + 2), typeof(Sprite));
                    LevelGame[i + 1].GetComponent<Button>().interactable = true;
                }
            }
        }
        DbManager.Instance.ClearData();
        //i = 0;
    }
    public void ClickBackMenu()
    {
        LevelSelection.SetActive(false);
        Menu.SetActive(true);
    }
    public void LoadedLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadedLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadedLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void GetComplitedLevel()
    {
        StartCoroutine(DbManager.Instance.GetLevel(PlayerPrefs.GetString("PlayerRegister")));
    }
}
