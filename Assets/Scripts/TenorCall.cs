using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TenorSDK;
using TenorSDK.Request;

public class TenorCall : MonoBehaviour {

	public GameObject[] elements;
	public InputField inputTag;

	private UniGifImage[] gifComponent = new UniGifImage[7];
	private int index = 0;
	private int indexResult = 0;
	private string lastSearch = "";

	// Use this for initialization
	void Start () {
		for (int i = 0; i < elements.Length; i++) {
			gifComponent[i] = elements[i].GetComponentInChildren<UniGifImage> ();
		}
		hideAll ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void hideAll() {
		for (int i = 1; i < elements.Length; i++) {
			elements [i].SetActive (false);
		}
	}

	// Search GIFs
	public void SearchTenorGIF() {

		// Initialize SDK
		TenorAPI.Initialize ("LIVDSRZULELA");

		// Prepare Request data
		SearchRequest request = new SearchRequest ();
		request.q = inputTag.text;
		request.limit = "50";

		if (lastSearch != inputTag.text) {
			// Change object with new search
			elements [index++].SetActive (false);
			elements [index].SetActive (true);
			indexResult = 0;
		} else {
			// Show next answer
			indexResult++;
			if (indexResult >= 49) {
				indexResult = 0;
			}
		}

		// Call Coroutine to not freeze
		StartCoroutine(TenorAPI.Search(request, ProcessAnswers));
		lastSearch = inputTag.text;
	}

	void ProcessAnswers(Response data) {
		StartCoroutine(gifComponent[index].SetGifFromUrlCoroutine(data.results[indexResult].media[0].mediumgif.url));
	}
}
