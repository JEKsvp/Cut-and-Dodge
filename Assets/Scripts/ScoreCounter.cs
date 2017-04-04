using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public float score;
	public float speed;
	private float temp;

	void Start () {
	}

	void Update () {
	
	}

	void FixedUpdate(){
		if (EnemyHead.speed != 0 && GameObject.FindGameObjectsWithTag ("EnemyHead").Length > 0) {
			switch (GameObject.FindGameObjectsWithTag ("EnemyHead").Length) {
			case 0:
				GameStatus.gameStatus = "GameOver";
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100);//Бонус за убийство всех змей
					break;
			case 1:
				speed = 1f;
				break;
			case 2:
				speed = 2.5f;
				break;
			case 3:
				speed = 8f;
				break;
			case 4:
				speed = 15f;
				break;
			case 5:
				speed = 25f;
				break;
			case 6:
				speed = 40f;
				break;
			default:
				speed = 25;
				break;
			}
		} else {
			speed = 0;
		}

		//Подсчёт счёта
		score += 0.006f * speed;
		score = (float) System.Math.Round (score, 2);
		if (score % 10 != 0) {
			temp = (float) System.Math.Round (score, 0);
			gameObject.GetComponent<Text> ().text = temp + "";
		}
	}
}
