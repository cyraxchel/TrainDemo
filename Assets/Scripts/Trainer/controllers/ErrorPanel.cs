using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField]
    GameObject panelRool;
    [SerializeField]
    Button continueButton;
    [SerializeField]
    Button restartButton;


    private void Awake()
    {
        TrainSteps.TrainConfigurationComplete += Subscribelisteners;
        continueButton.onClick.AddListener(ContinueAction);
        restartButton.onClick.AddListener(RestartAction);
        panelRool.SetActive(false);
    }

    private void RestartAction()
    {
        SceneManager.LoadScene(0);
    }

    private void ContinueAction()
    {
        panelRool.SetActive(false);
    }


    private void Subscribelisteners(TrainModel model)
    {
        model.ErrorAction += OnTrainError;
    }

    private void OnTrainError(int erorcounted)
    {
        panelRool.SetActive(true);
    }

}
