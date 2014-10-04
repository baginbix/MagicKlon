using UnityEngine;
using System.Collections;

public class MagmaLizardScript : BaseFireUnit {
    public float FlamebreathAngle;
    public float FlamebreathRange;
    float RangePerStack = 1;
	// Use this for initialization
	void Start () 
    {
        base.Start();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        base.Update();	
	}

    private void FlameBreath()
    {
        FlamebreathRange = 1 + RangePerStack * CurrentEmberStack;
        Debug.Log("FlameBreath BITCH");
        MinionList enemyMinions = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<MinionList>();
        for (int i = 0; i < enemyMinions.minionList.Count; i++)
        {
            Vector3 dir = enemyMinions.minionList[i].transform.position - transform.position;
            if (Vector3.Angle(dir, transform.forward) < FlamebreathAngle * 0.5f && Vector3.Distance(enemyMinions.minionList[i].position,transform.position)<=FlamebreathRange)
            {
                Debug.Log("Get Flamed Bitch");
                enemyMinions.minionList[i].GetComponent<BaseUnit>().TakeDamage(attack.TotalAttackDamage);
            }
        }
    }

    protected override void Combat()
    {
        if (!health.IsDead())
        {
            if (InRange())
            {
                agent.enabled = false;
                if (attack != null && attack.Attack())
                {
                    FlameBreath();
                    if (enemy[0].GetComponent<BaseUnit>().health.IsDead())
                    {
                        if (enemy.Count == 0)
                        {
                            Debug.Log("Killed him");
                            ExitCombat();
                        }
                        else
                            enemy.RemoveAt(0);
                    }
                }
            }
            else if (chase != null)
                chase.ChangeTarget(enemy[0].transform.position);
        }
    }
}
