﻿using UnityEngine;
using System.Collections;

public class Bonus1Control : MonoBehaviour
{

    public GameObject[] _prefab;
    public float[] _distance;
    float limitHieght;
    float limitWith;

    void OnEnable()
    {
        limitHieght = (Screen.height) / 200;
        limitWith = (Screen.width) / 200;
        StartCoroutine(spawm());
    }

    IEnumerator spawm()
    {
        int directionPos = Random.Range(0, 2);
        switch (directionPos)
        {
            case 0:
                for (int i = 0; i < _prefab.Length; i++)
                {
                    Transform _tr = Instantiate(_prefab[i]).transform;
                    float _posY = -2.1f + (1 * i);
                    _tr.position = new Vector2(-limitWith - 1 - _distance[i], _posY);
                    _tr.eulerAngles = Vector3.zero;
                    _tr.GetComponent<FishFollowLeaderBonusControl>().FollowStart();
                    yield return new WaitForSeconds(0.5f);
                }
                break;
            case 1:
                for (int i = 0; i < _prefab.Length; i++)
                {
                    Transform _tr = Instantiate(_prefab[i]).transform;
                    float _posY = -2.1f + (1 * i);
                    _tr.position = new Vector2(limitWith + 1 + _distance[i], _posY);
                    _tr.eulerAngles = new Vector3(0, 0, 180);
                    _tr.GetComponent<FishFollowLeaderBonusControl>().FollowStart();
                    yield return new WaitForSeconds(0.5f);
                }
                break;
        }
    }
}
