using UnityEngine;
using System.Collections;

public class texttimecontrol : MonoBehaviour
{
    float timequa;
    public UILabel _lb;
    UILabel _this;

    void Start()
    {
        timequa = 60;
        _this = GetComponent<UILabel>();
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        if (timequa > 0)
        {
            timequa -= 1;
            _this.text = timequa + "";
        }
        else
        {
            if (PlayerPrefs.GetInt("gold", 200) < 200)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold", 200) + 10);
                _lb.text = PlayerPrefs.GetInt("gold", 200) + "";
                timequa = 60;
            }
        }
        StartCoroutine(time());
    }

}
