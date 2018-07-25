using UnityEngine;
using System.Collections;

public class Limiter : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col) {
        if(col.tag == "fish") {
            col.GetComponent<FishControl>().ColliderExit();
        }
    }
}
