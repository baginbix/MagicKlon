using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUnit : IUnit {
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

	void Start()
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
	void Update ()
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

	public string Name
	{ 
		get{return name;}
	}

	public float Cost
	{ 
		get{return cost;}
		set{cost = value;}
	}

	void OnTriggerStay(Collider other) {

		if(!maxCountCombatLock)
		{
			if(other.tag == "Player2")
			{
				EngageCombat(other.gameObject);
				agent.enabled = false;
			}
		
			else if(other.tag == enemyTag)
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

	/*void OnTriggerExit(Collider other)
	{
		if(other.gameObject == enemy[0] && enemy.Count == 0)
			ExitCombat();
	}*/

	public override void Attack()
	{

	}

	public void TakeDamage(float amount)
	{
		health.Damage(armor.ActuallHPTaken(amount));
	}

	public override void EngageCombat(GameObject vjsMamma)
	{
		combatLock = true;
		enemy.Add(vjsMamma);
		maxCountCombatLock = (enemy.Count == CombatLockCount);
		if(chase!= null)
			chase.ChangeTarget(enemy[0].transform.position);
	}

	public override void ExitCombat()
	{
		combatLock = false;
		enemy.RemoveAt(0);
		agent.enabled = true;
		if(chase != null)
			chase.SetPrimaryTarget();
	}

	public override bool InRange()
	{
		if(enemy.Count >0)
			return Vector3.Distance(enemy[0].transform.position,transform.position)<=range;

		return false;
	}
	public override bool OnSummon ()
	{
		throw new System.NotImplementedException ();
	}

	public override bool OnDeath ()
	{
		throw new System.NotImplementedException ();
	}
	public bool OnSummon(ref List<Transform> minionList)
	{
		Debug.Log("Spawn ability FTW");
		minionList.Add((Transform)Instantiate(transform, new Vector3(transform.position.x+1,transform.position.y,transform.position.z), transform.rotation));
		return true;
	}
}
