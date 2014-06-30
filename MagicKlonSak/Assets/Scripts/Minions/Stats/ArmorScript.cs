using UnityEngine;
using System.Collections;

public class ArmorScript : MonoBehaviour {

	public float baseArmorPoints;
	public float bonusArmorPoints;

	public float BaseArmorPoints
	{
		get{return baseArmorPoints;}
		set{baseArmorPoints = value;}
	}

	public float BonusArmorPoints
	{
		get{return bonusArmorPoints;}
		set{bonusArmorPoints = value;}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ReduceArmor(float amount)
	{
		bonusArmorPoints -= amount;
	}
	
	public void AddArmor(float amount)
	{
		bonusArmorPoints+=amount;
	}

	public float TotalArmorPoints()
	{
		return baseArmorPoints+bonusArmorPoints;
	}

	public float ActuallHPTaken(float damage)
	{
		float damageTaken = damage-(baseArmorPoints+bonusArmorPoints);
		return damageTaken>0?damageTaken:0;
	}

	public void InitializeArmor(float baseArmor,float bonusArmor)
	{
		baseArmorPoints = baseArmor;
		bonusArmorPoints = bonusArmor;
	}
}
