using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TenorSDK;
using TenorSDK.Request;

public class GIFComponent : MonoBehaviour {

	public Renderer render;
	public UniGifImage unigif;

	// Use this for initialization
	void Start () {
		render = transform.gameObject.GetComponent<Renderer>();
		unigif = transform.gameObject.GetComponent<UniGifImage>();

	}
	
	// Update is called once per frame
	void Update () {
		// unigif.m_texture = render.material.mainTexture;

	}
}
