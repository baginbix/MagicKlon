using UnityEngine;
using System.Collections;

public class ArmorBreakScript : MonoBehaviour {

	public float baseArmorBreak;
	public float bonusArmorBreak;
	
	public float BaseArmorBreak
	{
		get{return baseArmorBreak;}
		set{baseArmorBreak = value;}
	}
	
	public float BonusArmorBreak
	{
		get{return bonusArmorBreak;}
		set{bonusArmorBreak = value;}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void ReduceArmorBreak(float amount)
	{
		bonusArmorBreak -= amount;
	}
	
	public void AddArmorBreak(float amount)
	{
		bonusArmorBreak+=amount;
	}

	public float TotalArmorBreak()
	{
		return baseArmorBreak+bonusArmorBreak;
	}

	public void InitializeArmorBreak(float baseArmorBreak,float bonusArmorBreak)
	{
		this.baseArmorBreak = baseArmorBreak;
		this.bonusArmorBreak = bonusArmorBreak;
	}
}
