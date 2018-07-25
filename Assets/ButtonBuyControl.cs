using UnityEngine;
using System.Collections;

public class ButtonBuyControl : MonoBehaviour
{

    public string _str;
    public int price;
    public UILabel priceLb;
    public GameObject popUp;

    public UILabel _txt;

    public void Click()
    {
        if (PlayerPrefs.GetInt("gold", 200) >= price)
        {
            PlayerPrefs.SetInt(_str, PlayerPrefs.GetInt(_str) + 1);
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200) - price);
            if (_txt != null)
            {
                _txt.text = PlayerPrefs.GetInt("gold", 200) + "";
            }
        }
        else
        {
            popUp.SetActive(true);
        }
    }

}
