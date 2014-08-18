using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUnit : MonoBehaviour {
	HealthScript health;
	ArmorScript armor;
	AttackScript attack;
	ArmorBreakScript armorBreak;
	Chase chase;
	public bool maxCountCombatLock;
	public int CombatLockCount = 1;
	public bool combatLock;
	List<GameObject> enemy;
	NavMeshAgent agent;
	public float range;
	string enemyTag;

	public float cost;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
		enemy = new List<GameObject>();
		if(tag == "Player1")
			enemyTag ="VjsMamma";
		else
			enemyTag = "Player1";
		health = GetComponent<HealthScript>();
		armor = GetComponent<ArmorScript>();
		attack = GetComponent<AttackScript>();
		agent = GetComponent<NavMeshAgent>();
		chase = GetComponent<Chase>();
	}

	// Update is called once per frame
	protected virtual void Update ()
	{
		if(!health.IsDead())
		{
		if(combatLock && InRange())
		{
			agent.enabled = false;
			if(attack != null && attack.Attack())
			{
				enemy[0].GetComponent<HealthScript>().currentHitPoints -= attack.TotalAttackDamage;
				if(enemy[0].GetComponent<BaseUnit>().health.IsDead())
				{
						if(enemy.Count == 0)
						{
							Debug.Log("Killed him");
							ExitCombat();
						}
						else
							enemy.RemoveAt(0);
				}
			}
		}
		else if(combatLock && chase != null)
			chase.ChangeTarget(enemy[0].transform.position);
		}
	}

	public float Cost
	{ 
		get{return cost;}
		set{cost = value;}
	}

	protected virtual void OnTriggerStay(Collider other) {

		if(!maxCountCombatLock)
		{
			if(other.tag == "Player2")
			{
				EngageCombat(other.gameObject);
				agent.enabled = false;
			}
		
			else if(IsEnemy(other))
			{
				if(other.GetComponent<BaseUnit>().combatLock == false && !other.GetComponent<BaseUnit>().maxCountCombatLock)
				{
					EngageCombat(other.gameObject);
					other.GetComponent<BaseUnit>().EngageCombat(gameObject);
					agent.enabled = false;
				}
			}
		}
	}

	bool IsEnemy(Collider other)
	{
		GameObject enemy = GameObject.Find("Enemy");
		MinionList enemyMinions = enemy.GetComponentInChildren<MinionList>();
		if(enemyMinions.minionList.Contains(other.transform))
			return true;
		return false;
	}

	/*void OnTriggerExit(Collider other)
	{
		if(other.gameObject == enemy[0] && enemy.Count == 0)
			ExitCombat();
	}*/

	public virtual void Attack()
	{

	}

	public virtual void TakeDamage(float amount)
	{
		health.Damage(armor.ActuallHPTaken(amount));
	}

	public virtual void EngageCombat(GameObject vjsMamma)
	{
		combatLock = true;
		enemy.Add(vjsMamma);
		maxCountCombatLock = (enemy.Count == CombatLockCount);
		if(chase!= null)
			chase.ChangeTarget(enemy[0].transform.position);
	}

	public virtual void ExitCombat()
	{
		combatLock = false;
		enemy.RemoveAt(0);
		agent.enabled = true;
		if(chase != null)
			chase.SetPrimaryTarget();
	}

	bool InRange()
	{
		if(enemy.Count >0)
			return Vector3.Distance(enemy[0].transform.position,transform.position)<=range;

		return false;
	}

	protected virtual void  OnSummon ()
	{

	}

	protected virtual void  OnDeath ()
	{
	}

	public virtual void CancelCombat()
	{
		combatLock = false;
		agent.enabled = true;
		if(chase != null)
			chase.SetPrimaryTarget();
		if(enemy.Count > 0)
			enemy[0].GetComponent<BaseUnit>().CancelCombat();
	}	
}
