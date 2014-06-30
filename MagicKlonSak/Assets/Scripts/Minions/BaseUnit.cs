using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {
	HealthScript health;
	ArmorScript armor;
	AttackScript attack;
	ArmorBreakScript armorBreak;
	Chase chase;
	public bool combatLock;
	GameObject enemy;
	NavMeshAgent agent;
	public float range;
	string enemyTag;

	public string name;
	public float cost;

	void Start()
	{
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
		if(combatLock && InRange())
		{
			agent.enabled = false;
			if(attack != null && attack.Attack())
			{
				enemy.GetComponent<BaseUnit>().TakeDamage(attack.TotalAttackDamage);
				if(enemy.GetComponent<BaseUnit>().health.IsDead())
				{
					ExitCombatLock();
				}
			}
		}
		else if(combatLock && chase != null)
			chase.ChangeTarget(enemy.transform.position);

		if(health.IsDead())
			Destroy(gameObject);
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

		if(!combatLock)
		{
			if(other.tag == enemyTag)
			{
				if(other.GetComponent<BaseUnit>().combatLock == false)
				{
					EngageCombatLock(other.gameObject);
					other.GetComponent<BaseUnit>().EngageCombatLock(gameObject);
					agent.enabled = false;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == enemy)
			ExitCombatLock();
	}


	public void TakeDamage(float amount)
	{
		health.Damage(armor.ActuallHPTaken(amount));
	}

	public void EngageCombatLock(GameObject vjsMamma)
	{
		combatLock = true;
		enemy = vjsMamma;
		if(chase!= null)
			chase.ChangeTarget(enemy.transform.position);
	}

	public void ExitCombatLock()
	{
		combatLock = false;
		enemy = null;
		agent.enabled = true;
		if(chase != null)
			chase.SetPrimaryTarget();
	}

	bool InRange()
	{
		if(enemy!= null)
			return Vector3.Distance(enemy.transform.position,transform.position)<=range;

		return false;
	}
}
