using UnityEngine;
using System.Collections;

public class ItemCountLb : MonoBehaviour
{

    public string _str;
    UILabel _lb;

    void Start()
    {
        _lb = GetComponent<UILabel>();
    }

    void Update()
    {
        _lb.text = PlayerPrefs.GetInt(_str) + "";
    }
}
