using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ItemControl : MonoBehaviour
{
    public GameObject efBoom;
    public GameObject efNT;
    public GameObject shop;
    public UILabel _lb;
    public UILabel highScore;
    public GameObject thuong;
    public GameObject popUp;
    public void DestroyCaMap()
    {
        if (PlayerPrefs.GetInt("itemcamap") > 0)
        {
            while (FishManage.Instance._CaMapManage.Count > 0)
            {
                Transform aFish = FishManage.Instance._CaMapManage[0];
                FishManage.Instance._CaMapManage.RemoveAt(0);
                if (aFish != null)
                    aFish.GetComponent<FishControl>().hitDame(10000, efBoom);
            }
            PlayerPrefs.SetInt("itemcamap", PlayerPrefs.GetInt("itemcamap") - 1);
            AudioControl.Instance.clickButton();
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void DestroyMuc()
    {
        if (PlayerPrefs.GetInt("itemmuc") > 0)
        {
            while (FishManage.Instance._MucManager.Count > 0)
            {
                Transform aFish = FishManage.Instance._MucManager[0];
                FishManage.Instance._MucManager.RemoveAt(0);
                if (aFish != null)
                    aFish.GetComponent<FishControl>().hitDame(10000, efBoom);
            }
            PlayerPrefs.SetInt("itemmuc", PlayerPrefs.GetInt("itemmuc") - 1);
            AudioControl.Instance.clickButton();
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void DestroyAll()
    {
        if (PlayerPrefs.GetInt("itemnt") > 0)
        {
            AudioControl.Instance.nguyentu();
            while (FishManage.Instance._FishMange.Count > 0)
            {
                Transform aFish = FishManage.Instance._FishMange[0];
                FishManage.Instance._FishMange.RemoveAt(0);
                if (aFish != null)
                    aFish.GetComponent<FishControl>().hitDame(10000, efBoom);
            }
            Instantiate(efNT, Vector3.zero, Quaternion.identity);
            PlayerPrefs.SetInt("itemnt", PlayerPrefs.GetInt("itemnt") - 1);
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void ItemX2()
    {
        if (PlayerPrefs.GetInt("itemx2") > 0)
        {
            CancelInvoke("ResetGoldBonus");
            GunControl.BonusCoin = 2;
            Invoke("ResetGoldBonus", 60);
            PlayerPrefs.SetInt("itemx2", PlayerPrefs.GetInt("itemx2") - 1);
            AudioControl.Instance.clickButton();
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void ItemX3()
    {
        if (PlayerPrefs.GetInt("itemx3") > 0)
        {
            CancelInvoke("ResetGoldBonus");
            GunControl.BonusCoin = 3;
            Invoke("ResetGoldBonus", 60);
            PlayerPrefs.SetInt("itemx3", PlayerPrefs.GetInt("itemx3") - 1);
            AudioControl.Instance.clickButton();
        }
        else
        {
            shop.SetActive(true);
        }
    }

    void ResetGoldBonus()
    {
        GunControl.BonusCoin = 1;
    }

    public void FocusBoom()
    {
        if (PlayerPrefs.GetInt("itembom") > 0)
        {
            Instantiate(efBoom, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            PlayerPrefs.SetInt("itembom", PlayerPrefs.GetInt("itembom") - 1);
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void closeShop()
    {
        shop.SetActive(false);
        _lb.text = PlayerPrefs.GetInt("gold", 200) + "";
        highScore.text = _lb.text;
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
                        _lb.text = "" + PlayerPrefs.GetInt("gold", 200);
                        highScore.text = _lb.text;
                        if (popUp.activeInHierarchy == true)
                        {
                            popUp.SetActive(false);
                        }
                    }
                }
            });
        }
    }

    public void cancleads()
    {
        popUp.SetActive(false);
    }

    public void homeButton()
    {
        Application.LoadLevel("Home");
    }
}
