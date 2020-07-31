using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logical : MonoBehaviour
{
    protected enum State{On, Off};
    
    protected State _state;

    protected virtual void Start()
    {
        _state = State.Off;
    }

    protected virtual void ChangeState()
    {
        _state = _state == State.Off ? State.On : State.Off;

        if (_state == State.On)
            Activate();
        else 
            Deactivate();
    }

    public virtual void Activate()
    {
        
    }

    public virtual void Deactivate()
    {
        
    }
}
