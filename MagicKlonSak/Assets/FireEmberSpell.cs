using UnityEngine;
using System.Collections;

public class FireEmberSpell : MonoBehaviour {

	public float Size;
	public float Range;
	public float Speed;
	Vector3 velocity;
	GameObject targetPosition;
	string player;

	// Use this for initialization
	void Start () {
		velocity = targetPosition.transform.pos - transform.position;
		velocity = Vector3.Normalize(velocity);
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = new GameObject();
		transform.position += velocity * (Speed*Time.deltaTime); 
	}

	void OnExplosion()
	{
		MinionList[] minionLists = GetComponents<MinionList>();
		if(minionLists[0].tag == player)
		{
			for (int i = 0; i < minionLists[0].minionList.Count; i++) 
			{
					if(Vector3.Distance(minionLists[0].minionList[i].position,targetPosition.transform.position)<=Size)
					return;
			}
		}
		else
		{
			
			for (int i = 0; i < minionLists[1].minionList.Count; i++) 
			{
				if(Vector3.Distance(minionLists[1].minionList[i].position,targetPosition.transform.position)<=Size)
					return;
			}
		}
	}

	public void SetTargetPosition(Vector3 pos)
	{
		targetPosition.transform.position = pos;
	}

	public void SetTargetUnit(GameObject unit)
	{
		targetPosition = unit;
	}
}
