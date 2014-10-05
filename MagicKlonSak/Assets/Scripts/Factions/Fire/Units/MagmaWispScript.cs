using UnityEngine;
using System.Collections;

public class MagmaWispScript : BaseFireUnit {
    public const float IgniteCd = 10;
    private float IgniteCountDown;
	// Use this for initialization
	void Start () 
    {
        IgniteCountDown = IgniteCd;
        base.Start();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        IgniteCountDown -= Time.deltaTime;
        if (IgniteCountDown <= 0)
        {
            Ignite();
            IgniteCountDown = IgniteCd;
        }
        base.Update();
	}

    private void Ignite() 
    {
        MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
        Transform ClosestFriendlyUnit = null;
        for (int i = 0; i < minionListScript.minionList.Count; i++)
        {
            //kollar om det är fireunit
            if (minionListScript.minionList[i].GetComponent<BaseUnit>() is BaseFireUnit)
            {
                //kollar så den kan ha burning ember
                if (minionListScript.minionList[i].GetComponent<BaseFireUnit>().MaxEmberStack > minionListScript.minionList[i].GetComponent<BaseFireUnit>().CurrentEmberStack )
                {
                    if (ClosestFriendlyUnit == null)
                        ClosestFriendlyUnit = minionListScript.minionList[i];
                    else if (Vector3.Distance(transform.position, minionListScript.minionList[i].position) < Vector3.Distance(transform.position, ClosestFriendlyUnit.position))
                    {
                        ClosestFriendlyUnit = minionListScript.minionList[i];
                    }

                }
            }     
        }
        if(ClosestFriendlyUnit != null)
            ClosestFriendlyUnit.GetComponent<BaseFireUnit>().AddEmber(1);

    }
}
