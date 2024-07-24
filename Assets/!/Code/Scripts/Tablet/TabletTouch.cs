using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TabletTouch : MonoBehaviour
{
    [SerializeField] private Material m_material;
    [SerializeField] private Vector3Reference m_lastTabletTouch;

    private LocalKeyword m_ripples;

    private bool _toggle = false;
    private float _lerpTimer = 0;

    private static readonly int RippleTime = Shader.PropertyToID("_Ripple_Time");
    private static readonly int RippleOrigin = Shader.PropertyToID("_Ripple_Origin");

    void Start()
    {
        m_ripples = new LocalKeyword(m_material.shader, "_USE_RIPPLES");
    }

    void Update()
    {
        if (_toggle)
        {
            TouchUpdate(m_lastTabletTouch.Variable.Value.x, m_lastTabletTouch.Variable.Value.y);
        }
    }

    public void OnTouchEvent()
    {
        _toggle = true;
        _lerpTimer = 0;
    }

    private void TouchUpdate(float x, float y)
    {
        var t = Mathf.Lerp(0, 1, _lerpTimer);
        _lerpTimer += Time.deltaTime;

        m_material.SetVector(RippleOrigin, new Vector4(x, y));
        m_material.SetFloat(RippleTime, t);
        if (t == 1)
        {
            _toggle = false;
        }
    }
}