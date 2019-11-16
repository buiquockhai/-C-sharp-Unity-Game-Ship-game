using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Delete : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2f);
	}
}
