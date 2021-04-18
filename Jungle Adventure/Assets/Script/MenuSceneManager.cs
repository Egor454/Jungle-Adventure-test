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


    void Start()
    {
        GetComplitedLevel();
    }
    public void ClickLevelSelection()
    {
        LevelSelection.SetActive(true);
        Menu.SetActive(false);
        for (int i = 1; i < DbManager.Instance.Level.Count; i++)
        {
            if (DbManager.Instance.Level[i] == "1")
            {
                LevelGame[i].GetComponent<Image>().sprite = (Sprite)Resources.Load("Image/MenuImage/MenuLevel" + (i + 1), typeof(Sprite));
                LevelGame[i].GetComponent<Button>().interactable = true;
            }
        }
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
    public void GetComplitedLevel()
    {
        StartCoroutine(DbManager.Instance.GetLevel());
    }
}
