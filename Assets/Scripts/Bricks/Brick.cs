﻿using UnityEngine;

public class Brick : MonoBehaviour
{
    public float m_axisY;

    public float m_BounceTime = 0.3f;
    public float m_BounceDistance = 0.3f;
    public AnimationCurve m_Curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
    private Vector3 m_Source;
    private Bounds m_Bounds;
    private bool m_CanBounce;
    private float m_StartTime;

    public AudioClip m_BounceAudioClip;

    private Animator m_anim;

    private void Start()
    {
        m_Source = transform.position;
        m_Bounds = GetComponent<Collider>().bounds;
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = new Vector3(m_Source.x,
                                         m_Source.y + m_axisY,
                                         m_Source.z);
    }
    /*private void LateUpdate()
    {
        if (!m_CanBounce) return;

        var time = (Time.time - m_StartTime) / m_BounceTime;
        transform.position = m_Source + Vector3.up * m_BounceDistance * m_Curve.Evaluate(time);

        m_CanBounce = time < 1.0f;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        var impact = collision.contacts[0].point;
        var isBelowBrick = impact.y <= m_Bounds.min.y;
        if (!isBelowBrick) return;

        m_anim.SetTrigger("Vai");
        /*m_CanBounce = true;
        m_StartTime = Time.time;*/
    }
}

