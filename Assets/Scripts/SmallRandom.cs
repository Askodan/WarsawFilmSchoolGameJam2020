using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRandom : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool lerp = true;
    [SerializeField] bool local = true;
    [SerializeField] Vector2 positionTimeInterval;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Vector3 positionMax;
    Vector3 positionNew;
    Vector3 positionStart;
    Vector3 localPositionNew;
    Vector3 localPositionStart;
    [SerializeField] float positionSpeed = 1f;
    [SerializeField] bool positionx;
    [SerializeField] bool positiony;
    [SerializeField] bool positionz;

    [SerializeField] Vector2 rotationTimeInterval;
    [SerializeField] Vector3 rotationMax;
    Vector3 rotationNew;
    Vector3 rotationStart;
    Vector3 localRotationNew;
    Vector3 localRotationStart;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] bool rotationx;
    [SerializeField] bool rotationy;
    [SerializeField] bool rotationz;

    [SerializeField] Vector2 scaleTimeInterval;
    [SerializeField] Vector3 scaleMax;
    Vector3 scaleNew;
    Vector3 scaleStart;
    Vector3 localScaleNew;
    Vector3 localScaleStart;

    [SerializeField] float scaleSpeed = 1f;
    [SerializeField] bool scalex;
    [SerializeField] bool scaley;
    [SerializeField] bool scalez;
    // Use this for initialization
    void Awake()
    {
        if (!target)
        {
            target = gameObject;
        }
        positionStart = target.transform.position;
        positionNew = positionStart;
        rotationStart = target.transform.rotation.eulerAngles;
        rotationNew = rotationStart;
        scaleStart = target.transform.localScale;
        scaleNew = scaleStart;
        localPositionStart = target.transform.localPosition;
        localPositionNew = localPositionStart;
        localRotationStart = target.transform.localRotation.eulerAngles;
        localRotationNew = localRotationStart;
        localScaleStart = target.transform.localScale;
        localScaleNew = scaleStart;
        OnEnable();
    }

    IEnumerator ChangePosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(positionTimeInterval.x, positionTimeInterval.y));
            Vector3 result = positionStart;
            if (positionx)
            {
                result.x += Random.Range(-positionMax.x, positionMax.x);
            }
            if (positiony)
            {
                result.y += Random.Range(-positionMax.y, positionMax.y);
            }
            if (positionz)
            {
                result.z += Random.Range(-positionMax.z, positionMax.z);
            }
            positionNew = result + positionOffset;
        }
    }
    IEnumerator ChangeLocalPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(positionTimeInterval.x, positionTimeInterval.y));
            Vector3 result = localPositionStart;
            if (positionx)
            {
                result.x += Random.Range(-positionMax.x, positionMax.x);
            }
            if (positiony)
            {
                result.y += Random.Range(-positionMax.y, positionMax.y);
            }
            if (positionz)
            {
                result.z += Random.Range(-positionMax.z, positionMax.z);
            }
            localPositionNew = result + positionOffset;
        }
    }

    IEnumerator ChangeRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(rotationTimeInterval.x, rotationTimeInterval.y));
            Vector3 result = rotationStart;
            if (rotationx)
            {
                result.x += Random.Range(-rotationMax.x, rotationMax.x);
            }
            if (rotationy)
            {
                result.y += Random.Range(-rotationMax.y, rotationMax.y);
            }
            if (rotationz)
            {
                result.z += Random.Range(-rotationMax.z, rotationMax.z);
            }
            rotationNew = result;
        }
    }

    IEnumerator ChangeLocalRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(rotationTimeInterval.x, rotationTimeInterval.y));
            Vector3 result = localRotationStart;
            if (rotationx)
            {
                result.x += Random.Range(-rotationMax.x, rotationMax.x);
            }
            if (rotationy)
            {
                result.y += Random.Range(-rotationMax.y, rotationMax.y);
            }
            if (rotationz)
            {
                result.z += Random.Range(-rotationMax.z, rotationMax.z);
            }
            localRotationNew = result;
        }
    }

    IEnumerator ChangeScale()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(scaleTimeInterval.x, scaleTimeInterval.y));
            Vector3 result = scaleStart;
            if (scalex)
            {
                result.x += Random.Range(-scaleMax.x, scaleMax.x);
            }
            if (rotationy)
            {
                result.y += Random.Range(-scaleMax.y, scaleMax.y);
            }
            if (rotationz)
            {
                result.z += Random.Range(-scaleMax.z, scaleMax.z);
            }
            scaleNew = result;
        }
    }
    IEnumerator ChangeLocalScale()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(scaleTimeInterval.x, scaleTimeInterval.y));
            Vector3 result = localScaleStart;
            if (scalex)
            {
                result.x += Random.Range(-scaleMax.x, scaleMax.x);
            }
            if (rotationy)
            {
                result.y += Random.Range(-scaleMax.y, scaleMax.y);
            }
            if (rotationz)
            {
                result.z += Random.Range(-scaleMax.z, scaleMax.z);
            }
            localScaleNew = result;
        }
    }
    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        var sca = Vector3.one;
        if (local)
        {
            if (lerp)
            {
                pos = Vector3.Lerp(target.transform.localPosition, localPositionNew, Time.deltaTime * positionSpeed);
                rot = Quaternion.Lerp(target.transform.localRotation, Quaternion.Euler(localRotationNew), Time.deltaTime * rotationSpeed);
                sca = Vector3.Lerp(target.transform.localScale, scaleNew, Time.deltaTime * scaleSpeed);
            }
            else
            {
                pos = Vector3.MoveTowards(target.transform.localPosition, localPositionNew, Time.deltaTime * positionSpeed);
                rot = Quaternion.RotateTowards(target.transform.localRotation, Quaternion.Euler(localRotationNew), Time.deltaTime * rotationSpeed);
                sca = Vector3.MoveTowards(target.transform.localScale, scaleNew, Time.deltaTime * scaleSpeed);
            }
            target.transform.localPosition = pos;
            target.transform.localRotation = rot;
            target.transform.localScale = sca;
        }
        else
        {
            if (lerp)
            {
                pos = Vector3.Lerp(target.transform.position, positionNew, Time.deltaTime * positionSpeed);
                rot = Quaternion.Lerp(target.transform.rotation, Quaternion.Euler(rotationNew), Time.deltaTime * rotationSpeed);
                sca = Vector3.Lerp(target.transform.localScale, scaleNew, Time.deltaTime * scaleSpeed);
            }
            else
            {
                pos = Vector3.MoveTowards(target.transform.position, positionNew, Time.deltaTime * positionSpeed);
                rot = Quaternion.RotateTowards(target.transform.rotation, Quaternion.Euler(rotationNew), Time.deltaTime * rotationSpeed);
                sca = Vector3.MoveTowards(target.transform.localScale, scaleNew, Time.deltaTime * scaleSpeed);
            }
            target.transform.position = pos;
            target.transform.rotation = rot;
            target.transform.localScale = sca;
        }
    }
    void OnDisable()
    {
        if (local)
        {
            target.transform.localPosition = positionStart;
            target.transform.localRotation = Quaternion.Euler(rotationStart);
            target.transform.localScale = scaleStart;
        }
        else
        {
            target.transform.position = positionStart;
            target.transform.rotation = Quaternion.Euler(rotationStart);
            target.transform.localScale = scaleStart;
        }
    }
    void OnEnable()
    {
        StartCoroutine(ChangePosition());
        StartCoroutine(ChangeRotation());
        StartCoroutine(ChangeScale());
        StartCoroutine(ChangeLocalPosition());
        StartCoroutine(ChangeLocalRotation());
        StartCoroutine(ChangeLocalScale());
    }
    public void SetStartPos(Vector3 val)
    {
        positionStart = val;
    }
}
