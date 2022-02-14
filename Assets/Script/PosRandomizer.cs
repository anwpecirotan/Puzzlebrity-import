using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRandomizer : MonoBehaviour {

	public Transform [] pos;
	public GameObject [] piece;
	public int [] posFill;

	// Use this for initialization
	void Start () {
		int x;
		for (int i = 0; i < piece.Length; i++) {
			do {
				x = Random.Range (0, pos.Length);
			} while(posFill [x] != 0);
			piece [i].transform.position = pos[x].position;
			posFill [x] = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
