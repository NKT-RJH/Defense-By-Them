using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faster : MonoBehaviour
{
	public Text text;

	private int faster = 1;

	private void Awake()
	{
		Time.timeScale = faster;
	}

	public void SetFaster()
	{
		if (!text) return;

		faster += faster < 3 ? 1 : -2;
		Time.timeScale = faster;

		text.text = string.Format("x{0}", faster);
	}
}
