using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuLogic : MonoBehaviour
{
    LevelProgress lp;
    ItemSpawnerMenu ism;
    [SerializeField]
    float velocity = 10f;
    void Awake()
    {
        ism = FindObjectOfType<ItemSpawnerMenu>();
        lp = FindObjectOfType<LevelProgress>();

    }
    void Start()
    {
        lp.modifySpeed(velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        lp.modifySpeed(0f);
    }

    void OnNext()
    {
        ism.AllowSpawn = true;
        lp.modifySpeed(velocity);
    }
    void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
