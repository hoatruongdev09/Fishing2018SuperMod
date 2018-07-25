using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class shopScenes : MonoBehaviour
{

    public GameObject thuong;
    public GameObject ads;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Home");
        }
    }


    public void HomeButoon()
    {
        Application.LoadLevel("Home");
    }

    public void showAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result.ToString() == "Finished")
                    {
                        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200) + 50);
                        thuong.SetActive(true);
                        if (ads.activeInHierarchy == true)
                        {
                            ads.SetActive(false);
                        }
                    }
                }
            });
        }
    }

    public void candcleAds()
    {
        ads.SetActive(false);
    }
}
