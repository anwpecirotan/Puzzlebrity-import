using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageRandomizer : MonoBehaviour {

	public Sprite[] puzzleImages;
	public SpriteRenderer[] puzzlePieces;
	public int randNumber;
	public Text mosqueTitleText;
	public string[] mosqueTitle;
    public string[] mosqueInfo;
    public Text winInfo;

    public SpriteRenderer previewImage;
	public Sprite[] previewsPool;

    //PLAYERPREFS "lastlevel" untuk menyimpan agar level selanjutnya bukan level yang barusan dimainkan
    //PLAYERPREFS "selectedlevel" untuk menyimpan level apa yang ingin dimainkan

    // Use this for initialization
    void Start () {
        //do {
        //	randNumber = Random.Range (0, (puzzleImages.Length / 20));
        //} while(randNumber == PlayerPrefs.GetInt ("lastlevel"));

        //PlayerPrefs.SetInt ("lastlevel", randNumber);

        randNumber = PlayerPrefs.GetInt("selectedlevel");

		for (int i = 0, j = randNumber*puzzlePieces.Length; i < puzzlePieces.Length; i++,j++) {
			puzzlePieces [i].sprite = puzzleImages [j];
		}

		mosqueTitleText.text = mosqueTitle [randNumber];
		previewImage.sprite = previewsPool [randNumber];
        winInfo.text = mosqueInfo[randNumber];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			do {
				randNumber = Random.Range (0, (puzzleImages.Length / 20));
			} while(randNumber == PlayerPrefs.GetInt ("lastlevel"));

			PlayerPrefs.SetInt ("lastlevel", randNumber);

			for (int i = 0, j = randNumber*puzzlePieces.Length; i < puzzlePieces.Length; i++,j++) {
				puzzlePieces [i].sprite = puzzleImages [j];
			}

			mosqueTitleText.text = mosqueTitle [randNumber];
			previewImage.sprite = previewsPool [randNumber];
            winInfo.text = mosqueInfo[randNumber];
        }
	}
}
