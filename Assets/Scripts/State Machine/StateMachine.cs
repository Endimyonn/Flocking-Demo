using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public string defaultState;
    protected StateBase curState;
    protected StateBase lastState;

    //for external use
    public string currentState = "";
    public string previousState = "";

    protected virtual void Awake()
    {
        curState = (StateBase)System.Activator.CreateInstance(System.Type.GetType(defaultState));
        curState.StateInitialize(this);
        curState.Awake();
        curState.StateEnter();

        currentState = curState.GetType().ToString();
    }

    public virtual void ChangeState(StateBase argState)
    {
        ChangeStateResult stateChange = ChangeStateConfirm(argState);
        if (stateChange.success == false)
        {
            switch (stateChange.failureReason)
            {
                case ChangeStateFailureReason.CurrentStateRefused:
                    Debug.LogWarning("Could not change state to " + argState.GetType().ToString() + ". Current state (" + curState.GetType().ToString() + ") refused change.");
                    break;
                case ChangeStateFailureReason.InvalidState:
                    Debug.LogWarning("Could not change state to " + argState.GetType().ToString() + ". State type does not exist.");
                    break;
            }
        }
        else
        {
            //DebugConsole.FeedEntry("State changed to " + argState.GetType().ToString(), "", FeedEntryType.Info);
        }
    }
    
    protected virtual ChangeStateResult ChangeStateConfirm(StateBase argState)
    {
        ChangeStateResult returnValue;
        returnValue.success = false;
        returnValue.failureReason = ChangeStateFailureReason.None;

        if (argState != null && argState.GetType() != curState.GetType())
        {
            if (curState.validTransitions.Contains(argState.GetType().ToString()))
            {
                if (curState != null)   //make sure it exists first to prevent issues when first setting the state on init
                {
                    lastState = curState;
                    previousState = lastState.GetType().ToString();
                    curState.StateExit();
                }
                curState = argState;
                currentState = curState.GetType().ToString();
                curState.StateInitialize(this);
                curState.Awake();
                curState.StateEnter();
                returnValue.success = true;
            }
            else
            {
                returnValue.failureReason = ChangeStateFailureReason.CurrentStateRefused;
            }
        }
        else if (argState == null && argState.GetType() == curState.GetType())
        {
            returnValue.failureReason = ChangeStateFailureReason.InvalidState;
        }
        else
        {
            returnValue.failureReason = ChangeStateFailureReason.SameState;
        }
        return returnValue;
    }







    //Below are passthrough functions - the StateMachine acts as a pipeline and passes
    //data to the active state. Do not add any non-Unity ones here - create a derivative
    //class and add them to it.
    protected virtual void Update()
    {
        curState.Update();
    }

    protected virtual void FixedUpdate()
    {
        curState.FixedUpdate();
    }

    protected virtual void LateUpdate()
    {
        curState.LateUpdate();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        curState.OnCollisionEnter(other);
    }

    protected virtual void OnCollisionExit(Collision other)
    {
        curState.OnCollisionExit(other);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        curState.OnTriggerEnter(other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        curState.OnTriggerExit(other);
    }

    //todo: other ons (eg gui)
}

public struct ChangeStateResult
{
    public bool success;
    public ChangeStateFailureReason failureReason;
}

public enum ChangeStateFailureReason : byte
{
    None,
    CurrentStateRefused,
    InvalidState,
    SameState
}