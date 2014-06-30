using UnityEngine;
using System.Collections;

public class ManaScript : MonoBehaviour {
	public float MaxMana;
	public float CurrentMana;
	public float ManaReg;

	void Start()
	{
		SetDefaultManaReg();
	}
	// Update is called once per frame
	void Update () 
	{
		RegenMana();
	}

	void SetDefaultManaReg()
	{
		ManaReg = (MaxMana*0.1f);
	}

	void RegenMana()
	{
		CurrentMana += ManaReg*Time.deltaTime;

		if(CurrentMana > MaxMana)
		{
			CurrentMana = MaxMana;
		}
	}
}
