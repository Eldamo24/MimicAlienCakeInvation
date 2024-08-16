using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private GameObject anyKeyMenu;
    [SerializeField] private GameObject elevatorAnimMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private VideoPlayer vp;

    private void Update()
    {
        CheckStatesAndClicks();
    }

    private void CheckStatesAndClicks()
    {
        if (anyKeyMenu.activeSelf)
        {
            if (Input.anyKey)
            {
                elevatorAnimMenu.SetActive(true);
            }
        }
        if (vp.isPlaying)
        {
            anyKeyMenu.SetActive(false);
            vp.loopPointReached += CheckEndOfVideo;
        }
    }

    private void CheckEndOfVideo(VideoPlayer vp)
    {
        Debug.Log("Termino");
        mainMenu.SetActive(true);
        elevatorAnimMenu.SetActive(false);
    }
}
