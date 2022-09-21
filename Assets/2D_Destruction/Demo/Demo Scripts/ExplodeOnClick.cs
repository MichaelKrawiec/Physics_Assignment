using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
	private Camera cam;
	private GameObject Firepoint;
	public Explodable _explodable;
	public LayerMask Hitmask;


	void Start()
	{
		_explodable = GetComponent<Explodable>();
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		Firepoint = GameObject.FindGameObjectWithTag("Firepoint");
	}


	void Update()
	{

		if (Input.GetButton("Fire1"))
		{
			FireLaser();
		}


		void FireLaser()
		{
			var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

			int hitmask = 1 << 9;

			Hitmask = hitmask;


			Vector2 direction = mousePos - (Vector2)Firepoint.transform.position;
			RaycastHit2D hit = Physics2D.Raycast((Vector2)Firepoint.transform.position, direction.normalized, direction.magnitude, Hitmask);

			Debug.DrawLine(mousePos, Firepoint.transform.position, Color.red);


			if (hit)
			{
				_explodable.explode();
				ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
				ef.doExplosion(transform.position);
			}

		}

	}


}

