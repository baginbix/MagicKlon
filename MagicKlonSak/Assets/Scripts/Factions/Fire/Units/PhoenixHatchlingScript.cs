using UnityEngine;
using System.Collections;

public class PhoenixHatchlingScript : BaseFireUnit {
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

        MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
        Debug.Log(minionListScript.name);
        minionListScript.minionList.Add((Transform)Instantiate(prefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation));

    }
}
