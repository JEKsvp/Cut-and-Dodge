using UnityEngine;
using System.Collections;

public struct ScaleInPool {
	public GameObject scale;
	public int count;
}

public class ScalePool : MonoBehaviour {

	public static ScaleInPool[] scalesInPool;

	public GameObject mainHead;
	private GameObject tempBack;
	private GameObject tempTail;

	private int[] edge;

	void Start () {		
		scalesInPool = new ScaleInPool[50];

		edge = new int[50];
		for (int i = 0; i < edge.Length; i++) {
			edge[i] = Random.Range(500, 3000);
		}
	}
	
	void Update () {
		for (int i = 0; i < ScalePool.scalesInPool.Length; i++){
			if (scalesInPool[i].scale != null)
			{
				scalesInPool[i].count += 1;
				if (scalesInPool[i].count > edge[i])
				{
					backToCreature(scalesInPool[i].scale, i);
				}
			}
		}

		if (GameStatus.gameStatus == "GameOver") {
			Destroy(gameObject);
		}
	}

	void backToCreature(GameObject scale, int numberInPool) {
		tempBack = mainHead.GetComponent<EnemyHead>().back;
		
		scale.transform.position = tempBack.transform.position;
		if (tempBack.GetComponent<EnemyBack>().back.GetComponent<EnemyBack>() != null)
		{
			scale.GetComponent<EnemyBack>().back = tempBack.GetComponent<EnemyBack>().back;
			tempBack.GetComponent<EnemyBack>().back.GetComponent<EnemyBack>().front = scale;
		}
		else {
			scale.GetComponent<EnemyBack>().back = tempBack.GetComponent<EnemyBack>().back;
			tempBack.GetComponent<EnemyBack>().back.GetComponent<EnemyTail>().front = scale;
		}
		scale.GetComponent<EnemyBack>().front = tempBack;
		tempBack.GetComponent<EnemyBack>().back = scale;
		
		scale.SetActive(true);

		scalesInPool[numberInPool].scale = null;
		scalesInPool[numberInPool].count = 0;
		tempBack = mainHead.GetComponent<EnemyHead>().back;
	}

	public static void goInPool(GameObject back) {
		for (int i = 0; i < scalesInPool.Length; i++)
		{
			if (scalesInPool[i].scale == null)
			{
				scalesInPool[i].scale = back;
				back.GetComponent<EnemyBack>().back = null;
				back.GetComponent<EnemyBack>().back = null;
				back.SetActive(false);
				break;
			}
		}
	}
}
