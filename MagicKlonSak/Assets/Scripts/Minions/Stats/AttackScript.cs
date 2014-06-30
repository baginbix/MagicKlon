using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	public float baseAttackDamage;
	public float bonusAttackDamage;
	public float baseAttackSpeed;
	public float bonusAttackSpeed;
	public float timeToNextAttack;

	public float BonusAttackDamage
	{
		get{return bonusAttackDamage;}
		set{bonusAttackDamage = value;}
	}

	public float BonusAttackSpeed
	{
		get{return bonusAttackSpeed;}
		set{bonusAttackSpeed = value;}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void BuffAttackDamage(float amount)
	{
		bonusAttackDamage += amount;
	}
	
	public void ReduceAttackDamage(float amount)
	{
		bonusAttackDamage-=amount;
	}

	public void BuffAttackSpeed(float amount)
	{
		bonusAttackSpeed += amount;
	}
	
	public void ReduceAttackSpeed(float amount)
	{
		bonusAttackSpeed-=amount;
	}

	public float TotalAttackDamage
	{
		get{return baseAttackDamage + bonusAttackDamage;}
	}

	public float TotalAttackSpeed
	{
		get{return baseAttackSpeed + bonusAttackSpeed;}
	}

	public bool Attack()
	{
		if(timeToNextAttack >= (1/baseAttackSpeed))
		{
			timeToNextAttack = 0;
			return true;
		}
		else
		{
			timeToNextAttack += Time.deltaTime;
			return false;
		}
	}
}
