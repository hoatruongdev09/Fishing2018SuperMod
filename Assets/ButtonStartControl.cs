using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ButtonStartControl : MonoBehaviour
{

    public void Play()
    {
        Application.LoadLevel("Play");
        AudioControl.Instance.clickButton();
    }
    public void Shop()
    {
        Application.LoadLevel("Shop");
        AudioControl.Instance.clickButton();
    }
    public void rate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.firevil.banca2016");
    }

    public void showAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(null, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result.ToString() == "Finished")
                    {
                        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold",200) + 50);
                    }
                }
            });
        }
    }
}
