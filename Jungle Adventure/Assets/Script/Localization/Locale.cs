using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Localization
{
    public static class Locale 
    {
        #region Fields

        const string STR_LOCALIZATION_KEY = "locale";
        const string STR_LOCALIZATION_PREFIX = "localization/";
        static string currentLanguage;
        static bool currentLanguageFileHasBeFound = false;
        public static bool currentLanguageHasBeenSet = false;
        public static Dictionary<string, string> CurrentLanguageStrings = new Dictionary<string, string>();
        static TextAsset currentLocalizationText;

        #endregion Fields

        #region Public Methods

        public static string CurrentLanguage 
        {
            get { return currentLanguage; }
            set
            {
                if(value != null && value.Trim() != string.Empty)
                {
                    currentLanguage = value;
                    currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                    if(currentLocalizationText == null)
                    {
                        Debug.LogWarningFormat("Missing locale '{0}', loading Russian ", CurrentLanguage);
                        currentLanguage = SystemLanguage.Russian.ToString();
                        currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                    }
                    if(currentLocalizationText != null)
                    {
                        currentLanguageFileHasBeFound = true;
                        string[] lines = currentLocalizationText.text.Split(new string[] { "\r\n", "\n\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                        CurrentLanguageStrings.Clear();
                        for(int i = 0;i < lines.Length; i++)
                        {
                            string[] pairs = lines[i].Split(new char[] { '\t', '=' }, 2);
                            if(pairs.Length == 2)
                            {
                                CurrentLanguageStrings.Add(pairs[0].Trim(), pairs[1].Trim());
                            }
                        }
                    }
                    else
                    {
                        Debug.LogErrorFormat("Local language '{0}' not found!", currentLanguage); 
                    }
                }
            }
        }

        public static bool CurrentLanguageHasBeenSet 
        {
            get
            {
                return currentLanguageHasBeenSet;
            }
        }
        public static SystemLanguage PlayerLanguage
        {
            get
            {
                return (SystemLanguage)PlayerPrefs.GetInt(STR_LOCALIZATION_KEY, (int)Application.systemLanguage);
            }
            set
            {
                PlayerPrefs.SetInt(STR_LOCALIZATION_KEY, (int)value);
                PlayerPrefs.Save();
            }
        }

        #endregion Public Methods

    }
}

