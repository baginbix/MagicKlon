using UnityEngine;
using System.Collections;

public class MagmaElementalScript : BaseFireUnit {
	public bool MakeClone = true;

	void Awake()
	{
		base.Awake();
		OnSummon();
	}
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	protected override void OnSummon ()
	{
		Debug.Log(MakeClone.ToString());
		if(MakeClone)
		{
			MakeClone = false;
			MinionList minionListScript = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<MinionList>();
			Debug.Log (minionListScript.name);
			minionListScript.minionList.Add((Transform)Instantiate(transform, new Vector3(transform.position.x+1,transform.position.y,transform.position.z), transform.rotation));
		}
	}
}
