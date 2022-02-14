using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour {

	public bool clickable;
	public bool activated;
	public Animator myAnim;

	public bool pool;
	public PoolCollider thePoolCollider;
	public BoxCollider2D myCollider;

	void Start () {
		thePoolCollider = FindObjectOfType<PoolCollider> ();
		clickable = false;
		myCollider = GetComponent<BoxCollider2D> ();
		if (!pool) {
			myAnim = GetComponent<Animator> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (!pool) {
			if (clickable) {
				myAnim.SetBool ("blink", true);
			} else {
				myAnim.SetBool ("blink", false);
			}
		}
	}

	public void OnMouseDown()
	{
		if (clickable) {
			activated = true;
			thePoolCollider.oneSelected = false;
		}
	}
}
