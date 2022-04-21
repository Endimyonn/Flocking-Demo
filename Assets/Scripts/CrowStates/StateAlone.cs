using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlone : CrowState
{
    public override void Awake()
    {

    }

    public override void Update()
    {

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
