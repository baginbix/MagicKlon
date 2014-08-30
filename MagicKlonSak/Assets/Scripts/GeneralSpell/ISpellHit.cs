using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public interface ISpellHit
    {
        void OnHitAction(GameObject target, GameObject owner, Vector3 hitPoint, float damage = 0, float AoERange = 0);
    }
}
