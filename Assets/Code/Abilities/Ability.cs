using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilityEngine
{
    public abstract class Ability : MonoBehaviour
    {
        [HideInInspector]
        public GameObject Player;
        public abstract void Use();
    }
}
