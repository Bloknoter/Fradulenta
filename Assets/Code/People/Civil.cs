using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Maps.Data;

public class Civil : Man, IArrestable
{
    [SerializeField]
    protected MovingSpaceData SpaceData;

    public MovingSpaceData GetSpaceData() {  return SpaceData; }

    public enum state
    {
        Start,
        Moving,
        Waiting,
        Bearrested
    }

    public state CurrentCivilState { get; protected set; } = state.Start;

    public void Arrest()
    {
        StopAllCoroutines();
        currentManState = StateEnum.OtherAnim;
        movement.StopMoving();
        CurrentCivilState = state.Bearrested;
        Collider2D[] colliders = GetComponents<Collider2D>();
        for(int i = 0; i < colliders.Length;i++)
        {
            colliders[i].isTrigger = true;
        }
        animator.SetInteger("state", (int)movement.LookingDirection * 3);
    }

    public void BeKicked()
    {
        StartCoroutine(BeKickedProcess());
    }

    private IEnumerator BeKickedProcess()
    {
        float rotspeed = 3f;
        float speed = 0.7f;
        int iteration = 30;
        float acceleration = speed / iteration;
        /*for(int i = 0; i < 50;i++)
        {
            mytransform.position = new Vector2(mytransform.position.x, mytransform.position.y + speed * Time.deltaTime);
            speed -= acceleration;
            mytransform.Rotate(0, 0, rotspeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 500; i++)
        {
            mytransform.position = new Vector2(mytransform.position.x, mytransform.position.y - speed * Time.deltaTime);
            speed += acceleration;
            mytransform.Rotate(0, 0, rotspeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }*/
        for(int i = 0; i < iteration; i++)
        {
            mytransform.position = new Vector2(mytransform.position.x, mytransform.position.y + speed);
            speed -= acceleration;
            mytransform.Rotate(0, 0, rotspeed);
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < iteration * 4; i++)
        {
            mytransform.position = new Vector2(mytransform.position.x, mytransform.position.y - speed);
            speed += acceleration;
            mytransform.Rotate(0, 0, rotspeed);
            yield return new WaitForFixedUpdate();
        }
    }

}
