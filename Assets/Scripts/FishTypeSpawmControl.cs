using UnityEngine;
using System.Collections;

public class FishTypeSpawmControl : MonoBehaviour {

    public GameObject[] _pre;
    public float countTime;
    public float RndCountTime;
    public float StartWaitTime;

    public static FishTypeSpawmControl _free;

    public float _distance = 0;

    public float limitHieght;
    public float limitWith;

    public void Start() {

        limitHieght = (Screen.height) / 200;
        limitWith = (Screen.width) / 200;
        _free = this;
    }

    void OnEnable() {
        StartCoroutine(spawm(StartWaitTime));
    }

    IEnumerator spawm(float starttime) {
        yield return new WaitForSeconds(starttime);

        int a = Random.Range(0, _pre.Length);
        Transform _tr = Instantiate(_pre[a]).transform;
        int directionPos = Random.Range(0, 4);
        switch (directionPos) {
            case 0:
                float _posY0 = Random.Range(-limitHieght + 1, limitHieght - 1);
                _tr.position = new Vector2(-limitWith - 1 - _distance, _posY0);
                if (_posY0 < -limitHieght / 2) {
                    _tr.eulerAngles = new Vector3(0, 0, Random.Range(-70, -85));
                } else {
                    if (_posY0 > limitHieght / 2) {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(70, 85)); //(-65, -25)
                    } else {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(70, 90)); //(-45, 45)
                    }
                }
                break;

            case 1:
                float _posX1 = Random.Range(-limitWith + 1, limitWith - 1);
                _tr.position = new Vector2(_posX1, limitHieght + 1 + _distance);
                if (_posX1 < -limitWith / 2) {
                    _tr.eulerAngles = new Vector3(0, 0, Random.Range(-60, -80)); //(295, 335)
                } else {
                    if (_posX1 > limitWith / 2) {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(60, 80)); //(-155, -115)
                    } else {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(85, 90)); //(-135, -35)
                    }
                }
                break;

            case 2:
                float _posX2 = Random.Range(-limitWith + 1, limitWith - 1);
                _tr.position = new Vector2(_posX2, -limitHieght - 1 - _distance);
                if (_posX2 < -limitWith / 2) {
                    _tr.eulerAngles = new Vector3(0, 0, Random.Range(-60, -80)); //(25, 65)
                } else {
                    if (_posX2 > limitWith / 2) {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(60, 80)); //(115, 155)
                    } else {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(85, 90)); //(35, 145)
                    }
                }
                break;

            case 3:
                float _posY3 = Random.Range(-limitHieght + 1, limitHieght - 1);
                _tr.position = new Vector2(limitWith + 1 + _distance, _posY3);
                if (_posY3 < -limitHieght / 2) {
                    _tr.eulerAngles = new Vector3(0, 0, Random.Range(-70, -85)); //(115, 165)
                } else {
                    if (_posY3 > limitHieght / 2) {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(70, 85)); //(205, 245)
                    } else {
                        _tr.eulerAngles = new Vector3(0, 0, Random.Range(70, 90)); //(135, 235)
                    }
                }
                break;
            default:
                break;
        }

        switch (a) {
            case 2:
                _tr.GetComponent<FishFlockLeaderControl>().FlockStart();
                break;
            case 1:
                _tr.GetComponent<FishFollowLeaderControl>().FollowStart();
                break;
        }

        yield return new WaitForSeconds(countTime);
        StartCoroutine(spawm(0));
    }
}
