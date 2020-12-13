using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    private PlayerInput playerInputController;
    private GameObject shopContainer;
    private GameObject funkProvider;
    private AudioSource funkEmitter;
    
    // Start is called before the first frame update
    public void Start()
    {
        playerInputController = gameObject.GetComponent<PlayerInput>();
        shopContainer = GameObject.Find("ShopContainer");
        funkProvider = GameObject.Find("FunkProvider");
        funkEmitter = funkProvider.GetComponent<AudioSource>();
        shopContainer.SetActive(false);
    }

    public void OnGamePause()
    {
        if(Time.timeScale != 0) {
            funkEmitter.Pause();
            Time.timeScale = 0;
            shopContainer.SetActive(true);
            playerInputController.SwitchCurrentActionMap("Shop");
        }
    }

    public void OnGameUnpause()
    {
        if(Time.timeScale == 0) {
            shopContainer.SetActive(false);
            playerInputController.SwitchCurrentActionMap("Steering");
            Time.timeScale = 1;
            funkEmitter.UnPause();
        }
    }
}
