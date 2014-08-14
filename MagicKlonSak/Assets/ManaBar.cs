using UnityEngine;
using System.Collections;

public class ManaBar : MonoBehaviour {
	public GameObject player;
	ManaScript mana;
	public float MaxManaBarLength;
	public float CurrentManaBarLength;
	GUITexture ManaBarTexture;

	// Use this for initialization
	void Start () {
		ManaBarTexture = GetComponent<GUITexture>();
		mana = player.GetComponent<ManaScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
		ShowCurrentMana();
	}

	public void ShowCurrentMana()
	{
		CurrentManaBarLength = mana.CurrentMana/ mana.MaxMana;
		Rect manaBar = ManaBarTexture.pixelInset;
		manaBar.width = MaxManaBarLength*CurrentManaBarLength;
		ManaBarTexture.pixelInset = manaBar;
	}

	/*public void ChangeAlertBar()
	{
		percentOfAwareness = awareness/maxAwareness;
		Rect alerter = alertBar.pixelInset;
		alerter.height = (maxAwareness*percentOfAwareness);
		alertBar.pixelInset = alerter;
	}*/
}
