using UnityEngine;
using System.Collections;
using System.Collections.Generic;
enum CombatStates
{

};
public class BaseUnit : MonoBehaviour
{
    public HealthScript health;
    protected ArmorScript armor;
    protected AttackScript attack;
    protected ArmorBreakScript armorBreak;
    protected Chase chase;
    public bool maxCountCombatLock;
    public const int CombatLockCount = 1;
    public bool combatLock;
	bool summonerCombatLock;
    protected List<GameObject> enemy;
    protected NavMeshAgent agent;
    public float range;
    string enemyTag;
    public bool m_cancelCombat;
	public bool flying = false;

    public float cost;

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {
        enemy = new List<GameObject>();
        if (tag == "Player1")
            enemyTag = "VjsMamma";
        else
            enemyTag = "Player1";
        health = GetComponent<HealthScript>();
        armor = GetComponent<ArmorScript>();
        attack = GetComponent<AttackScript>();
        agent = GetComponent<NavMeshAgent>();
        chase = GetComponent<Chase>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
		if(summonerCombatLock)
		{
			SummonerCombat();
		}

        if (combatLock)
        {
            Combat();
        }

        if (m_cancelCombat)
        {
            CancelCombat();
        }
    }

    public float Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    protected virtual void OnTriggerStay(Collider other)
    {
		if(other.name == "Enemy" )
		{
			enemy.Add (other.gameObject);
			summonerCombatLock = true;
			return;
		}

        if (!maxCountCombatLock)
        {
            if (other.tag == "Player2")
            {
                EngageCombat(other.gameObject);
				return;
            }

            else if (IsEnemy(other))
            {
                if (other.GetComponent<BaseUnit>().combatLock == false && !other.GetComponent<BaseUnit>().maxCountCombatLock)
                {
                    EngageCombat(other.gameObject);
                    other.GetComponent<BaseUnit>().EngageCombat(gameObject);
                    agent.enabled = false;
					return;
                }
            }
        }


    }

    protected bool IsEnemy(Collider other)
    {
        GameObject enemy = GameObject.Find("Enemy");
        MinionList enemyMinions = enemy.GetComponentInChildren<MinionList>();
        if (enemyMinions.minionList.Contains(other.transform))
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
        if (chase != null)
            chase.ChangeTarget(enemy[0].transform.position);
    }

    public virtual void ExitCombat()
    {
        combatLock = false;
		maxCountCombatLock = false;
		agent.enabled = true;
        if (chase != null)
            chase.SetPrimaryTarget();
    }

    protected bool InRange()
    {
        if (enemy.Count > 0)
            return Vector3.Distance(enemy[0].transform.position, transform.position) <= range;

        return false;
    }

    public virtual void OnSummon()
    {

    }

    public virtual void OnDeath()
    {
    }

	protected virtual void SummonerCombat()
	{

		if(InRange ())
		{
			agent.enabled = false;
			if(attack.Attack())
			{
				enemy[0].GetComponent<HealthScript>().Damage(attack.TotalAttackDamage);
			}
		}
		else
		{
			agent.enabled = true;
		}
	}

    protected virtual void Combat()
    {
        if (!health.IsDead())
        {
			Debug.Log(enemy[0].name);
            if (InRange())
            {
                agent.enabled = false;
                if (attack != null && attack.Attack())
                {
					enemy[0].GetComponent<BaseUnit>().TakeDamage(attack.TotalAttackDamage);
					Debug.Log(enemy == null);
                    if (enemy[0].GetComponent<HealthScript>().IsDead())
                    {
						enemy.RemoveAt(0);
						maxCountCombatLock = false;
						if(enemy.Count == 0)
						{
                       		ExitCombat();
						}
                            
                    }
                }
            }
            else if (chase != null)
                chase.ChangeTarget(enemy[0].transform.position);
        }
    }

    protected virtual void CancelCombat()
    {
        combatLock = false;
        agent.enabled = true;
        enemy.Clear();
        if (chase != null)
            chase.SetPrimaryTarget();

        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy.Count == 0)
                break;

            enemy[i].GetComponent<BaseUnit>().m_cancelCombat = true;
        }
    }

}