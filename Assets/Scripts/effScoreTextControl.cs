using UnityEngine;
using System.Collections;

public class effScoreTextControl : MonoBehaviour
{
    Camera uiCam;
    public UILabel _lb;
    public void InitEffScore(Vector3 _trs, int gold, bool minus)
    {
        if (minus)
        {
            _lb.color = Color.black;
            _lb.text = "-" + gold;
        }
        else
        {
            _lb.color = Color.yellow;
            _lb.text = "+" + gold;
        }
        
        switch (GunControl.BonusCoin)
        {
            case 2:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
            case 3:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
        }
        uiCam = GameObject.FindObjectOfType<UICamera>().GetComponent<Camera>();
        Vector3 a = _trs;
        a = Camera.main.WorldToScreenPoint(a);
        a = uiCam.ScreenToWorldPoint(a);
        transform.position = a;
        LeanTween.move(gameObject, a + Vector3.up * 0.1f, 0.8f).setOnComplete(() =>
        {
            Destroy(gameObject);
            if (minus)
                UiTextSpawmControl.Instance.MinusGold(gold * GunControl.BonusCoin);
            else UiTextSpawmControl.Instance.PushGold(gold * GunControl.BonusCoin);
        });
    }


    public void InitEffScore(Vector3 _trs, string gold, bool die)
    {
        if (die)
        {
            _lb.text = "-" + gold;
            _lb.color = Color.gray;
        }
        else
        {
            _lb.color = Color.magenta;
            _lb.text = "+" + gold;
        }
           

        switch (GunControl.BonusCoin)
        {
            case 2:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
            case 3:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
        }
        uiCam = GameObject.FindObjectOfType<UICamera>().GetComponent<Camera>();
        Vector3 a = _trs;
        a = Camera.main.WorldToScreenPoint(a);
        a = uiCam.ScreenToWorldPoint(a);
        transform.position = a;
        LeanTween.move(gameObject, a + Vector3.up * 0.1f, 0.8f).setOnComplete(() =>
        {
            Destroy(gameObject);
            //UiTextSpawmControl.Instance.PushGold(gold * GunControl.BonusCoin);
        });
    }

    public void InitEffScore(Vector3 _trs, string gold)
    {
        _lb.color = Color.red;
        _lb.text = gold;
        switch (GunControl.BonusCoin)
        {
            case 2:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
            case 3:
                _lb.text += "x" + GunControl.BonusCoin;
                break;
        }
        uiCam = GameObject.FindObjectOfType<UICamera>().GetComponent<Camera>();
        Vector3 a = _trs;
        a = Camera.main.WorldToScreenPoint(a);
        a = uiCam.ScreenToWorldPoint(a);
        transform.position = a;
        LeanTween.move(gameObject, a + Vector3.up * 0.1f, 0.8f).setOnComplete(() =>
        {
            Destroy(gameObject);
            //UiTextSpawmControl.Instance.PushGold(gold * GunControl.BonusCoin);
        });
    }


}
