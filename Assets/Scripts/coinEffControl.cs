using UnityEngine;
using System.Collections;

public class coinEffControl : MonoBehaviour
{


    void Start()
    {
        LeanTween.move(gameObject, new Vector2(3.4f, 3.4f), 1).setOnComplete(() =>
        {
            Destroy(gameObject);
        });
        AudioControl.Instance.coin();
    }


}
