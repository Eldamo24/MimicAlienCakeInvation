using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private GameObject anyKeyMenu;
    [SerializeField] private GameObject elevatorAnimMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject intro;
    [SerializeField] private AudioSource audio;
    private VideoPlayer vp;


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
                vp = GameObject.Find("DoorAnimation").GetComponent<VideoPlayer>();
            }
        }
        if (vp.isPlaying  && elevatorAnimMenu.activeSelf)
        {
            anyKeyMenu.SetActive(false);
            vp.loopPointReached += CheckEndOfVideo;
        }
        if (vp.isPlaying && intro.activeSelf)
            mainMenu.SetActive(false);
    }

    

    private void CheckEndOfVideo(VideoPlayer vp)
    {
        mainMenu.SetActive(true);
        elevatorAnimMenu.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void onStartClick()
    {
        intro.SetActive(true);
        vp = GameObject.Find("IntroVideo").GetComponent<VideoPlayer>();
        vp.loopPointReached += StartGame;
        audio.Stop();
    }

    private void StartGame(VideoPlayer vp)
    {
        SceneManager.LoadScene("PrototypeLevel1");
    }
}
