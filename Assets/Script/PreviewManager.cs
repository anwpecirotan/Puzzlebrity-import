using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewManager : MonoBehaviour {
	public Animator previewAnim;
	public bool showing;

	// Use this for initialization
	void Start () {
		showing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown()
	{
		if (!showing) {
			showing = true;
			previewAnim.SetBool ("Show", true);
		} else {
			showing = false;
			previewAnim.SetBool ("Show", false);
		}
	}

	public void ClosePreview()
	{
		showing = false;
		previewAnim.SetBool ("Show", false);
	}
}
