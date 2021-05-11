using UnityEngine;
using UnityEngine.UI;

namespace Script.Localization
{
    [RequireComponent(typeof(Text))]

    public class Localize : LocalizeBase
    {
        #region Private Fields

        private Text text;

        #endregion

        #region Public Methods
        public override void UpdateLocal()
        {
            if (!text) return;
            if (!System.String.IsNullOrEmpty(localizationKey) && Locale.CurrentLanguageStrings.ContainsKey(localizationKey))
                text.text = Locale.CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n');
        }
        #endregion Public Methods

        #region Private Methods

        protected override void Start()
        {
            text = GetComponent<Text>();
            base.Start();
        }

        #endregion Private Methods
    }

}

