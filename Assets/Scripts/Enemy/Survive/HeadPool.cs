using UnityEngine;
using System.Collections;

public class HeadPool : MonoBehaviour {

	public static GameObject[] headPool;
	private static GameObject headInPool;

	public static GameObject[] headSpritesPool;
	private static GameObject headspritesInPool;


	void Start () {
		headPool = new GameObject[9];
		headSpritesPool = new GameObject[9];
		for (int i = 0; i < 9; i++)
		{
			headPool[i] = Instantiate(Resources.Load("Prefabs/Survive/HeadCopy")) as GameObject;
			headSpritesPool[i] = Instantiate(Resources.Load("Prefabs/Survive/HeadSprite")) as GameObject;
			headPool[i].SetActive(false);
			headSpritesPool[i].SetActive(false);
		}
	}

	public static GameObject getHead() {
		for (int i = 0; i < 9; i++)
		{
			if (headPool[i] != null)
			{
				headInPool = headPool[i];
				headPool[i] = null;
				break;
			}
		}
		headInPool.SetActive(true);
		return headInPool;
	}

	public static void goHeadInPool(GameObject head)
	{
		for (int i = 0; i < 9; i++)
		{
			if (headPool[i] == null)
			{
				headPool[i] = head;
				head.GetComponent<EnemyHead>().back = null;
				break;
			}
		}
		head.SetActive(false);
	}

	public static GameObject getHeadSprite()
	{
		for (int i = 0; i < 9; i++)
		{
			if (headSpritesPool[i] != null)
			{
				headspritesInPool = headSpritesPool[i];
				headSpritesPool[i] = null;
				break;
			}
		}
		headspritesInPool.SetActive(true);
		return headspritesInPool;
	}

	public static void goHeadSpriteInPool(GameObject headSprite)
	{
		for (int i = 0; i < 9; i++)
		{
			if (headSpritesPool[i] == null)
			{
				headSpritesPool[i] = headSprite;
				headSprite.GetComponent<HeadSprite>().head = null;
				break;
			}
		}
		headSprite.SetActive(false);
	}
}
