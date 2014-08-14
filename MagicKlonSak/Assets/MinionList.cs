using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionList : MonoBehaviour {
	public List<Transform> minionList = new List<Transform>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		List<Transform> temp = new List<Transform>();

		if(minionList.Count>0)
		{
		for (int i = minionList.Count-1; i >= 0; i--) {
			if(minionList[i].GetComponent<HealthScript>().IsDead())
			{
				Debug.Log("Found Dead");
				Destroy(minionList[i].gameObject);
				minionList.RemoveAt(i);
			}
			else
			{
				temp.Add(minionList[i]);
			}
				}
		minionList = temp;
		}
	}
}
