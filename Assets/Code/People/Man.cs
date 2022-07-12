using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Man : MonoBehaviour
{
    [SerializeField]
    protected Transform mytransform;

    [SerializeField]
    protected Rigidbody2D myrigidbody;

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected MovingEngine.Movement movement;

    protected enum StateEnum { Idle, Walk, OtherAnim}

    protected StateEnum currentManState = StateEnum.Idle;

    private void Start()
    {
        movement.StopMoving();
        OnStart();
    }

    protected virtual void OnStart()
    {
        
    }

    private void Update()
    {
        if (currentManState != StateEnum.OtherAnim)
        {
            if (movement.IsMoving())
            {
                currentManState = StateEnum.Walk;
                if (movement.LookingDirection == MovingEngine.Movement._LookingDirection.Left)
                {
                    animator.SetInteger("state", -2);
                }
                else if (movement.LookingDirection == MovingEngine.Movement._LookingDirection.Right)
                {
                    animator.SetInteger("state", 2);
                }
            }
            else
            {
                currentManState = StateEnum.Idle;
                if (movement.LookingDirection == MovingEngine.Movement._LookingDirection.Left)
                {
                    animator.SetInteger("state", -1);
                }
                else if (movement.LookingDirection == MovingEngine.Movement._LookingDirection.Right)
                {
                    animator.SetInteger("state", 1);
                }
            }
        }
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }

    private void FixedUpdate()
    {
        
    }

    protected virtual void OnFixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Walls>() != null)
        {
            movement.StopMoving();
        }
    }

}
