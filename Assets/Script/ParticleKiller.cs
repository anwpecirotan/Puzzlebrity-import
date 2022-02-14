using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartCoroutine ("KillMe");
	}
	
	public IEnumerator KillMe()
	{
		yield return new WaitForSeconds (0.8f);
		Destroy (gameObject);
	}
}
