using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlace : MonoBehaviour
{


	public Turret[] turrets = new Turret[4];

	private bool flag = false;
	private bool isInstall = false;

	private Vector3 screenTransform;

	private void Start()
	{
		screenTransform = Camera.main.WorldToScreenPoint(transform.position);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Input.mousePosition.x >= screenTransform.x - 150 &&
				Input.mousePosition.x <= screenTransform.x + 150 &&
				Input.mousePosition.y >= screenTransform.y - 150 &&
				Input.mousePosition.y <= screenTransform.y + 150)
			{
				if (!flag)
				{
					print("µé¾î¿È");
					flag = true;
				}
				else
				{
					print("³ª°¨");
					flag = false;
				}
			}
		}
	}
}

[Serializable]
public class Turret
{
	public GameObject prefab;
	public Mesh[] looks = new Mesh[3];
}