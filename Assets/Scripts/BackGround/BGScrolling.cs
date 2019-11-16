using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour {

    private float speed = 0.06f;

    private Material mat;

    private Vector2 offset = Vector2.zero;

    void Awake() {
        mat = GetComponent<Renderer>().material;
    }

	void Start () {
        offset = mat.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        offset.y += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);

    }
}
