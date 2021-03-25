using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject LevelSelection;

    public void ClickLevelSelection()
    {
        LevelSelection.SetActive(true);
        Menu.SetActive(false);

    }
    public void ClickBackMenu()
    {
        LevelSelection.SetActive(false);
        Menu.SetActive(true);
    }
}
