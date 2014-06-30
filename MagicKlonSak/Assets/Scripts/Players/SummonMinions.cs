using UnityEngine;
using System.Collections;

public class SummonMinions : MonoBehaviour {
	public Transform prefab;
	public float SummonRange;
	Vector3 spawnPoint;
	NavMeshAgent agent;
	Vector3 defaultSpawnPoint = new Vector3(1000,1000,1000);

	// Use this for initialization
	void Start () {
		spawnPoint = defaultSpawnPoint;
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			GetSpawnpoint();
		}

		if(spawnPoint != defaultSpawnPoint)
		{
			if(CheckRange() )
			{
				if(CheckMana())
				{
					Summon();
				}
			}
			else
			{
				agent.enabled = true;
				agent.SetDestination(spawnPoint);
			}
		}
	}

	bool CheckRange()
	{
		return Vector3.Distance(spawnPoint,transform.position)<=SummonRange;
	}

	void GetSpawnpoint()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit) && hit.transform.tag =="Mark" && CheckMana())
		{
			spawnPoint = hit.point;
		}
	}

	bool CheckMana()
	{
		BaseUnit unit = prefab.GetComponent<BaseUnit>();
		return unit.cost <= GetComponent<ManaScript>().CurrentMana;
	}

	public void Summon()
	{
		Instantiate(prefab, spawnPoint, transform.rotation);
		GetComponent<ManaScript>().CurrentMana -= prefab.GetComponent<BaseUnit>().cost;
		spawnPoint = defaultSpawnPoint;
		agent.enabled = false;
	}

	public void CancelMovment()
	{
		agent.enabled = false;
		spawnPoint = defaultSpawnPoint;
	}
}
