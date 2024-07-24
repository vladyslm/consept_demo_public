using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildableObjectReference
{

    public bool UseConstant = true;
    public BuildableSO ConstantValue;

    public BuildableObjectVariable Variable;

    public BuildableObjectReference() { }
    public BuildableObjectReference(BuildableSO value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public BuildableSO Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator BuildableSO(BuildableObjectReference reference)
    {
        return reference.Value;
    }


}
