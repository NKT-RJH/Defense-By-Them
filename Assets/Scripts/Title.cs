using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
	public Text pressToStart;

	public GameObject buttons;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void FirstLoad()
	{
		print("프레임 고정");
		Application.targetFrameRate = 60;
	}

	private void Start()
	{
		Time.timeScale = 1;
		StartCoroutine(PressToStart());
	}

	private IEnumerator PressToStart()
	{
		GameObject game = pressToStart.gameObject;
		float countTime = Time.time;
		while(!(Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2)))
		{
			if (Time.time - countTime >= 0.5f)
			{
				game.SetActive(!game.activeSelf);
				countTime = Time.time;
			}
			yield return null;
		}
		game.SetActive(true);

		int count = 255;
		while (count > 0)
		{
			pressToStart.color = new Color(pressToStart.color.r, pressToStart.color.g, pressToStart.color.b, count / 255f);
			count -= 5;
			yield return null;
		}
		game.SetActive(false);

		buttons.SetActive(true);
	}

	public void Play()
	{
		//중간에 게임 씬 넣기
		SceneManager.LoadScene("Fight");
	}

	public void Help()
	{
		// 이거 만들고 포탑 손보기!!
	}

	public void Credits()
	{

	}

	public void Quit()
	{
		Application.Quit();
	}
}
