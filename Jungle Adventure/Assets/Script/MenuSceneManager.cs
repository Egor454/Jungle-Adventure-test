using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Script.Localization;
using TMPro;


public class MenuSceneManager : MonoBehaviour
{
    #region SerializeField

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject levelSelection;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject shop;
    [SerializeField] private Text offOnMusic;
    [SerializeField] private Text offOnSound;
    [SerializeField] private Text nameLanguage;
    [SerializeField] private TextMeshProUGUI titleLevelSelect;
    [SerializeField] private Image[] LevelGame;

    #endregion SerializeField

    #region Private Fields

    private int sceneIndex;
    private bool musicSettings;
    private bool soundSettings;
    private string namePlayer;

    int i;

    private ShopModel shopModel;
    private ShopController shopController;

    #endregion Private Fields

    #region UnitCode

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        namePlayer = PlayerPrefs.GetString("PlayerRegister");
        GetComplitedLevel();
        GetAllSkin();
        AudioManager.Instance.FonMusic(sceneIndex);
    }
    private void Awake()
    {
        StartSettingGame();
    }

    #endregion unitCode

    #region StartSetting

    public void StartSettingGame()
    {
        if (!PlayerPrefs.HasKey("MusicSettings"))
            PlayerPrefs.SetString("MusicSettings", "true");
        if (!PlayerPrefs.HasKey("SoundSettings"))
            PlayerPrefs.SetString("SoundSettings", "true");
        musicSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("MusicSettings"));
        soundSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("SoundSettings"));
        if (musicSettings)
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
                offOnMusic.text = "On";
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
                offOnMusic.text = "Вкл";
        }
        else
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
                offOnMusic.text = "Off";
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
                offOnMusic.text = "Выкл";
        }
        if (soundSettings)
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
                offOnSound.text = "On";
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
                offOnSound.text = "Вкл";
        }
        else
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
                offOnSound.text = "Off";
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
                offOnSound.text = "Выкл";
        }
        if(Locale.PlayerLanguage == SystemLanguage.English)
            nameLanguage.text = "English";
        else if (Locale.PlayerLanguage == SystemLanguage.Russian)
            nameLanguage.text = "Русский";
    }

    #endregion StartSetting

    #region MenuClick

    public void ClickLevelSelection()
    {
        levelSelection.SetActive(true);
        menu.SetActive(false);
        if(Locale.currentLanguageHasBeenSet == true)
        {
            if(Locale.PlayerLanguage == SystemLanguage.English)
                Localize.SetCurrentLanguage(SystemLanguage.English);
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
                Localize.SetCurrentLanguage(SystemLanguage.Russian);
        }
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
    }
    public void ClickBackMenu()
    {
        AudioManager.Instance.ButtonClick();
        levelSelection.SetActive(false);
        settings.SetActive(false);
        shop.SetActive(false);
        menu.SetActive(true);
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
        StartCoroutine(DbManager.Instance.GetLevel(namePlayer));
    }

    public void OpneShop()
    {
        shop.SetActive(true);
        menu.SetActive(false);

        shopModel = new ShopModel();
        var shopView = shop.GetComponent<ShopView>();
        shopController = new ShopController(shopView, shopModel);

    }

    public void GetAllSkin()
    {
        StartCoroutine(DbManager.Instance.GetAllSkin());
        StartCoroutine(DbManager.Instance.GetCoinPlayer(namePlayer));
        StartCoroutine(DbManager.Instance.GetSkinBuyPlayer(namePlayer));
    }

    #endregion MenuClick

    #region Settings

    public void OpenSetting()
    {
        AudioManager.Instance.ButtonClick();
        settings.SetActive(true);
        menu.SetActive(false);
    }
    public void LeftArrowMusic()
    {
        if(offOnMusic.text != "Вкл" || offOnMusic.text != "On")
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
            {
                offOnMusic.text = "On";
            }
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
            {
                offOnMusic.text = "Вкл";
            }
            PlayerPrefs.SetString("MusicSettings", "true");
            AudioManager.Instance.ChangeMusicSettings();
            AudioManager.Instance.ButtonClick();
        }
    }
    public void RightArrowMusic()
    {
        if (offOnMusic.text != "Выкл" || offOnMusic.text != "Off")
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
            {
                offOnMusic.text = "Off";
            }
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
            {
                offOnMusic.text = "Выкл";
            }
            PlayerPrefs.SetString("MusicSettings", "false");
            AudioManager.Instance.ButtonClick();
            AudioManager.Instance.ChangeMusicSettings();
        }
    }
    public void LeftArrowSound()
    {
        if (offOnSound.text != "Вкл" || offOnSound.text != "On")
        {
            if (Locale.PlayerLanguage == SystemLanguage.English)
            {
                offOnSound.text = "On";
            }
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
            {
                offOnSound.text = "Вкл";
            }
            PlayerPrefs.SetString("SoundSettings", "true");
            AudioManager.Instance.ChangeSoundSettings();
            AudioManager.Instance.ButtonClick();
        }
    }
    public void RightArrowSound()
    {
        if (offOnSound.text != "Выкл" || offOnSound.text != "Off")
        {
            if(Locale.PlayerLanguage == SystemLanguage.English)
            {
                offOnSound.text = "Off";
            }
            else if (Locale.PlayerLanguage == SystemLanguage.Russian)
            {
                offOnSound.text = "Выкл";
            }
            PlayerPrefs.SetString("SoundSettings", "false");
            AudioManager.Instance.ChangeSoundSettings();
            AudioManager.Instance.ButtonClick();
        }
    }

    #endregion Settings

    #region Localization

    public void SetRussian()
    {
        nameLanguage.text = "Русский";
        Localize.SetCurrentLanguage(SystemLanguage.Russian);
        StartSettingGame();
    }
    public void SetEnglish()
    {
        nameLanguage.text = "English";
        Localize.SetCurrentLanguage(SystemLanguage.English);
        StartSettingGame();
    }

    #endregion Localization
}
