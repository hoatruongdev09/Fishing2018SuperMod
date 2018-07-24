using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour
{
    public static GunControl Instance;
    public GameObject Bullet;
    public static int BonusCoin;
    public GameObject tenlua;
    public GameObject _effboom;
    public GameObject popUp;

    bool _checkfire;
    bool _tenlua;
    Animator _ani;
    int _levelGun;

    void Start()
    {
        _checkfire = true;
        _tenlua = false;
        Instance = this;
        _ani = GetComponent<Animator>();
        _ani.Play("Idle", 0, 0);
        _ani.SetFloat("level", 0);
        _ani.speed = 2;
        _levelGun = 1;
        BonusCoin = 1;
    }


    public void PlusGun()
    {
        if (!_checkfire) return;
        if (_levelGun < 9)
            _levelGun += 1;
        else
            _levelGun = 1;

        _ani.SetFloat("level", _levelGun);
    }

    public void MinusGun()
    {
        if (!_checkfire) return;
        if (_levelGun > 1)
            _levelGun -= 1;
        else
            _levelGun = 9;

        _ani.SetFloat("level", _levelGun);
    }

    public void Fire()
    {
        if (Time.timeScale == 0)
            return;
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = Vector3.Normalize(mousePoint + Vector3.forward * 10 - transform.position);
        if (PlayerPrefs.GetInt("gold", 200) < _levelGun && _tenlua == false)
            popUp.SetActive(true);
        else
        {
            if (PlayerPrefs.GetInt("gold", 200) >= _levelGun && _checkfire && _tenlua == false)
            {
                _ani.Play("Fire", 0, 0);
                AudioControl.Instance.shoot();
                GameObject _bullet = (GameObject)Instantiate(Bullet);
                _bullet.transform.position = transform.position + transform.up * 0.5f;
                _bullet.GetComponent<BulletControl>().InitBullet(_levelGun, transform, new Vector2(mousePoint.x, mousePoint.y));

                //UiTextSpawmControl.Instance.MinusGold(_levelGun);
            }
        }
        if (_tenlua && _checkfire)
        {
            _tenlua = false;
            tenlua.transform.up = Vector3.Normalize(mousePoint + Vector3.forward * 10 - tenlua.transform.position);
            _checkfire = false;
            LeanTween.move(tenlua, new Vector3(mousePoint.x, mousePoint.y, 0), 0.2f * (Vector2.Distance(mousePoint, tenlua.transform.position))).setOnComplete(() =>
            {
                RaycastHit2D[] fish = Physics2D.CircleCastAll(new Vector3(tenlua.transform.position.x, tenlua.transform.position.y, 0), 2, Vector3.zero);
                AudioControl.Instance.boom();
                for (int i = 0; i < fish.Length; i++)
                {
                    if (fish[i].collider.tag == "fish")
                        fish[i].collider.gameObject.GetComponent<FishControl>().hitDame(1000, gameObject);
                }
                GameObject boom = (GameObject)Instantiate(_effboom, tenlua.transform.position + tenlua.transform.up * 0.5f, Quaternion.identity);
                Destroy(boom, 1.5f);
                tenlua.SetActive(false);
                //GetComponent<SpriteRenderer>().enabled = true;
                transform.up = Vector3.up;
                transform.localScale = Vector3.zero;
                LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
                {
                    _checkfire = true;
                });
            });
        }
    }

    public void ChangtoRocket()
    {
        _checkfire = false;
        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setOnComplete(() =>
        {

            GetComponent<SpriteRenderer>().enabled = false;
            _checkfire = true;
            _tenlua = true;
        });
        tenlua.SetActive(true);
        tenlua.transform.localScale = Vector3.zero;
        tenlua.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        tenlua.transform.up = Vector3.up;
        LeanTween.scale(tenlua, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);

    }

}
