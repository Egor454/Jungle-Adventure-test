using TMPro;
using UnityEngine;

namespace Script.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]

    public class LocalizeTM : LocalizeBase
    {
        #region Private Fields

        private TextMeshProUGUI text;

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
            text = GetComponent<TextMeshProUGUI>();
            base.Start();
        }

        #endregion Private Methods
    }

}
