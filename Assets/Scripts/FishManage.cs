using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishManage : MonoBehaviour
{
    public enum status
    {
        normal,
        bonus
    }

    public GameObject Normal;
    public GameObject Bonus;

    public GameObject wave;
    public GameObject effwave;

    public status _stt;

    public static FishManage Instance;
    public List<Transform> _FishMange;
    public List<Transform> _CaMapManage;
    public List<Transform> _MucManager;

    bool _checkTimeBonus;

    void Start()
    {
        Instance = this;
        _FishMange = new List<Transform>();
        _CaMapManage = new List<Transform>();
        _MucManager = new List<Transform>();
        _checkTimeBonus = false;

    }
    void Update()
    {
        if (_checkTimeBonus && Bonus.activeInHierarchy)
        {
            if (_FishMange.Count == 0)
            {
                Normal.SetActive(true);
                Bonus.SetActive(false);
                _checkTimeBonus = false;
                _FishMange.Clear();
            }
        }
    }

    public void ChangeToBonus()
    {
        Normal.SetActive(false);
        Bonus.SetActive(false);

        Instantiate(wave, new Vector2(8, 0), Quaternion.identity);
        _stt = status.bonus;
        Invoke("activeeffwave", 0.2f);
    }
    void activeeffwave()
    {
        effwave.SetActive(true);
    }

    public void BonusTime()
    {
        Normal.SetActive(false);
        Bonus.SetActive(true);
        Invoke("encheck", 2);
    }

    void encheck()
    {
        _checkTimeBonus = true;
    }
}
