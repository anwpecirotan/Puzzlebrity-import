using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour {

	public bool activated;
	public bool moving;
	public PuzzleController[] otherPuzzles;
	public PlateController[] thePlates;

	public int target;
	public GameObject myGoal;
	public bool finished;

	public Vector3 initPos;
	public PoolCollider thePool;
	public Animator myAnim;

	public GameObject edgeGlow;
	public WinningManager theWinning;
	public SpriteRenderer mySprite;
	private PreviewManager thePreview;

	public AudioSource puzzleActive, puzzlePut;
	// Use this for initialization
	void Start () {
		otherPuzzles = FindObjectsOfType<PuzzleController> ();
		StartCoroutine ("SetInitPos");
		thePool = FindObjectOfType<PoolCollider> ();
		myAnim = GetComponent<Animator> ();
		transform.localScale = new Vector2 (0.2f, 0.2f);
		theWinning = FindObjectOfType<WinningManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
		thePreview = FindObjectOfType<PreviewManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(activated || transform.position != initPos){
			transform.localScale = new Vector2 (0.41f, 0.41f);
		}else if (transform.position == initPos && !activated) {
			transform.localScale = new Vector2 (0.2f, 0.2f);
		} 

		if (activated) {
			mySprite.sortingOrder = 6;
			myAnim.SetBool ("active", true);
			for (int i = 0; i < thePlates.Length; i++) {
				if (thePlates [i].activated) {
					target = i;
					activated = false;
					moving = true;
					for (int j = 0; j < thePlates.Length; j++) {
						thePlates [j].activated = false;
						thePlates [j].clickable = false;
					}
					break;
				}
			}
		} else {
			myAnim.SetBool ("active", false);
			mySprite.sortingOrder = 5;
		}

		if (moving) {
			if (target == thePlates.Length-1) {
				transform.position = Vector2.MoveTowards (transform.position, initPos, 20 * Time.deltaTime);
				if (transform.position == initPos) {
					moving = false;
					activated = false;
					puzzlePut.Play ();
					transform.localScale = new Vector2 (0.41f, 0.41f);
				}
			} else {
				transform.position = Vector2.MoveTowards (transform.position, thePlates [target].transform.position, 20 * Time.deltaTime);
				if (transform.position == thePlates [target].transform.position) {
					moving = false;
					activated = false;
					puzzlePut.Play ();
				}
			}

		}

		if (transform.position == myGoal.transform.position) {
			if (!finished) {
				Instantiate (edgeGlow, transform.position, transform.rotation);
				theWinning.counter++;
				puzzlePut.Play ();
			}
			finished = true;
			activated = false;
			transform.localScale = new Vector2 (0.41f, 0.41f);
		}
	}

	public void OnMouseDown()
	{
		thePreview.ClosePreview ();
		print ("YIHA");
		thePlates [target].myCollider.enabled = true;
		if (thePool.oneSelected == false) {
			if (!finished) {
				thePool.oneSelected = true;
				if (activated == false) {
					for (int i = 0; i < otherPuzzles.Length; i++) {
						otherPuzzles [i].activated = false;
					}
					activated = true;
					puzzleActive.Play ();
					for (int i = 0; i < thePlates.Length; i++) {
						thePlates [i].clickable = true;
					}
				} else {
					for (int i = 0; i < otherPuzzles.Length; i++) {
						otherPuzzles [i].activated = false;
					}
					activated = false;
					for (int i = 0; i < thePlates.Length; i++) {
						thePlates [i].clickable = false;
					}
				}
			}
		} else {
			if (transform.position != initPos) {
				if (!finished) {
					for (int i = 0; i < otherPuzzles.Length; i++) {
						if (otherPuzzles [i].activated) {
							otherPuzzles [i].target = target;
							otherPuzzles [i].moving = true;
							break;
						}
					}
					for (int j = 0; j < thePlates.Length; j++) {
						thePlates [j].activated = false;
						thePlates [j].clickable = false;
					}
					target = thePlates.Length - 1;
					moving = true;
					thePool.oneSelected = false;
				}
			} else {
				print ("No Can Doo");
			}
		}
	}

	public IEnumerator SetInitPos()
	{
		yield return new WaitForSeconds (0.3f);
		initPos = transform.position;
	}
}
