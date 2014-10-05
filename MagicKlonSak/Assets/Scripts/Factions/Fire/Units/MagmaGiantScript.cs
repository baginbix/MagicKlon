using UnityEngine;
using System.Collections;

public class MagmaGiantScript : BaseFireUnit
{
    bool passiveBonusArmorRecived = false;
    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        MoltenRegeneration();
        base.Update();
    }

    private void MoltenRegeneration()
    {
        if (CurrentEmberStack >= 1 && health.currentHitPoints <= (health.MaxHitPoints - 7))
        {
            health.Heal(7);
            CurrentEmberStack--;
            if (CurrentEmberStack == 0)
            {
                Debug.Log("NO ARMOR FOR YOU");
                armor.ReduceArmor(1);
                passiveBonusArmorRecived = false;
            }
        }
    }

    protected override void OnEmberGain()
    {
        if(!passiveBonusArmorRecived)
            armor.AddArmor(1);
    }

}
