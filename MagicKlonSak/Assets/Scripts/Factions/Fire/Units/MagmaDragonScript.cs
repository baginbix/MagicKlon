using UnityEngine;
using System.Collections;

public class MagmaDragonScript : BaseFireUnit {

	// Use this for initialization
	void Start () 
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () 
    {
        base.Update();
        Warleader();
	}
    public float WarLeaderRange;

    private void Warleader()
    {
        
        MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
        for (int i = 0; i < minionListScript.minionList.Count; i++)
        {
            if (minionListScript.minionList[i].GetComponent<BaseUnit>() is BaseFireUnit)
            {

                if(Vector3.Distance(transform.position, minionListScript.minionList[i].position) < WarLeaderRange)
                {
                    agent.speed = agent.speed * 2;
                    minionListScript.minionList[i].GetComponent<NavMeshAgent>().speed = minionListScript.minionList[i].GetComponent<NavMeshAgent>().speed * 2;
                }
            }
        }
    }
}
