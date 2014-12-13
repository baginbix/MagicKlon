using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float baseHitpoints;
	public float currentHitPoints;
	public float bonusHitPoints;

	public float BaseHitPoints
	{
		get{return baseHitpoints;}
		set{baseHitpoints = value;}
	}
	// Use this for initialization
	void Awake () {
		currentHitPoints = baseHitpoints + bonusHitPoints;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(float amount)
	{
		float dmgReduction = GetComponent<ArmorScript>().ActuallHPTaken(amount);
		Debug.Log(dmgReduction.ToString());
		currentHitPoints -= dmgReduction;
	}

	public void Heal(float amount)
	{
		if(bonusHitPoints+amount<MaxHitPoints)
		{
			currentHitPoints+=amount;
		}
		else
		{
			currentHitPoints = MaxHitPoints;
		}
	}

	public float MaxHitPoints
	{
		get{return baseHitpoints+bonusHitPoints;}
	}

	public void BuffBonusHitPoints(float amount)
	{
		bonusHitPoints += amount;
	}

	public void ReduceBonusHitPoints(float amount)
	{
		bonusHitPoints-=amount;
	}

	public bool IsDead()
	{
		if(currentHitPoints<= 0)
		{
			Debug.Log(currentHitPoints.ToString());
			currentHitPoints = 0;
			return true;
		}
		return false;
	}

	public void InitializeHP(float baseHP,float bonusHP)
	{
		baseHitpoints = baseHP;
		bonusHitPoints = bonusHP;
	}
}
