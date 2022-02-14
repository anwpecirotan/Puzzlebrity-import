using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	public Vector2 initialPosition;
	private SpriteRenderer mySprite;
	private BoxCollider2D myBoxCollider;

	//Ukuran No
	public Vector3 startSize;
	public Vector3 clickedSize;

	//Target dimana objek harus diletakkan
	public GameObject targetObject;
	public GameObject platePool;

	//Apakah objek sudah di posisi target
	public bool onTarget;
	public bool onPlate;

	//Apakah objek sudah terkunci di posisi target
	public bool locked;
	public WinningManager theManager;

	//public RectTransform myRect;
	public GameObject edgeGlowEffect;
	private PreviewManager thePreview;

	// Use this for initialization
	void Start () {
		locked = false;
		onTarget = false;
		thePreview = FindObjectOfType<PreviewManager> ();
		//StartCoroutine ("SetInitPos");
		theManager = FindObjectOfType<WinningManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
		myBoxCollider = GetComponent<BoxCollider2D> ();
		//myRect = GetComponent<RectTransform> ();
	}

//	void Update()
//	{
//		if (transform.position.y <= platePool.transform.position.y) {
//			onPlate = true;
//		} else {
//			onPlate = false;
//		}
//	}
		
//	private void OnMouseDown()
//	{
//		if (locked == false) {
//			deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
//			deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
//			transform.localScale = clickedSize;
//			thePreview.ClosePreview();
//		}
//	}

//	private void OnMouseDrag()
//	{
//		if (locked == false) {
//			mySprite.sortingOrder = 20;
//			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y + 1);
//		}
//	}

//	private void OnMouseUp()
//	{
//		if (!onTarget && !onPlate) {
//			//transform.position = new Vector2 (initialPosition.x, initialPosition.y);
//			//transform.localScale = startSize;
//			mySprite.sortingOrder = 5;
//			//myRect.offsetMin = new Vector2 (0, 0);
//			//myRect.offsetMax = new Vector2 (0, 0);
//		}
//		else if(onPlate)
//		{
//			transform.position = new Vector2 (initialPosition.x, initialPosition.y);
//			transform.localScale = startSize;
//			mySprite.sortingOrder = 5;
//		}
//		else {
//			transform.position = targetObject.transform.position;
//			transform.localScale = clickedSize;
//			myBoxCollider.enabled = false;
//			mySprite.sortingOrder = 4;
//			if (!locked) {
//				Instantiate (edgeGlowEffect, transform.position, transform.rotation);
//				theManager.counter++;
//			}
//			locked = true;
//
//		}
//	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.name == targetObject.name) {
//			onTarget = true;
//		} else if (other.name == platePool.name) {
//			onPlate = true;
//		}
//	}
//
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if (other.name == targetObject.name) {
//			onTarget = false;
//		} else if (other.name == platePool.name) {
//			onPlate = false;
//		}
//	}

	public IEnumerator SetInitPos()
	{
		yield return new WaitForSeconds (0.3f);
		initialPosition = transform.position;
	}
}
