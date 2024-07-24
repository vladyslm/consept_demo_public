using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SnapGroundElement : MonoBehaviour
{
    [SerializeField] private GroundBlueprintContainer m_Container;

    void FixedUpdate()
    {
        var moveVector =
            Vector3.MoveTowards(m_Container.Target.transform.position, m_Container.transform.position, 100);
        m_Container.Target.transform.position = moveVector;

        if (m_Container.transform.position != m_Container.Target.transform.position) return;
        var x = Mathf.Round(m_Container.transform.position.x);
        var z = Mathf.Round(m_Container.transform.position.z);
        m_Container.Target.transform.position = new Vector3(x, 0, z);
    }
}