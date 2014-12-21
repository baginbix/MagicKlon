using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatModifierList : MonoBehaviour {

	public List<StatModifier> statModifiers = new List<StatModifier>();
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		CheckForExpiredModifiers();
		CheckForUnapplayedModifiers();
	}

	public void AddStatModifier(GameObject modifier)
	{
		StatModifier stat = modifier.GetComponent<StatModifier>();
		if(stat != null && !statModifiers.Contains(stat))
		{
			statModifiers.Add(stat);
			ApplayModifier(stat);
		}
	}

	void CheckForExpiredModifiers()
	{
		if(statModifiers.Count == 0)
			return;

		for (int i = 0; i < statModifiers.Count; i++) {
			if(statModifiers[i].HasEnded())
			{
				RemoveModifier(statModifiers[i]);
				statModifiers.RemoveAt(i);
			}
				}
	}

	void ApplayModifier(StatModifier stat)
	{
		for (int i = 0; i < stat.effectList.Count; i++) 
		{
			if(stat.effectList[i].statusEffect == StatusEffects.AttackDamage)
			{
				GetComponent<AttackScript>().bonusAttackDamage += stat.effectList[i].effect;
			}
			else if(stat.effectList[i].statusEffect == StatusEffects.AttackSpeed)
			{
				GetComponent<AttackScript>().bonusAttackSpeed += stat.effectList[i].effect;
			}
			else if(stat.effectList[i].statusEffect == StatusEffects.Health)
			{
				GetComponent<HealthScript>().bonusHitPoints += stat.effectList[i].effect;
			}

			else if(stat.effectList[i].statusEffect == StatusEffects.MovmentSpeed)
			{
				GetComponent<NavMeshAgent>().speed += stat.effectList[i].effect;
			}
		}
		stat.Applyed = true;
	}

	void CheckForUnapplayedModifiers()
	{
		if(statModifiers.Count <1)
			return;
		for (int i = 0; i < statModifiers.Count; i++) {
			if(!statModifiers[i].Applyed)
			{
				ApplayModifier(statModifiers[i]);
			}
				}
	}

	void RemoveModifier(StatModifier stat)
	{
		for (int i = 0; i < stat.effectList.Count; i++) {
			if(stat.effectList[i].statusEffect == StatusEffects.AttackDamage)
			{
				GetComponent<AttackScript>().bonusAttackDamage -= stat.effectList[i].effect;
			}

			else if(stat.effectList[i].statusEffect == StatusEffects.AttackSpeed)
			{
				GetComponent<AttackScript>().bonusAttackSpeed -= stat.effectList[i].effect;
			}
			else if(stat.effectList[i].statusEffect == StatusEffects.Health)
			{
				GetComponent<HealthScript>().bonusHitPoints -= stat.effectList[i].effect;
			}
			
			else if(stat.effectList[i].statusEffect == StatusEffects.MovmentSpeed)
			{
				GetComponent<NavMeshAgent>().speed -= stat.effectList[i].effect;
			}
		}
	}
}
