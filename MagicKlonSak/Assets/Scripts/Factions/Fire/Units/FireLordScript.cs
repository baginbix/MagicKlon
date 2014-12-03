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

}
