using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Moving ();
		LockRotation();
	}

	void Moving()
	{
		if(tag =="Player1")
		{
			if(Input.GetKey(KeyCode.A))
			{
				transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.D))
			{
				transform.Translate(new Vector3(speed,0,0)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.W))
			{
				transform.Translate(new Vector3(0,0,speed)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.S))
			{
				transform.Translate(new Vector3(0,0,-speed)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
		}

		if(tag =="Player2")
		{
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.RightArrow))
			{
				transform.Translate(new Vector3(speed,0,0)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.UpArrow))
			{
				transform.Translate(new Vector3(0,0,speed)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.DownArrow))
			{
				transform.Translate(new Vector3(0,0,-speed)*Time.deltaTime);
			}
		}
	}
	public void LockRotation()
	{
		transform.rotation = new Quaternion(0f,0f,0f,0f);
	}
}
