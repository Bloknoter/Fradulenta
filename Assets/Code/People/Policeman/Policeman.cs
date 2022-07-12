using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MovingEngine;

public class Policeman : Man
{
    [SerializeField]
    protected BoxCollider2D boxcollider;

    [SerializeField]
    private GameObject ClickPrefab;

    [SerializeField]
    private GameObject TargetPrefab;

    private enum state
    {
        Idle_Walking,
        Arresting
    }

    private state CurrentState = state.Idle_Walking;

    private Transform arrestTarget;

    private Transform TargetLabel;


    private int manaclescount;

    public int ManaclesCount { get { return manaclescount; } }

    protected override void OnStart()
    {
        manaclescount = 3;
        mytransform.position = Vector2.zero;
        movement.StopMoving();
    }

    protected override void OnUpdate()
    {
        if (CurrentState != state.Arresting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                arrestTarget = null;
                if (TargetLabel != null)
                    Destroy(TargetLabel.gameObject);
                movement.StopMoving();
                Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(point, boxcollider.size, 0);
                if (colliders.Length == 0)
                {
                    ClickAndMove(point);
                }
                else
                {
                    bool waswall = false;
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if (colliders[i].gameObject.GetComponent<Walls>() != null)
                        {
                            InstantiateClick(point, false);
                            CurrentState = state.Idle_Walking;
                            waswall = true;
                            break;
                        }
                    }
                    if (!waswall)
                    {
                        ClickAndMove(point);
                        CurrentState = state.Idle_Walking;
                    }
                }
            }
            if (Input.GetMouseButtonDown(1) && manaclescount > 0)
            {
                Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(point, boxcollider.size, 0);
                if (colliders.Length > 0)
                {
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        IArrestable arrestable = colliders[i].gameObject.GetComponent<IArrestable>();
                        if (arrestable != null)
                        {
                            arrestTarget = colliders[i].gameObject.transform;
                            if (TargetLabel != null)
                                Destroy(TargetLabel.gameObject);
                            TargetLabel = Instantiate(TargetPrefab).transform;
                            CurrentState = state.Idle_Walking;
                            break;
                        }
                    }
                }
            }
            if (arrestTarget != null)
            {
                Vector2 target = new Vector2(arrestTarget.position.x, arrestTarget.position.y - 0.3f);
                movement.SetMovement(target);
                TargetLabel.position = new Vector2(arrestTarget.position.x, arrestTarget.position.y + 0.2f);
                if (Vector2.Distance(mytransform.position, target) <= 0.8f)
                {
                    Destroy(TargetLabel.gameObject);
                    movement.StopMoving();
                    currentManState = StateEnum.OtherAnim;
                    CurrentState = state.Arresting;
                    arrestTarget.gameObject.GetComponent<IArrestable>().Arrest();
                    animator.SetInteger("state", (int)movement.LookingDirection * 3);
                }
            }
        }
        
    }

    private void ClickAndMove(Vector2 point)
    {
        InstantiateClick(point, true);
        movement.SetMovement(point);
    }

    private void InstantiateClick(Vector2 point, bool allowed)
    {
        GameObject click = Instantiate(ClickPrefab);
        click.transform.position = point;
        click.GetComponent<Click>().SetState(allowed);
    }

    public void OnKickingArrested()
    {
        arrestTarget.gameObject.GetComponent<IArrestable>().BeKicked();
    }

    public void OnArrestingFinished()
    {
        manaclescount--;
        arrestTarget = null;
        animator.SetInteger("state", (int)movement.LookingDirection);
        CurrentState = state.Idle_Walking;
        currentManState = StateEnum.Idle;
    }
}
