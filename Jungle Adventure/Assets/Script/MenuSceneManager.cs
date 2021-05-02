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
    private int sceneIndex;

    int i;
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        GetComplitedLevel();
        AudioManager.Instance.FonMusic(sceneIndex);
    }
    public void ClickLevelSelection()
    {
        LevelSelection.SetActive(true);
        Menu.SetActive(false);
        AudioManager.Instance.ButtonClick();
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
        AudioManager.Instance.ButtonClick();
        LevelSelection.SetActive(false);
        Menu.SetActive(true);
    }
    public void LoadedLevel1()
    {
        AudioManager.Instance.ButtonClick();
        SceneManager.LoadScene("Level1");
    }
    public void LoadedLevel2()
    {
        AudioManager.Instance.ButtonClick();
        SceneManager.LoadScene("Level2");
    }
    public void LoadedLevel3()
    {
        AudioManager.Instance.ButtonClick();
        SceneManager.LoadScene("Level3");
    }
    public void LoadedLevel4()
    {
        AudioManager.Instance.ButtonClick();
        SceneManager.LoadScene("Level4");
    }
    public void GetComplitedLevel()
    {
        StartCoroutine(DbManager.Instance.GetLevel(PlayerPrefs.GetString("PlayerRegister")));
    }
}
