using UnityEngine;
using System.Collections;

public class MagmaSurgeScript : BaseFireUnit
{
    public float SurgeSpeed;
    public float SurgeRange;
    public float surgeDamage;
    Vector3 surgeStartingPoint;
    bool surging = false;

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (surging)
            Surge();
        else
            base.Update();
    }

    void Surge()
    {
        m_cancelCombat = true;
        Vector3 vel = (transform.forward * SurgeSpeed) * Time.deltaTime;
        Vector3 newPos = transform.position += vel;
        transform.position += (transform.forward * SurgeSpeed) * Time.deltaTime;

        if (Vector3.Distance(transform.position, surgeStartingPoint) >= SurgeRange)
        {
            surging = false;

        }
    }

    public override void EngageCombat(GameObject vjsMamma)
    {
        base.EngageCombat(vjsMamma);
        if (EmberStackAvailable())
        {
            surging = true;
            CurrentEmberStack--;
            surgeStartingPoint = transform.position;
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collision");
        MinionList enemies = GameObject.Find("Enemy").GetComponentInChildren<MinionList>();

        if (enemies.minionList.Contains(collider.transform))
        {
            Debug.Log("Doing dmg");
            collider.gameObject.GetComponent<BaseUnit>().TakeDamage(surgeDamage);
        }
    }
}