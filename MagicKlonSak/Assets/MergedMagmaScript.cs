using UnityEngine;
using System.Collections;

public class MergedMagmaScript : BaseFireUnit {

    public Transform prefab;

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

    public override void OnDeath()
    {
        Debug.Log("spawnign shit");
        for (int i = CurrentEmberStack; i > 0; i--)
        {
            Summon(); 
        }
    }

    public void Summon()
    {
        MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
        Debug.Log(minionListScript.name);
        minionListScript.minionList.Add((Transform)Instantiate(prefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation));
        minionListScript.minionList[minionListScript.minionList.Count-1].GetComponent<MagmaElementalScript>().MakeClone = false;

    }
}
