using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour {

	public int counter;
	public GameObject winScreen;
	public AudioSource BGM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= 20) {
			winScreen.SetActive (true);
			if (BGM.isPlaying) {
				BGM.Stop ();
			}
		}
	}

	public void PlayAgain()
	{
        PlayerPrefs.SetInt("selectedlevel", Random.Range(0, 11));
		Application.LoadLevel ("Prototype");
	}
}
