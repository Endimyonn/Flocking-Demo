using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHungry : CrowState
{
    public override void Awake()
    {
        Debug.Log("entering hungry state");
    }

    public override void Update()
    {
        crow.CheckAround();

        if (crow.avoidThese.Count > 0)
        {
            machine.ChangeState(new StateAvoidance());
        }

        if (crow.targetThis == null)
        {
            machine.ChangeState(new StateAlone());
        }

        Vector3 moveDirection = (crow.transform.position - crow.targetThis.transform.position).normalized * -3;
        moveDirection.y = 0;
        crow.transform.position += moveDirection * Time.deltaTime;
    }

    public override void FixedUpdate()
    {

    }

    public override void LateUpdate()
    {

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
