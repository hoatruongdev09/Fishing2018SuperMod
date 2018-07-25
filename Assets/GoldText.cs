using UnityEngine;
using System.Collections;

public class GoldText : MonoBehaviour
{

    UILabel _lb;
    void Start()
    {
        _lb = GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        _lb.text = PlayerPrefs.GetInt("gold", 200) + "";
    }
}
