using UnityEngine;
using System.Collections;

public class paintGun : MonoBehaviour {

	public GameObject triggerObj;
	public GameObject sprayPart;

	 public Bullet bulletPrefab;

	public float speed = 35;
	public Vector3 offset;

	void Start () 
	{
		sprayPart.active = false;
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			//sprayPart.active = true;
			Bullet bull = Instantiate(bulletPrefab, transform.position + offset, Quaternion.identity, null);
			bull.rb.velocity = transform.right * speed;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			sprayPart.active = false;
		}
	}
}
