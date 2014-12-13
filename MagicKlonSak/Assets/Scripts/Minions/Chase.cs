using UnityEngine;
using System.Collections;

public class Chase: MonoBehaviour {
	GameObject vjsMamma;
	Transform myTransform;
	public NavMeshAgent agent;
	public Vector3 destination;
	public float speed;
	bool subTargetSet;
	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();
		/*foreach (GameObject enemy in vjsMamma) {
			if(enemy.GetComponent<PlayerScript>().name == "Player"&& gameObject.tag !="VjsMamma")
				agent.SetDestination(enemy.transform.position);
				}*/
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.enabled && !subTargetSet) 
		{
			vjsMamma = GameObject.FindGameObjectWithTag("Player2") as GameObject;
			if(vjsMamma != null)
			{
				agent.SetDestination(vjsMamma.transform.position);
			}
		}
	}

	public void ChangeTarget(Vector3 destination)
	{
		agent.enabled = true;
		agent.SetDestination(destination);
		subTargetSet = true;
	}

	public void SetPrimaryTarget()
	{
		subTargetSet = false;
		agent.enabled = true;
	}
}
