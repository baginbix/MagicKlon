using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ModifierType
{
	Buff,
	Debuff
}

public enum StatusEffects
{
	MovmentSpeed,
	AttackDamage,
	AttackSpeed,
	Health
}
[System.Serializable]
public class StatusEffect
{
	public StatusEffects statusEffect; 
	public float effect;
}

[System.Serializable]
public class StatModifier : MonoBehaviour {
	public ModifierType type;

	public List<StatusEffect> effectList = new List<StatusEffect>();

	public string name;
	public string description;

	public float duration = -1;
	public float timeRemaining;

	public bool Applyed = false;


	// Use this for initialization
	void Awake()
	{
		timeRemaining = duration;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
	}

	public bool HasEnded()
	{
		if(timeRemaining <=0)
			return true;

		return false;
	}
}
