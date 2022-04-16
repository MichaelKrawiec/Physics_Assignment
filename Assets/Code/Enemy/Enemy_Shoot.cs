using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
	public Transform player;
	private bool onRange = false;
	public float range = 10.0f;
	Ship_Steering ship_Steering;

	[SerializeField]
	GameObject bullet;

	public float fireRate;
	public float nextFire;

	// Use this for initialization
	void Start()
	{
		ship_Steering = GameObject.Find("player").GetComponent<Ship_Steering>();
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (ship_Steering.isActiveAndEnabled)
		{
			if (onRange)

				CheckIfTimeToFire();
			onRange = Vector3.Distance(transform.position, player.position) < range;
		}


	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			if (onRange)
			{
				Instantiate(bullet, transform.position, Quaternion.identity);
				nextFire = Time.time + fireRate;
			}

		}

	}


}
