using UnityEngine;

namespace Assets.Scripts.Spells
{
    public class DirectionalCastable : MonoBehaviour
    {
        public Vector3 direction;
        public float speed;
        public ISpellHit spellHit;

        void Start()
        {
            enabled = false;    
        }

        public void Activate(Vector3 direction, float speed)
        {
            enabled = true;
            this.speed = speed;
            this.direction = direction;
        }

        void Update()
        {
            transform.Translate(direction * speed);
        }

        void OnCollisionEnter(Collision collision)
        {
            spellHit.OnHitAction(collision.gameObject, gameObject, collision.contacts[0].point);
        }

    }
}
