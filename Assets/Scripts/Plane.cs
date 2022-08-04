using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
	private int count = -1;
	private Vector3[] path = new Vector3[]
	{
		Vector3.left,
		Vector3.forward,
		Vector3.left,
		Vector3.back,
		Vector3.right,
		Vector3.forward,
		Vector3.left,
		Vector3.back
	};

	private void Start()
	{
		Time.timeScale = 3;
		StartCoroutine(TurnAngle());
	}

	private void Update()
	{
		transform.Translate(path[count + 1] * Time.deltaTime, 0);
	}

	private IEnumerator TurnAngle()
	{
		Vector3 startPath = new Vector3(3.4f, 1.3f, 0f);
		Vector3[] turnPath = new Vector3[]
		{
			new Vector3(3.4f,1.3f,3.4f),
			new Vector3(-3.6f,1.3f,3.4f),
			new Vector3(-3.6f,1.3f,-3.4f),
			new Vector3(3.4f,1.3f,-3.4f),
			new Vector3(3.4f,1.3f,3.4f),
			new Vector3(-3.6f,1.3f,3.4f),
		};
		Vector3[] angle = new Vector3[]
		{
			new Vector3(0,0,0),
			new Vector3(0,-90,0),
			new Vector3(0,-180,0),
			new Vector3(0,90,0),
			new Vector3(0,0,0),
			new Vector3(0,-90,0),
			new Vector3(0,-180,0)
		};
		
		while (startPath.z.Equals(Mathf.Floor(transform.position.z * 10) * 0.1f))
		{
			if (startPath.x.Equals(Mathf.Floor(transform.position.x * 10) * 0.1f)) break;
			yield return null;
		}

		print("넘어감");
		transform.position = startPath;
		count++;
		transform.eulerAngles = angle[count];

		while (count < 6)
		{
			// 이거 왜 안돼...
			if (count == 1)
			{
				print("X : " + turnPath[count].x.Equals(Mathf.Floor(transform.position.x * 10) * 0.1f));
				print("Z : " + turnPath[count].z.Equals(Mathf.Floor(transform.position.z * 10) * 0.1f));
				print(turnPath[count].x);
				print(Mathf.Floor(transform.position.x * 10) * 0.1f);
				if ((Mathf.Floor(transform.position.x * 10) * 0.1f).Equals(turnPath[count].x))
				{
					print("!!!!!!!!!!");
				}
			}
			if (turnPath[count].x.Equals(Mathf.Floor(transform.position.x * 10) * 0.1f) &&
			    turnPath[count].z.Equals(Mathf.Floor(transform.position.z * 10) * 0.1f))
			{
				transform.position = turnPath[count];
				count++;
				transform.eulerAngles = angle[count];
			}
			yield return null;
		}
	}
}
