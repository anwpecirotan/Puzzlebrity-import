using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOnline : MonoBehaviour {

	public RawImage rawImg;

	void Awake()
	{
		rawImg = this.gameObject.GetComponent<RawImage> ();
	}

	// Use this for initialization
	IEnumerator Start () {
		WWW www = new WWW ("https://drive.google.com/uc?export=view&id=1hPAy288DTB5U80IcMjWIggQD-C8AWj3h");
		yield return www ;
		rawImg.texture = www.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
