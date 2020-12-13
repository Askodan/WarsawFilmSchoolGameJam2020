using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectRotation : SkillEffect
{
    [SerializeField]
    private float restAngle;
    [SerializeField]
    private float activeAngle;
    [SerializeField]
    private Vector3 axis;
    [SerializeField]
    private float speed;
    public override void Activate()
    {
        StartCoroutine(Rotate(restAngle, activeAngle));
    }
    public override void Deactivate()
    {
        StartCoroutine(Rotate(activeAngle, restAngle));
    }

    private IEnumerator Rotate(float start, float end)
    {
        float current = start;
        while (current != end)
        {
            SetRotation(current);
            current = Mathf.MoveTowards(current, end, Time.deltaTime * speed);
            yield return null;
        }
        SetRotation(end);
    }
    private void SetRotation(float angle)
    {
        transform.localRotation = Quaternion.Euler(axis * angle);

    }
}
