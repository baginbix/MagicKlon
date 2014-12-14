using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatModifierList : MonoBehaviour {

	private List<StatModifier> statModifiers = new List<StatModifier>();
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStatModifier(StatModifier modifier)
	{
		statModifiers.Add(modifier);
	}

	void ApplayModifiers()
	{
	}

	void RemoveModifiers()
	{

	}
}
