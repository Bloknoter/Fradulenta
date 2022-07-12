using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MovingEngine
{
    public class RigidMove : Movement
    {

        private float startspeed;

        private bool ismoving;

        private Vector2 target;

        void Start()
        {
            startspeed = speed;
        }

        private void FixedUpdate()
        {
            float distance = Vector2.Distance(mytransform.position, target);
            if (distance > 0.1f)
            {
                ismoving = true;
                if (mytransform.position.x >= target.x)
                {
                    lookingDirection = _LookingDirection.Left;
                }
                else
                {
                    lookingDirection = _LookingDirection.Right;
                }
                myrigidbody.MovePosition((Vector2)mytransform.position + ((target - (Vector2)mytransform.position) / (distance / speed)));
            }
            else
            {
                ismoving = false;
            }
        }

        public void RandomizeSpeed()
        {
            speed = Random.Range(startspeed - startspeed / 2, startspeed + startspeed / 2);
        }

        public override void SetMovement(Vector2 vector)
        {
            target = vector;
        }

        public override bool IsMoving()
        {
            return ismoving;
        }

        public override void StopMoving()
        {
            SetMovement(mytransform.position);
        }
    }
}
