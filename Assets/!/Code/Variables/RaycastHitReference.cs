using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class RaycastHitReference
{
    public bool UseConstant = true;
    public RaycastHit ConstantValue;

    public RaycastHitVariable Variable;


    public RaycastHitReference() { }

    public RaycastHitReference(RaycastHit value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public RaycastHit Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator RaycastHit(RaycastHitReference reference)
    {
        return reference.Value;
    }

}
