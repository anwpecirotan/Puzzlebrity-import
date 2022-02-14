using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour {

	public Text timerText;
	public Text timerRecord;
	public int minuteCount;
	public int secondCount;

	private string minutes;
	private string seconds;

	private float coolDown;
	private float actualCoolDown;
	private WinningManager theWin;

	// Use this for initialization
	void Start () {
		actualCoolDown = 0;
		coolDown = 1;
		minuteCount = 0;
		secondCount = 0;
		theWin = FindObjectOfType<WinningManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (theWin.counter < 20) {
			actualCoolDown += Time.deltaTime;
		}

		if (actualCoolDown >= coolDown) {
			actualCoolDown = 0;
			secondCount++;
		}

		if (secondCount > 59) {
			minuteCount++;
			secondCount = 0;
		}

		if (minuteCount < 10) {
			minutes = "0" + minuteCount.ToString();
		} else {
			minutes = minuteCount.ToString();
		}

		if (secondCount < 10) {
			seconds = "0" + secondCount.ToString ();
		} else {
			seconds = secondCount.ToString ();
		}

		timerText.text = minutes + ":" + seconds;
		timerRecord.text = "Durasi: " + minutes + " : " + seconds;
	}
}
