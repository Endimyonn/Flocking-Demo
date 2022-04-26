using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlone : CrowState
{
    Vector3 moveDirection;

    public override void Awake()
    {
        moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        moveDirection *= 4;
    }

    public override void Update()
    {
        crow.CheckAround();

        if (crow.avoidThese.Count > 0)
        {
            machine.ChangeState(new StateAvoidance());
        }

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
