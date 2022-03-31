using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
	private Camera cam;
	private GameObject Firepoint;
	private Explodable _explodable;
	public LayerMask IgnoreMe;



	void Start()
	{
		_explodable = GetComponent<Explodable>();
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		Firepoint = GameObject.FindGameObjectWithTag("Firepoint");		
	}


	void Update()
	{

		var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

		int layerMask = 1 << 8;
		layerMask = ~layerMask;


		Vector2 direction = mousePos - (Vector2)Firepoint.transform.position;
		RaycastHit2D hit = Physics2D.Raycast((Vector2)Firepoint.transform.position, direction.normalized, direction.magnitude, layerMask);

		Debug.DrawLine(mousePos, Firepoint.transform.position, Color.red);


		if (hit && Input.GetButton("Fire1"))
		{
			_explodable.explode();
			ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
			ef.doExplosion(transform.position);
		}
		

		


	}

}

