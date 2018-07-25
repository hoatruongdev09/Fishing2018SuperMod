using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{

    public Sprite[] ListBullet;
    public float speed;
    public GameObject _web;

    SpriteRenderer _sprite;
    

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void InitBullet(int level, Transform Gun, Vector2 target)
    {
        _sprite.sprite = ListBullet[level - 1];
        transform.up = Gun.up;
        LeanTween.move(gameObject, target, speed*(Vector2.Distance(target,transform.position))).setOnComplete(() =>
        {
            GameObject web = (GameObject)Instantiate(_web);
            web.transform.position = transform.position;
            web.transform.up = transform.up;
            web.GetComponent<WebControl>().InitWeb(level);
            Destroy(gameObject);
        });
    }

   

}
