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
            float red = Random.Range(0, 255) / 255;
            float green = Random.Range(0, 255) / 255;
            float blue = Random.Range(0, 255) / 255;
            //sprayPart.active = true;
            Bullet bull = Instantiate(bulletPrefab, transform.position + offset, Quaternion.identity, null);
			bull.rb.velocity = transform.right * speed;

            Material material = new Material(Shader.Find("Specular"));
            material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            bull.GetComponent<Renderer>().material = material;
            Destroy(bull.gameObject, 10);
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			sprayPart.active = false;
		}
	}
}
