using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedChecker : MonoBehaviour {

	public PuzzleController[] puzzlePieces;
	public PlateController[] platePieces;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for (int j = 0; j < platePieces.Length; j++) {
			platePieces [j].myCollider.enabled = true;
		}

		for (int i = 0; i < puzzlePieces.Length; i++) {
			for (int j = 0; j < platePieces.Length; j++) {
				if (puzzlePieces [i].transform.position == platePieces [j].transform.position) {
					platePieces [j].myCollider.enabled = false;
					break;
				}
			}
		}
	}
}
