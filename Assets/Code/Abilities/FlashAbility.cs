using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilityEngine
{
    public class FlashAbility : Ability
    {
        [SerializeField]
        private GameObject FlashPrefab;

        private GameObject FlashObject;

        void Start()
        {

        }

        void Update()
        {

        }
        public override void Use()
        {
            StartCoroutine(Flash());
        }

        private IEnumerator Flash()
        {
            FlashObject = Instantiate(FlashPrefab);
            FlashObject.transform.position = Vector2.zero;
            Player.transform.position = Player.GetComponent<Civil>().GetSpaceData().GetRandomPoint();
            yield return new WaitForSeconds(1f);
            SpriteRenderer spriteRenderer = FlashObject.GetComponent<SpriteRenderer>();
            for(int i = 0; i < 100;i++)
            {
                Color newcolor = spriteRenderer.color;
                newcolor.a -= 0.01f;
                spriteRenderer.color = newcolor;
                yield return new WaitForSeconds(0.01f);
            }
            Destroy(FlashObject);
            Destroy(gameObject);
        }
    }
}
