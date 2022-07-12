using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MovingEngine
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField]
        protected Transform mytransform;

        [SerializeField]
        protected Rigidbody2D myrigidbody;

        [SerializeField]
        protected float speed;

        public enum _LookingDirection { Left = -1, Right = 1 }

        protected _LookingDirection lookingDirection = _LookingDirection.Left;

        public _LookingDirection LookingDirection
        {
            get { return lookingDirection; }
        }

        public abstract void SetMovement(Vector2 vector);
        public abstract bool IsMoving();
        public abstract void StopMoving();
    }
}
