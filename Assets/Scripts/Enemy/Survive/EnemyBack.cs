using UnityEngine;
using System.Collections;

public class EnemyBack : MonoBehaviour {

	public GameObject front;
	public GameObject back;

	private GameObject tail;
	private GameObject headFromPool;
	private GameObject headSprite;

	private int number;
	private float speed;
	private EnemyHead head;

	private GameObject tempFront;
	private GameObject tempBack;

	private bool creatingHead;
	private bool creatingTail;

	private Vector3 moveDirection;

	private GameObject score;

	private ScaleInPool scaleInPull;
	private bool waiting;

	void Start () {
		creatingHead = false;
		creatingTail = false;
		waiting = false;

		transform.position = GameObject.Find ("Head").transform.position;

		SelectedSkin selectedSkin = GameObject.Find ("SelectedSkin").GetComponent<SelectedSkin> ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = selectedSkin.backSprites [selectedSkin.skinId];

		score = GameObject.Find("Score");
	}

	void OnEnable() {
		creatingHead = false;
		creatingTail = false;
		waiting = false;
	}


	void Update() {
		speed = EnemyHead.speed / 10.0f;

		if (front != null)
		{
			transform.position = Vector3.Lerp(transform.position, front.transform.position, speed);

			moveDirection = front.transform.position - transform.position;
			if (moveDirection != Vector3.zero)
			{
				float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		}
		if (!front.activeSelf || !back.activeSelf) {
			if (!waiting)
				StartCoroutine(wait());
		}
			
		if(front == null || front.activeSelf == false) {
			if (!creatingHead) {
				StartCoroutine(createHead());
			}
		}
		if (back == null || back.activeSelf == false) {
			if(!creatingTail)
			StartCoroutine(createTail());
		}
	}


	//Логика разрубаия змеи
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			score.GetComponent<ScoreCounter> ().score += 0.3f;
			ScalePool.goInPool(gameObject);
		}
	}


	IEnumerator createHead()
	{
		creatingHead = true;
		yield return new WaitForSeconds(0.5f);
		if (front == null || front.activeSelf == false)
		{
			headFromPool = HeadPool.getHead();
			headFromPool.GetComponent<EnemyHead>().firstStart = false;
			headFromPool.transform.position = gameObject.transform.position;
			if (gameObject.GetComponent<EnemyBack>() != null)
			{
				gameObject.GetComponent<EnemyBack>().front = headFromPool;
				headFromPool.GetComponent<EnemyHead>().back = gameObject;
			}

			headSprite = HeadPool.getHeadSprite();
			if (headSprite != null)
			{
				headSprite.transform.position = headFromPool.transform.position;
				headSprite.GetComponent<HeadSprite>().head = headFromPool;
				headSprite.transform.localScale = new Vector3(0, 0, 0);
			}
			yield return new WaitForSeconds(0.01f);
			headFromPool.GetComponent<EnemyHead>().isPlayerOnTarget = true;
			for (int i = 0; i < 28; i++)
			{
				headSprite.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
				yield return new WaitForSeconds(0.01f);
			}

			yield return new WaitForSeconds(0.05f);
			creatingHead = false;
			yield return new WaitForSeconds(Random.Range(5f, 25f));
			headSprite.GetComponent<HeadSprite>().secondaryHead = true;
			headFromPool.GetComponent<EnemyHead>().secondaryHead = true;
		}
		else {
			creatingHead = false;
		}
	}

	IEnumerator createTail()
	{
		creatingTail = true;
		yield return new WaitForSeconds(0.5f);
		if (back == null || back.activeSelf == false)
		{
			if (back == null || back.activeSelf == false)
			{
				tail = TailPool.getTail();
				tail.transform.localScale = new Vector3(0, 0, 0);
				tail.transform.position = gameObject.transform.position;
				if (gameObject.GetComponent<EnemyBack>() != null && tail != null)
				{
					gameObject.GetComponent<EnemyBack>().back = tail;
					tail.GetComponent<EnemyTail>().front = gameObject;
				}
				yield return new WaitForSeconds(0.05f);
				for (int i = 0; i < 22; i++)
				{
					if (tail != null)
					{
						tail.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
						yield return new WaitForSeconds(0.01f);
					}
				}
			}
		}
	
		
			creatingTail = false;
		
	}

	IEnumerator wait() {
		waiting = true;
		yield return new WaitForSeconds(0.55f);
		if (!front.activeSelf || !back.activeSelf)
			ScalePool.goInPool(gameObject);
		waiting = false;
	}
}