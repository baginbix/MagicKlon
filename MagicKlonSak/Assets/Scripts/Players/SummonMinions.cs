using UnityEngine;
using System.Collections;
public enum Hotkey
{
	One = 0,
	Two,
	Three,
	Four,
	None = 4
};
public class SummonMinions : MonoBehaviour {
	public Transform[] prefab;
	public float SummonRange;
	public GameObject minionList;
	Vector3 spawnPoint;
	NavMeshAgent agent;
	public Hotkey chosenHotkey;
	Vector3 defaultSpawnPoint = new Vector3(1000,1000,1000);
	private int unitIndex;

	// Use this for initialization
	void Start () {
		spawnPoint = defaultSpawnPoint;
		agent = GetComponent<NavMeshAgent>();
		chosenHotkey = Hotkey.None;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && chosenHotkey != Hotkey.None) {
			unitIndex = (int)chosenHotkey;
			Debug.Log("Time to summon");
			GetSpawnpoint();
		}
		if(spawnPoint != defaultSpawnPoint)
		{
			Debug.Log("Spawnungn");
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
		CheckForSelectedMinion();
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
			spawnPoint.y+=2;
			Debug.Log(spawnPoint.ToString());
		}

		Debug.Log(hit.ToString());

	}

	bool CheckMana()
	{
 		BaseUnit unit = prefab[unitIndex].GetComponent<BaseUnit>();
		return unit.cost <= GetComponent<ManaScript>().CurrentMana;
	}

	public void Summon()
	{
		Transform unit = (Transform)Instantiate(prefab[unitIndex], spawnPoint, transform.rotation);
		minionList.GetComponent<MinionList>().minionList.Add(unit);
		GetComponent<ManaScript>().CurrentMana -= prefab[unitIndex].GetComponent<BaseUnit>().cost;
		spawnPoint = defaultSpawnPoint;
		agent.enabled = false;
		chosenHotkey = Hotkey.None;
		Debug.Log(unit.GetComponent<HealthScript>().currentHitPoints.ToString());
	}

	public void CancelMovment()
	{
		agent.enabled = false;
		spawnPoint = defaultSpawnPoint;
		chosenHotkey = Hotkey.None;
	}

	void CheckForSelectedMinion()
	{
		if(Input.GetKey(KeyCode.Alpha1))
			chosenHotkey = Hotkey.One;
		else if(Input.GetKey(KeyCode.Alpha2))
			chosenHotkey = Hotkey.Two;
		else if(Input.GetKey(KeyCode.Alpha3))
			chosenHotkey = Hotkey.Three;
		else if(Input.GetKey(KeyCode.Alpha4))
			chosenHotkey = Hotkey.Four;
		else if(Input.anyKeyDown)
			chosenHotkey = Hotkey.None;
	}
}
