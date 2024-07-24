using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material _material;

    private static readonly int DissolveID = Shader.PropertyToID("_Dissolve");

    private void Awake()
    {
        _material = transform.GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        StartCoroutine(AppearanceEffect());
    }

    private IEnumerator AppearanceEffect()
    {
        var transition = 0f;
        while (transition <= 1)
        {
            var value = Mathf.Lerp(1, 0, transition);
            transition += Time.deltaTime;
            _material.SetFloat(DissolveID, value);
            yield return null;
        }

        _material.SetFloat(DissolveID, 0);
    }
}