using UnityEngine;
using System.Collections;

public class effScoreTextControl : MonoBehaviour
{
    Camera uiCam;
    public UILabel _lb;
    public void InitEffScore(Vector3 _trs, int gold)
    {
        _lb.text = "+" + gold;
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
            UiTextSpawmControl.Instance.PushGold(gold * GunControl.BonusCoin);
        });
    }


}
