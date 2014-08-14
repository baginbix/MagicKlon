using UnityEngine;
using System.Collections;

public abstract class IUnit : MonoBehaviour {

	public abstract void Attack();

	public abstract void EngageCombat(GameObject vjsMamma);

	public abstract void ExitCombat();

	public abstract bool InRange();

	public abstract bool OnSummon();

	public abstract bool OnDeath();
	
}
