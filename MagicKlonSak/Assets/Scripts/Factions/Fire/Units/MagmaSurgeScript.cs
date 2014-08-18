using UnityEngine;
using System.Collections;

public class MagmaSurgeScript : BaseFireUnit {
	public float SurgeSpeed;
	bool surging = false;
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		if(surging)
			Surge();
	}

	void Surge()
	{
		CancelCombat();
		transform.position += (transform.forward*SurgeSpeed) * Time.deltaTime;
	}

	public override void EngageCombat (GameObject vjsMamma)
	{
		base.EngageCombat (vjsMamma);
		if(EmberStackAvailable() )
			surging = true;
	}
}
