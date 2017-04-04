using UnityEngine;
using System.Collections;

public class EnemyHead : MonoBehaviour {

	public static float speed;
	public GameObject back;

	//Движение змеи
	private Vector3 direction;
	private Vector3 screenSize;
	private float angle;
	public bool isPlayerOnTarget;
	public bool firstStart;
	private Vector3 startPoint;
	private Vector3 pointOnCircle;

	//Работа со счётом
	private ScoreCounter score;
	private int tempscore;

	public bool secondaryHead;
	private GameObject mainHead;
	private GameObject tempBack;
	private GameObject tempTail;
	private GameObject player;
	private bool attachingCreature;

	void Start () {

		attachingCreature = false;
		mainHead = GameObject.Find("Pool").GetComponent<ScalePool>().mainHead;
		secondaryHead = false;

		score = GameObject.Find ("Score").GetComponent<ScoreCounter> ();
		tempscore = 1;

		StartCoroutine(goToPlayer());
		
		//Подгрузка данных для ограничения движения змеи
		float width = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2 (width, height));
		pointOnCircle = randomPiontOnCircle();
		direction = new Vector3 (pointOnCircle.x, pointOnCircle.y, 0f);

		if(firstStart){
			transform.position = new Vector3 (Random.Range(-screenSize.x, screenSize.x),screenSize.y + 2);
			startPoint = new Vector3 (Random.Range (-screenSize.x, screenSize.x), Random.Range (-screenSize.y, screenSize.y), 0);
		}
		player = GameObject.Find("Player");

	}

	void OnEnable() {
		attachingCreature = false;
		secondaryHead = false;
		StartCoroutine(goToPlayer());
	}



void Update() {

		if (player == null) {
			player = GameObject.Find("Player");
		}

		//Логика движения змеи

		if (!secondaryHead)
		{
			if (firstStart)
			{
				if (transform.position != startPoint)
					transform.position = Vector3.MoveTowards(transform.position, startPoint, Time.deltaTime * speed);
				else
					firstStart = false;
			}
			else
			{
				if (isPlayerOnTarget)
				{
					transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
					pointOnCircle = randomPiontOnCircle();
					direction = new Vector3(pointOnCircle.x, pointOnCircle.y, 0f);
				}
				else
				{
					if (Mathf.Abs(transform.position.x) >= Mathf.Abs(screenSize.x) || Mathf.Abs(transform.position.y) >= Mathf.Abs(screenSize.y))
					{

						if (Mathf.Abs(transform.position.x) >= Mathf.Abs(screenSize.x))
						{
							direction = new Vector3(-direction.x, randomPiontOnCircle().y, 0f);
							transform.Translate(direction * Time.deltaTime * speed);
							if (Mathf.Abs(transform.position.x) >= Mathf.Abs(screenSize.x))
							{
								transform.Translate(direction * Time.deltaTime * speed);
								if (Mathf.Abs(transform.position.y) >= Mathf.Abs(screenSize.x))
								{
									isPlayerOnTarget = true;
								}
							}

						}
						if (Mathf.Abs(transform.position.y) >= Mathf.Abs(screenSize.y))
						{
							direction = new Vector3(randomPiontOnCircle().x, -direction.y, 0f);
							transform.Translate(direction * Time.deltaTime * speed);
							if (Mathf.Abs(transform.position.y) >= Mathf.Abs(screenSize.x))
							{
								transform.Translate(direction * Time.deltaTime * speed);
								if (Mathf.Abs(transform.position.y) >= Mathf.Abs(screenSize.x))
								{
									isPlayerOnTarget = true;
								}
							}
						}
					}
					else
					{
						transform.Translate(direction * Time.deltaTime * speed);
					}
				}

				if (back == null)
				{
					HeadPool.goHeadInPool(gameObject);
				}
			}
		}
		else {
			tempBack = mainHead.GetComponent<EnemyHead>().back;
			if (tempBack != null)
			{
				for (int i = 0; i < 50; i++)
				{
					if (tempBack.GetComponent<EnemyBack>().back != null)
					{
						if (tempBack.GetComponent<EnemyBack>().back.GetComponent<EnemyTail>() != null)
						{
							tempTail = tempBack.GetComponent<EnemyBack>().back;
							break;
						}
						tempBack = tempBack.GetComponent<EnemyBack>().back;
					}
					else
					{
						break;
					}
				}
			}
			transform.position = Vector3.MoveTowards(transform.position, tempBack.transform.position, Time.deltaTime * speed * 1.5f);
			if (!attachingCreature)
				StartCoroutine(attachCreature());
		}

		if (back.GetComponent<EnemyBack>().front != gameObject) {
			HeadPool.goHeadInPool(gameObject);
		}

		//Логика скорости
		if (System.Math.Round (score.score) % 10 == 0 && score.score  > tempscore) {
			Debug.Log ("+ Speed");
			speed += 0.05f / GameObject.FindGameObjectsWithTag("EnemyHead").Length;
			tempscore += 10;
		}

}


	//Вспомогательный метод для движения змеи
	private Vector2 randomPiontOnCircle(){
		float angle = Random.Range (0f, 2 * Mathf.PI);
		Vector2 point = new Vector2 (Mathf.Sin (angle), Mathf.Cos (angle));
		return point;
	}

	//Корутина для флага
	IEnumerator goToPlayer(){
		int headsNumber = 0;
		while (true) {
				headsNumber = GameObject.FindGameObjectsWithTag("EnemyHead").Length;
				switch (headsNumber)
				{
					case 1:
						if (Random.Range(0f, 100f) > 65f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
					case 2:
						if (Random.Range(0f, 100f) >90f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
					case 3:
						if (Random.Range(0f, 100f) > 95f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
					case 4:
						if (Random.Range(0f, 100f) > 98f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
					case 5:
						if (Random.Range(0f, 100f) > 99f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
					case 6:
						if (Random.Range(0f, 100f) > 99f)
							isPlayerOnTarget = true;
						else
							isPlayerOnTarget = false;
						break;
				}
			yield return new WaitForSeconds (Random.Range(1.5f, 3f));
		}
	}

	float getAngle(Vector2 center, Vector2 point){
		return Mathf.Atan2 (center.y - point.y, point.x - center.x) * (180 / Mathf.PI) - 90;
	}

	public IEnumerator attachCreature() {
		tempBack = mainHead.GetComponent<EnemyHead>().back;
		if (tempBack != null)
		{
			for (int i = 0; i < 50; i++) {
				if (tempBack.GetComponent<EnemyBack>().back != null)
				{
					if (tempBack.GetComponent<EnemyBack>().back.GetComponent<EnemyTail>() != null)
					{
						tempTail = tempBack.GetComponent<EnemyBack>().back;
						break;
					}
					tempBack = tempBack.GetComponent<EnemyBack>().back;
				}
				else {
					break;
				}
			}
		}
		attachingCreature = true;
		yield return new WaitForSeconds(0.8f);
		tempBack.GetComponent<EnemyBack>().back = back;
		back.GetComponent<EnemyBack>().front = tempBack;
		TailPool.goInPool(tempTail);
		HeadPool.goHeadInPool(gameObject);
	}
}
