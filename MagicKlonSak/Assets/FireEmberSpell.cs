using UnityEngine;
using System.Collections;

public class FireEmberSpell : MonoBehaviour {

	public float Size;
	public float Range;
	public float Speed;
	Vector3 velocity;
	Vector3 targetPosition;
	string player;

	// Use this for initialization
	void Start () {
		velocity = targetPosition - transform.position;
		velocity = Vector3.Normalize(velocity);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * (Speed*Time.deltaTime); 
	}

	void OnExplosion()
	{
		MinionList[] minionLists = GetComponents<MinionList>();
		if(minionLists[0].tag == player)
		{
			for (int i = 0; i < minionLists[0].minionList.Count; i++) 
			{
				if(Vector3.Distance(minionLists[0].minionList[i].position,targetPosition)<=Size)
					return;
			}
		}
		else
		{
			
			for (int i = 0; i < minionLists[1].minionList.Count; i++) 
			{
				if(Vector3.Distance(minionLists[1].minionList[i].position,targetPosition)<=Size)
					return;
			}
		}
	}
}
