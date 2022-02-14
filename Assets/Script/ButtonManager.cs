using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public Image blackScreen;
	public GameObject pauseScreen;
	private bool paused;
	public Camera myCam;
    public bool inGame;

	// Use this for initialization
	void Start () {
		paused = false;
		Time.timeScale = 1;
		StartCoroutine ("FadeIn");
		myCam = FindObjectOfType<Camera> ();
		Debug.Log (myCam.aspect);
		if (myCam.aspect <= 0.53f) {
			myCam.orthographicSize = 6;
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
	}

	public void LoadScene(string x)
	{
		Time.timeScale = 1;
        Application.LoadLevel(x);


    }

    public void SetLevelNumber(int x)
    {
        PlayerPrefs.SetInt("selectedlevel", x);
    }

	public void ExitGame()
	{
		Application.Quit ();
	}

	//public IEnumerator FadeOut(string x)
	//{
	//	blackScreen.gameObject.SetActive (true);
	//	for (float i = 0; i <= 0.5f; i += Time.deltaTime)
	//	{
	//		// set color with i as alpha
	//		blackScreen.color = new Color(0, 0, 0, i*2);
	//		yield return null;
	//	}
	//	//yield return new WaitForSeconds (1f);
	//	Application.LoadLevel (x);
	//}

	public IEnumerator FadeIn()
	{
		for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
		{
			blackScreen.color = new Color(0, 0, 0, i*2);
			yield return null;
		}
		blackScreen.gameObject.SetActive (false);
	}

	public void PauseGame()
	{
		if (!paused) {
			Time.timeScale = 0;
			pauseScreen.SetActive (true);
			paused = true;
		} else {
			Time.timeScale = 1;
			paused = false;
			pauseScreen.SetActive (false);
		}
	}
		
}
