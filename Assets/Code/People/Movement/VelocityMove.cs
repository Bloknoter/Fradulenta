using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MovingEngine
{
    public class VelocityMove : Movement
    {
        public override void SetMovement(Vector2 vector)
        {
            myrigidbody.velocity = vector * speed;
            if(vector.x > 0)
            {
                lookingDirection = _LookingDirection.Right;
            }
            else if (vector.x < 0)
            {
                lookingDirection = _LookingDirection.Left;
            }
        }

        public override bool IsMoving()
        {
            return myrigidbody.velocity != Vector2.zero;
        }

        public override void StopMoving()
        {
            myrigidbody.velocity = Vector2.zero;
        }
    }
}
