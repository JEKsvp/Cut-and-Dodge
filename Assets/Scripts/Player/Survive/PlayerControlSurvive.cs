using UnityEngine;
using System.Collections;

public class PlayerControlSurvive : MonoBehaviour {

	public PlayerSurvive selectedPlayer;
	private Vector3 cour;
	private Collider2D[] all;

	private bool isStart;

	void Start () {
		isStart = true;

		all = new Collider2D[50];
	}

	void Update () {

			cour = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.touchCount > 1)
		{
			selectedPlayer = null;
		}
		else
		{

			if (Input.GetMouseButton(0))
			{

				if (selectedPlayer == null)
				{
					all = Physics2D.OverlapCircleAll((Vector2)cour, 0.25f);
					foreach (var item in all)
					{
						if (item.GetComponent<PlayerSurvive>())
						{
							selectedPlayer = item.GetComponent<PlayerSurvive>();
						}
					}
				}

				if (selectedPlayer != null)
				{
					if (isStart)
					{
						EnemyHead.speed = 3;
						PlayerSurvive.isPlaying = true;
						isStart = false;
						GameStatus.gameStatus = "Playing";
					}
					GameObject.Find("OuterPart").GetComponent<Rotation>().speed = 1000f;
					selectedPlayer.transform.position = Vector3.MoveTowards(selectedPlayer.transform.position, new Vector2(cour.x, cour.y), Time.deltaTime * 10000f);
				}

			}

			if (Input.GetMouseButtonUp(0))
			{
				selectedPlayer = null;
				if (GameObject.Find("OuterPart") != null)
				{
					GameObject.Find("OuterPart").GetComponent<Rotation>().speed = 100f;
				}
			}
		}
	}
}
