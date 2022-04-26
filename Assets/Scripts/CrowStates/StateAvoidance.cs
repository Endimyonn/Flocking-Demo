using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAvoidance : CrowState
{
    public override void Awake()
    {

    }

    public override void Update()
    {
        crow.CheckAround();

        if (crow.avoidThese.Count == 0)
        {
            machine.ChangeState(new StateAlone());
        }

        crow.transform.position += (crow.GetAvoidanceDirection() * Time.deltaTime);
    }

    public override void FixedUpdate()
    {

    }

    public override void LateUpdate()
    {
        Gizmos.DrawLine(crow.transform.position, crow.transform.position + crow.GetAvoidanceDirection());
    }

    public override void OnCollisionEnter(Collision other)
    {

    }

    public override void OnCollisionExit(Collision other)
    {

    }

    public override void OnTriggerEnter(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }

    public override void OnStateEnter()
    {
        crow = machine.GetComponent<Crow>();
    }

    public override void OnStateExit()
    {

    }
}
