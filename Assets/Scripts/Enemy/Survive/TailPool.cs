using UnityEngine;
using System.Collections;

public class TailPool : MonoBehaviour {


	public static GameObject[] tailPool;
	private static GameObject tailInPool;

	void Start () {
		tailPool = new GameObject[10];
		for (int i = 0; i < 9; i++) {
			tailPool[i] = Instantiate(Resources.Load("Prefabs/Survive/Tail")) as GameObject;
			tailPool[i].SetActive(false);
		}
	}

	public static GameObject getTail() {
		for (int i = 0; i < 10; i++) {
			if (tailPool[i] != null)
			{
				tailInPool = tailPool[i];
				tailPool[i] = null;
				break;
			}
		}
		tailInPool.SetActive(true);
		return tailInPool;
	}

	public static void goInPool(GameObject tail) {
		for (int i = 0; i < 10; i++) {
			if (tailPool[i] == null) {
				tailPool[i] = tail;
				tail.GetComponent<EnemyTail>().front = null;
				break;
			}
		}
		tail.SetActive(false);
	}
}
