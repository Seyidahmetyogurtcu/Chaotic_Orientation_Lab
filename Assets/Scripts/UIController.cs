using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform UIMenu;
    [SerializeField] private GameObject menuPanel;
    public  Animator buttonAnimation;
    public Animator bgButtonAnimation;
    public static  UIController singleton;
    private Vector3 uIPositionSpace;
    public bool isPauseMenuPanelsOpen = false;

    void Start()
    {
        singleton = this;
    }
    public void IsMenuPanelsOpen(bool isPauseMenuOpen)
    {
        isPauseMenuPanelsOpen = isPauseMenuOpen;
    }
    public void ContinueGame()
    {
        isPauseMenuPanelsOpen = false;
        menuPanel.SetActive(false);
        //Time.timeScale = (float)Enums.Paused.continueGame;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPauseMenuPanelsOpen)
        {
            // UnityEditor.EditorApplication.isPaused = true;  //This is not work. find something usefull
            menuPanel.SetActive(true);
            isPauseMenuPanelsOpen = true;
          //  Time.timeScale = (float)Enums.Paused.continueGame;
        }
        //if (isPauseMenuPanelsOpen)
        //{
        //    Time.timeScale = (float)Enums.Paused.pauseGame;
        //}
        //else
        //{
        //    Time.timeScale = (float)Enums.Paused.continueGame;
        //}

        uIPositionSpace = player.forward * 4 + player.up * 1;
        UIMenu.transform.position = new Vector3(player.localPosition.x, player.localPosition.y, player.localPosition.z) + uIPositionSpace;
        UIMenu.forward = player.forward;
        //refresh every 0.1sec  
        StartCoroutine(SetUIPosition());
    }
    IEnumerator SetUIPosition()
    {

        yield return new WaitForSeconds(0.1f);
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonAnimation.SetTrigger("AnimationTrigger");
        bgButtonAnimation.SetTrigger("bg_AnimationTrigger");
        //buttonAnimation.ResetTrigger("AnimationTrigger");
        //bgButtonAnimation.ResetTrigger("bg_AnimationTrigger");

        //   buttonAnimation.Play(0);
        // bgButtonAnimation.Play(0);
    }

    public void OnDeselect(BaseEventData eventData)
    {

    }

}
