using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {
	public Transform m_transform;
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
				m_transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.D))
			{
				m_transform.Translate(new Vector3(speed,0,0)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.W))
			{
				m_transform.Translate(new Vector3(0,0,speed)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
			if(Input.GetKey(KeyCode.S))
			{
				m_transform.Translate(new Vector3(0,0,-speed)*Time.deltaTime);
				GetComponent<SummonMinions>().CancelMovment();
			}
		}

		if(tag =="Player2")
		{
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				m_transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.RightArrow))
			{
				m_transform.Translate(new Vector3(speed,0,0)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.UpArrow))
			{
				m_transform.Translate(new Vector3(0,0,speed)*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.DownArrow))
			{
				m_transform.Translate(new Vector3(0,0,-speed)*Time.deltaTime);
			}
		}
	}
	public void LockRotation()
	{
		m_transform.rotation = new Quaternion(0f,0f,0f,0f);
	}
}
