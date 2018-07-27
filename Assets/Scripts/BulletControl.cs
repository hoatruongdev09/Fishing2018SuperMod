using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{

    public Sprite[] ListBullet;
    public float speed;
    public GameObject _web;
    public GameObject gun;
    Vector2 mousePos;
    Vector3 bulletPosScreen;
    Camera cam;
    SpriteRenderer _sprite;
    

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        gun = GameObject.Find("Gun");
        cam = Camera.main;
    }

    public void InitBullet(int level, Transform Gun, Vector2 target)
    {
        _sprite.sprite = ListBullet[level - 1];
        //transform.up = Gun.up;
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        bulletPosScreen = cam.WorldToScreenPoint(gun.transform.position);
        mousePos = mousePos - new Vector2(bulletPosScreen.x, bulletPosScreen.y);
        speed = 260 / mousePos.magnitude;
        /*LeanTween.move(gameObject, target, speed*(Vector2.Distance(target,transform.position))).setOnComplete(() =>
        {
            GameObject web = (GameObject)Instantiate(_web);
            web.transform.position = transform.position;
            web.transform.up = transform.up;
            web.GetComponent<WebControl>().InitWeb(level);
            //Destroy(gameObject);
        });*/
    }

    void Update()
    {
        transform.Translate(mousePos * Time.deltaTime * 0.03f * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("cocl");
    }

}
