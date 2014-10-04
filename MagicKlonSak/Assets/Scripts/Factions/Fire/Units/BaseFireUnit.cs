using UnityEngine;
using System.Collections;

public class BaseFireUnit : BaseUnit {
	public int CurrentEmberStack;
	public int MaxEmberStack;

	protected virtual void Awake()
	{
		base.Awake();
	}
	// Use this for initialization
	protected virtual void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		base.Update();
	}

	public  bool EmberStackAvailable()
	{
		return CurrentEmberStack > 0;
	}

	public void AddEmber(int amount)
	{ 
		CurrentEmberStack += amount;
		if(CurrentEmberStack > MaxEmberStack)
		{
			CurrentEmberStack = MaxEmberStack;
		}
        OnEmberGain();
	}

    protected virtual void OnEmberGain()
    {
    }
}

