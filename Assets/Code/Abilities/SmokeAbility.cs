using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilityEngine
{
    public class SmokeAbility : Ability
    {
        [SerializeField]
        private GameObject SmokePrefab;

        [SerializeField]
        [Min(0)]
        private float WorkTime;

        private GameObject Smoke;

        void Start()
        {

        }

        void Update()
        {

        }
        public override void Use()
        {
            Smoke = Instantiate(SmokePrefab);
            Smoke.transform.position = new Vector2(Player.transform.position.x + Random.Range(-0.8f, 0.8f), Player.transform.position.y + Random.Range(-0.8f, 0.8f));
            StartCoroutine(DestroyingTimer());
        }

        private IEnumerator DestroyingTimer()
        {
            yield return new WaitForSeconds(WorkTime);
            Destroy(Smoke);
            Destroy(gameObject);
        }

    }
}
