using UnityEngine;
using System.Collections;

public class FireLordScript : BaseFireUnit {

    public float ImmortalTimer = 5.0f;
    bool hasrevived = false;
	// Use this for initialization
	void Start () 
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (CurrentEmberStack >= 5 && health.IsDead())
        {
            DeathDenied();
            hasrevived = true;
            CurrentEmberStack = 0;
        }
        //deathdenied
        if(hasrevived == true && ImmortalTimer > 0)
        {
            DeathDenied();
            ImmortalTimer -= Time.deltaTime;
        }
        base.Update();
	}

    void DeathDenied()
    {
        health.currentHitPoints = 1;
    }

    void RedirectPain(float amount)
    {        
        MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
        Transform ClosestFriendlyUnit = null;
        for (int i = 0; i < minionListScript.minionList.Count; i++)
        {
            if (minionListScript.minionList[i].gameObject == this.gameObject)
            {
                continue;
            }
            //kollar om det är fireunit
            if (minionListScript.minionList[i].GetComponent<BaseUnit>() is BaseFireUnit)
            {
                if (ClosestFriendlyUnit == null)
                {
                    ClosestFriendlyUnit = minionListScript.minionList[i];
                }
                else if (Vector3.Distance(transform.position, minionListScript.minionList[i].position) < Vector3.Distance(transform.position, ClosestFriendlyUnit.position))
                {
                    ClosestFriendlyUnit = minionListScript.minionList[i];
                }
            }
        }
        if (ClosestFriendlyUnit != null)
        {
            ClosestFriendlyUnit.GetComponent<HealthScript>().Damage(amount - 1);
            GetComponent<HealthScript>().Damage(1);
        }
        else
        {
            GetComponent<HealthScript>().Damage(amount);
        }
    }



}
