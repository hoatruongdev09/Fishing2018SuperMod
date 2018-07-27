using UnityEngine;
using System.Collections;

public class FishControl : MonoBehaviour
{

    public string AnimationName;
    public string AnimationNameDie;
    Animator _ani;

    public int Hp;
    public int RndHp;

    public int HpMax;
    public int RndHpMax;

    Swim _swim;
    int _hp;
    GameObject _checkCollsion;

    bool _checkInvisible;

    public delegate void CallDie();
    public CallDie _callDie;

    public int _gold;



    void OnEnable()
    {
        _checkInvisible = false;
        _ani = GetComponent<Animator>();
        _ani.Play(AnimationName, 0, Random.Range(0f, 1f));

        _swim = GetComponent<Swim>();

        if (Random.Range(0, 2) == 1)
            _hp = Random.Range(HpMax - RndHpMax, HpMax + RndHpMax);
        else
            _hp = Random.Range(Hp - RndHp, Hp - RndHp);
    }

    public void hitDame(int dame, GameObject obj)
    {
        if (_checkCollsion == null || (_checkCollsion.GetInstanceID() != obj.GetInstanceID()))
        {
            _hp -= dame;
            _checkCollsion = obj;

            if (_hp <= 0)
            {
                if (_callDie != null)
                {
                    _callDie();
                }
                _swim.enabled = false;
                _ani.Play(AnimationNameDie, 0, 0);
                GetComponent<BoxCollider2D>().enabled = false;
<<<<<<< HEAD
<<<<<<< HEAD
                Instantiate(Resources.Load("coinEff"), transform.position + Vector3.up * 0.5f, Quaternion.identity);
                UiTextSpawmControl.Instance.CallTextEff(transform.position + Vector3.up * 0.5f, _gold);
=======
                
=======
                Instantiate(Resources.Load("coinEff"), transform.position + Vector3.up * 0.5f, Quaternion.identity);
>>>>>>> parent of 6eb26bb... voi to, bong tru diem
                if (obj.tag == "fish")
                    UiTextSpawmControl.Instance.CallTextEff(transform.position + Vector3.up * 0.5f, _gold);
                else if (obj.tag == "fishDie")
                    UiTextSpawmControl.Instance.CallTextEff(transform.position + Vector3.up * 0.5f, "Die");
                else if (obj.tag == "fishLife")
                    UiTextSpawmControl.Instance.CallTextEff(transform.position + Vector3.up * 0.5f, "Life");
                else
                    UiTextSpawmControl.Instance.CallTextEff(transform.position + Vector3.up * 0.5f, "iPhone");

>>>>>>> 6eb26bb3581bdb754309990e65af7cdeadbff9ed
                FishManage.Instance._FishMange.Remove(transform);
                Destroy(gameObject, 0.8f);
            }
        }
    }

    public void CollisionWithWave()
    {
        if (_callDie != null)
        {
            _callDie();
        }
        FishManage.Instance._FishMange.Remove(transform);
        Destroy(gameObject);


    }
    public void ColliderExit() {
        if(_callDie != null) {
            _callDie();
        }
        FishManage.Instance._FishMange.Remove(transform);
        Destroy(gameObject);
    }

    void OnBecameVisible()
    {
        if (gameObject.tag == "fish")
        {
            if (_checkInvisible) return;
            _checkInvisible = true;
            FishManage.Instance._FishMange.Add(transform);
            if (gameObject.name == "Fish12FreeSign(Clone)" || gameObject.name == "Fish11FreeSign(Clone)")
            {
                FishManage.Instance._CaMapManage.Add(transform);
            }
            else
            {
                if (gameObject.name == "Fish7Follow(Clone)" || gameObject.name == "Fish7FollowBonus(Clone)" || gameObject.name == "Fish7FreeSign(Clone)" || gameObject.name == "Fish6Follow(Clone)" || gameObject.name == "Fish6FollowBonus(Clone)" || gameObject.name == "Fish6FreeSign(Clone)")
                {
                    FishManage.Instance._MucManager.Add(transform);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (gameObject.tag == "fish")
        {
            FishManage.Instance._FishMange.Remove(transform);
            if (gameObject.name == "Fish12FreeSign(Clone)" || gameObject.name == "Fish11FreeSign(Clone)")
            {
                FishManage.Instance._CaMapManage.Remove(transform);
            }
            else
            {
                if (gameObject.name == "Fish7Follow(Clone)" || gameObject.name == "Fish7FollowBonus(Clone)" || gameObject.name == "Fish7FreeSign(Clone)" || gameObject.name == "Fish6Follow(Clone)" || gameObject.name == "Fish6FollowBonus(Clone)" || gameObject.name == "Fish6FreeSign(Clone)")
                {
                    FishManage.Instance._MucManager.Remove(transform);
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        if (gameObject.tag == "fish")
        {
            FishManage.Instance._FishMange.Remove(transform);
            if (gameObject.name == "Fish12FreeSign(Clone)" || gameObject.name == "Fish11FreeSign(Clone)")
            {
                FishManage.Instance._CaMapManage.Remove(transform);
            }
            else
            {
                if (gameObject.name == "Fish7Follow(Clone)" || gameObject.name == "Fish7FollowBonus(Clone)" || gameObject.name == "Fish7FreeSign(Clone)" || gameObject.name == "Fish6Follow(Clone)" || gameObject.name == "Fish6FollowBonus(Clone)" || gameObject.name == "Fish6FreeSign(Clone)")
                {
                    FishManage.Instance._MucManager.Remove(transform);
                }
            }
        }
        Destroy(gameObject);

    }
}
