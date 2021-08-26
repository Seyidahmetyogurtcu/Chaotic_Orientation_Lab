using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDesign : MonoBehaviour
{
    private bool Animate = false;

    [Header("Functionalities")]
    [SerializeField] private bool isExitButton;

    [SerializeField] private bool isStartButton;


    [Header("Additionals")]
    [SerializeField] private int TargetScene;

    [SerializeField] private float Speed = 0.1f;

    [SerializeField] private float Amplify;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonAnimation();
    }
    private void OnMouseOver()
    {
        Animate = true;

    }
    private void OnMouseDown()
    {
        Exit(isExitButton);
        NextScene(isStartButton, TargetScene);
    }
    private void OnMouseExit()
    {
        Animate = false;
    }
    private void ButtonAnimation()
    {
        Vector3 CRate = Vector3.zero;
        if (Animate)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(Amplify, Amplify, Amplify), ref CRate, Speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(1, 1, 1), ref CRate, Speed * Time.deltaTime);
        }
    }
    private void Exit(bool ExitB)
    {
        if (ExitB)
        {
            Application.Quit();
        }
    }
    private void NextScene(bool StartB, int SceneId)
    {
        if (StartB)
        {
            SceneManager.LoadScene(SceneId);
        }
    }
}
