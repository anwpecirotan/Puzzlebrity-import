using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCollider : MonoBehaviour {

	public PuzzleController[] puzzlePiece;
	public Collider2D myColl;
	public bool oneSelected;

	// Use this for initialization
	void Start () {
		puzzlePiece = FindObjectsOfType<PuzzleController> ();
		myColl = GetComponent<Collider2D> ();
		oneSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		myColl.enabled = false;
		for (int i = 0; i < puzzlePiece.Length; i++) {
			if (puzzlePiece [i].activated && puzzlePiece[i].transform.position != puzzlePiece[i].initPos) {
				myColl.enabled = true;
				break;
			}
		}
	}
}
