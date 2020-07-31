using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : Logical
{
    [SerializeField]
    private GameObject _objectToActivate;
    protected Activatable _activatable;

    protected override void Start()
    {
        base.Start();

        var activatable = _objectToActivate.GetComponent<Activatable>();

        if (activatable != null)
        {
            _activatable = activatable;   
        }
        else
            Debug.LogError($"Activatable Not Assigned For {gameObject.name}");
    }

    protected override void ChangeState()
    {
        base.ChangeState();
    }

    public override void Activate()
    {
        _activatable.Activate();
    }

    public override void Deactivate()
    {
        _activatable.Deactivate();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, _objectToActivate.transform.position);
    }
}
