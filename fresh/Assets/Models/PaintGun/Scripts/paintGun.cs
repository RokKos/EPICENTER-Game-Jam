using UnityEngine;
using System.Collections;

public class paintGun : MonoBehaviour {

	public GameObject triggerObj;
	public GameObject sprayPart;

	void Start () 
	{
		sprayPart.active = false;
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			sprayPart.active = true;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			sprayPart.active = false;
		}
	}
}
