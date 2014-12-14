using UnityEngine;
using System.Collections;
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

public struct StatusEffect
{
	public StatusEffects statusEffect; 
	public float effect;
}


public class StatModifier : MonoBehaviour {
	public ModifierType type;

	public StatusEffect[] effectList;

	public string name;
	public string description;

	public float duration;
	public float timeRemaining;


	// Use this for initialization
	void Awake()
	{
		timeRemaining = duration;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
