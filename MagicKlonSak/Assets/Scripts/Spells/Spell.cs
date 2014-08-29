using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {
    
    /// <summary>
    /// In milliseconds
    /// </summary>
    public float Cooldown;
    public int Manacost;
    public KeyCode hotkey;
    public GameObject SpellToCast;

    private float cooldownRemaining;
    private ManaScript ownerMana;

	void Start() 
    {
        cooldownRemaining = 0;
	}
	
	void Update() 
    {
        if (Input.GetKeyDown(hotkey) && CanCast())
            Cast();
	}

    public void Cast()
    {
        ownerMana.CurrentMana -= Manacost;
        GameObject spawnedSpell = (GameObject)Instantiate(SpellToCast);
    }

    protected bool CanCast()
    {
        return cooldownRemaining <= 0 && ownerMana.CurrentMana >= Manacost;
    }

    protected void HandleCooldown()
    {
        if (cooldownRemaining >= 0)
            cooldownRemaining -= Time.deltaTime;
    }
}
