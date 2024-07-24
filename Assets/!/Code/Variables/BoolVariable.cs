using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public bool Value;

    public void SetValue(bool value) {
        Value = value;
    }

    public void SetValue(BoolVariable value) {
        Value = value;
    }

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
