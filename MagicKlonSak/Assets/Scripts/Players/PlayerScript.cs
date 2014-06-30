using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour {
	HealthScript health;
	ArmorScript armor;
	AttackScript attack;
	ArmorBreakScript armorBreak;
	
	public string name;
	// Use this for initialization
	void Start () {
		health = GetComponent<HealthScript>();
		armor = GetComponent<ArmorScript>();
		attack = GetComponent<AttackScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
