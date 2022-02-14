using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	public GameObject loadingScreenObj;
	public Image blackScreen;
	public Slider slider;

	AsyncOperation async;

	public void LoadScreenExample()
	{
		StartCoroutine ("FadeOut");
	}

	IEnumerator TheLoadingScreen()
	{
		blackScreen.gameObject.SetActive (true);
		loadingScreenObj.SetActive(true);
		async = SceneManager.LoadSceneAsync(1);
		async.allowSceneActivation = false;

		while(async.isDone == false)
		{
			slider.value = async.progress;
			if(async.progress == 0.9f)
			{
				slider.value=1f;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}

	public IEnumerator FadeOut()
	{
		blackScreen.gameObject.SetActive (true);
		for (float i = 0; i <= 0.5f; i += Time.deltaTime)
		{
			// set color with i as alpha
			blackScreen.color = new Color(0, 0, 0, i*2);
			yield return null;
		}
		StartCoroutine (TheLoadingScreen ());
	}
}
