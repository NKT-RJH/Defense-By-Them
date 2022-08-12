using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlace : MonoBehaviour
{
	public TurretData[] turrets = new TurretData[4];
	public Transform UI;

	private bool flag = false;
	private int isInstall = -1;
	private int level = 0;
	private int clickPath = 200;

	private Vector3 screenTransform;

	private Vector3[] turretPaths = new Vector3[4]
	{
		new Vector3(0.02f,0.73f,0.1f),
		new Vector3(0.02f,0.53f,0.1f),
		new Vector3(0.02f,0.83f,0.1f),
		new Vector3(0.02f,0.63f,0.08f)
	};

	private void Start()
	{
		screenTransform = Camera.main.WorldToScreenPoint(transform.position);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Input.mousePosition.x >= screenTransform.x - 200 &&
				Input.mousePosition.x <= screenTransform.x + clickPath &&
				Input.mousePosition.y >= screenTransform.y - 175 &&
				Input.mousePosition.y <= screenTransform.y + 175)
			{
				if (!flag)
				{
					if (isInstall < 0)
					{
						SetUI(true, false);
					}
					else
					{
						SetUI(false, true);
					}
					flag = true;
					clickPath += 100;
				}
				else
				{
					//SetUI(false , false);
					flag = false;
					clickPath -= 100;
				}
			}
			else
			{
				SetUI(false, false);
			}
		}
	}

	private void SetUI(bool install, bool upgrade)
	{
		UI.GetChild(0).gameObject.SetActive(install);
		UI.GetChild(1).gameObject.SetActive(upgrade);
	}

	public void InstallOne()
	{
		Instantiate(turrets[0].prefab, turretPaths[0] + transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), transform);
		isInstall = 0;
		SetUI(false, false);
	}

	public void InstallTwo()
	{
		Instantiate(turrets[1].prefab, turretPaths[1] + transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), transform);
		isInstall = 1;
		SetUI(false, false);
	}

	public void InstallThree()
	{
		Instantiate(turrets[2].prefab, turretPaths[2] + transform.position, Quaternion.Euler(new Vector3(-90, 60, 0)), transform);
		isInstall = 2;
		SetUI(false, false);
	}

	public void InstallFour()
	{
		Instantiate(turrets[3].prefab, turretPaths[3] + transform.position, Quaternion.Euler(new Vector3(-90, 30, 0)), transform);
		isInstall = 3;
		SetUI(false, false);
	}

	public void Upgrade()
	{
		Turret turret = transform.GetChild(0).GetComponent<Turret>();
		if (turret.level < 2)
		transform.GetChild(0).GetComponent<MeshFilter>().mesh = turrets[isInstall].looks[++level];
		turret.LevelUp();
		SetUI(false, false);
	}

	public void Destroy()
	{
		if (transform.childCount != 1) return;
		DestroyImmediate(transform.GetChild(0).gameObject);
		isInstall = -1;
		SetUI(false, false);
	}
}

[Serializable]
public class TurretData
{
	public GameObject prefab;
	public Mesh[] looks = new Mesh[3];
}