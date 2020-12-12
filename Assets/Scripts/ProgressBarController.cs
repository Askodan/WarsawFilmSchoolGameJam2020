using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform progressBarTransform;

    [SerializeField]
    public float progress = 0.1f;

    private Vector3 scaleChange;

    [SerializeField]
    private LevelProgress levelProgress;
    // Start is called before the first frame update
    void Start()
    {
        progressBarTransform = gameObject.GetComponent<RectTransform>();
        levelProgress = FindObjectOfType<LevelProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        progress = levelProgress.DistanceTraveled / levelProgress.levelLength;
        //Gdy coś będziemy robić, tutaj trzeba będzie zrobić wypełnianie.
        progress = Mathf.Clamp(progress, 0.0f, 1.0f);
        scaleChange = new Vector3(progress, 1.0f, 1.0f);
        progressBarTransform.localScale = scaleChange;
    }
}
