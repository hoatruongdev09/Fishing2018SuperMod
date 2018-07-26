﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiTextSpawmControl : MonoBehaviour
{

    public GameObject _UiRoot;
    public GameObject _TextChil;
    public UILabel TextGold;


    public UISprite EXPbar;
    public UILabel TextLevel;
    public Image RocketImg;

    public static UiTextSpawmControl Instance;

    public int power;
    public UILabel powerText;
    public UILabel gameoverText;

    public int fishCount;

    void Start()
    {
        //load ve tinh sau
        power = 3;
        Instance = this;
        TextGold.text = "" + PlayerPrefs.GetInt("gold", 0);
        EXPbar.fillAmount = PlayerPrefs.GetFloat("EXP") / (450 + 500 * PlayerPrefs.GetInt("level", 1));
        TextLevel.text = PlayerPrefs.GetInt("level", 1) + "";
    }

    public void CallTextEff(Vector3 _pos, int gold, bool minus)
    {
        GameObject obj = NGUITools.AddChild(_UiRoot, _TextChil);
        obj.GetComponent<effScoreTextControl>().InitEffScore(_pos, gold, minus);

        PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + gold);
        EXPbar.fillAmount = PlayerPrefs.GetFloat("EXP") / (450 + 500 * PlayerPrefs.GetInt("level", 1));
        //RocketImg.fillAmount += (float)((float)gold / 1000);
        //if (RocketImg.fillAmount == 1)
        //{
        //    GunControl.Instance.ChangtoRocket();
        //    RocketImg.fillAmount = 0;
        //}

        //if (EXPbar.fillAmount == 1)
        //{
        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        //    PlayerPrefs.SetFloat("EXP", 0);
        //    TextLevel.text = PlayerPrefs.GetInt("level", 1) + "";
        //    FishManage.Instance.ChangeToBonus();
        //}
    }

    public void CallTextEff(Vector3 _pos, string gold)
    {
        GameObject obj = NGUITools.AddChild(_UiRoot, _TextChil);
        obj.GetComponent<effScoreTextControl>().InitEffScore(_pos, gold);

        //PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + gold);
        EXPbar.fillAmount = PlayerPrefs.GetFloat("EXP") / (450 + 500 * PlayerPrefs.GetInt("level", 1));
        //RocketImg.fillAmount += (float)((float)gold / 1000);
        //if (RocketImg.fillAmount == 1)
        //{
        //    GunControl.Instance.ChangtoRocket();
        //    RocketImg.fillAmount = 0;
        //}

        //if (EXPbar.fillAmount == 1)
        //{
        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        //    PlayerPrefs.SetFloat("EXP", 0);
        //    TextLevel.text = PlayerPrefs.GetInt("level", 1) + "";
        //    FishManage.Instance.ChangeToBonus();
        //}
    }

    public void CallTextEff(Vector3 _pos, string gold, bool die)
    {
        GameObject obj = NGUITools.AddChild(_UiRoot, _TextChil);
        obj.GetComponent<effScoreTextControl>().InitEffScore(_pos, gold, die);

        //PlayerPrefs.SetFloat("EXP", PlayerPrefs.GetFloat("EXP") + gold);
        EXPbar.fillAmount = PlayerPrefs.GetFloat("EXP") / (450 + 500 * PlayerPrefs.GetInt("level", 1));
        //RocketImg.fillAmount += (float)((float)gold / 1000);
        //if (RocketImg.fillAmount == 1)
        //{
        //    GunControl.Instance.ChangtoRocket();
        //    RocketImg.fillAmount = 0;
        //}

        //if (EXPbar.fillAmount == 1)
        //{
        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        //    PlayerPrefs.SetFloat("EXP", 0);
        //    TextLevel.text = PlayerPrefs.GetInt("level", 1) + "";
        //    FishManage.Instance.ChangeToBonus();
        //}
    }

    public void PushGold(int gold)
    {
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold",200) + gold);
        TextGold.text = "" + PlayerPrefs.GetInt("gold",200);
    }

    public void MinusGold(int gold)
    {
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200) - gold);
        TextGold.text = "" + PlayerPrefs.GetInt("gold",200);
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
