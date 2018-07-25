using UnityEngine;
using System.Collections;

public class enableitem : MonoBehaviour {

    BoxCollider _box;
    UISprite _spr;
    void Start()
    {
        _box = GetComponent<BoxCollider>();
        _spr = GetComponent<UISprite>();
    }


    void Update()
    {
        if (GunControl.BonusCoin != 1 && _box.enabled)
        {
            _box.enabled = false;
            _spr.color = new Color(0.3f, 0.3f, 0.3f, 1);
        }
        if (GunControl.BonusCoin == 1 && !_box.enabled)
        {
            _box.enabled = true;
            _spr.color = new Color(1, 1, 1, 1);
        }
    }
}
