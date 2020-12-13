using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text result;
    LevelProgress levelProgress;
    [SerializeField]
    SkillHandler skillHandler;
    [SerializeField]
    GameObject screen;

    void Awake()
    {
        levelProgress = FindObjectOfType<LevelProgress>();
        screen.SetActive(false);
    }
    void Update()
    {
        if (levelProgress.Progress / levelProgress.LevelLength > 1f)
        {
            Over();
        }
    }
    void Over()
    {
        screen.SetActive(true);
        result.text = skillHandler.hasAllSkills() ? "Zwycięstwo" : "Porażka";
        Time.timeScale = 0f;
    }
}
