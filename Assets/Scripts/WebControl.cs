using UnityEngine;
using System.Collections;

public class WebControl : MonoBehaviour
{

    public Sprite[] ListWeb;
    public float[] ListRadius;

    SpriteRenderer _sprite;
    CircleCollider2D _Collider;

    int dame;


    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _Collider = GetComponent<CircleCollider2D>();
    }

    public void InitWeb(int level)
    {
        _sprite.sprite = ListWeb[level - 1];
        _Collider.radius = ListRadius[level - 1];
        dame = level + Random.Range(0, 1);
        if (level > 7)
        {
            dame = dame + 7 - level;
        }
        Invoke("DisableCollision", 0.1f);
        LeanTween.scale(gameObject, new Vector2(1, 1), 0.4f).setEase(LeanTweenType.easeOutElastic).setOnComplete(() =>
        {
            Destroy(gameObject, 0.5f);
        });
    }

    void DisableCollision()
    {
        _Collider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "fish")
        {
            col.GetComponent<FishControl>().hitDame(dame, gameObject);
        }
    }


}
