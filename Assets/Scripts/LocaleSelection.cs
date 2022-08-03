using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelection : MonoBehaviour
{
    bool active = false;

    private void Start()
    {
        int localeId = PlayerPrefs.GetInt("LocaleId", 0);
        ChangeLocale(localeId);
    }

    public void ChangeLocale(int localeId)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localeId));
    }

    IEnumerator SetLocale(int localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        PlayerPrefs.SetInt("LocaleId", localeId);
        active = false;
    }
}
