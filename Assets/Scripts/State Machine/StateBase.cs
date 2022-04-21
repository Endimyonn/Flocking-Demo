using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base class for a state in a State Machine. Can be used as an effective "micro game
//controller" - where each state works independently but transition smoothly between
//each other. This eliminates many problems of cramming all of the code into one script,
//and is much easier to manage and work with.
public class StateBase
{
    public StateMachine machine;
    public List<string> validTransitions = new List<string>(); //todo: find a clean way to implement flags enum or similar to replace this without hardcoding specific states into this base class

    //The machine activating this state should always call this, usually with a reference to itself
    public virtual void StateInitialize(StateMachine argMachine)
    {
        machine = argMachine;
    }

    //Awake is called after StateInitialize
    public virtual void Awake()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {

    }

    public virtual void OnCollisionEnter(Collision other)
    {
        Debug.LogWarning("State with no override for OnCollisionEnter() has called it");
    }

    public virtual void OnCollisionExit(Collision other)
    {
        Debug.LogWarning("State with no override for OnCollisionExit() has called it");
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("State with no override for OnTriggerEnter() has called it");
    }

    public virtual void OnTriggerExit(Collider other)
    {
        Debug.LogWarning("State with no override for OnTriggerExit() has called it");
    }

    //external enabler that calls the overridable internal enabler function
    public void StateEnter()
    {
        OnStateEnter();
    }

    public virtual void OnStateEnter()
    {
        Debug.LogWarning("State with no override for OnStateEnter() has called it");
    }

    public void StateExit()
    {
        OnStateExit();
    }

    public virtual void OnStateExit()
    {
        Debug.LogWarning("State with no override for OnStateExit() has called it");
    }
}