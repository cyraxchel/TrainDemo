using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FinishPanel : MonoBehaviour
{

    [SerializeField]
    GameObject panelRool;
    
    [SerializeField]
    Button restartButton;
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI errorCountText;


    private void Awake()
    {
        TrainSteps.TrainConfigurationComplete += Subscribelisteners;
        restartButton.onClick.AddListener(RestartAction);
        panelRool.SetActive(false);
        timeText.text = "";
        errorCountText.text = "";
        panelRool.SetActive(false);
    }

    private void RestartAction()
    {
        SceneManager.LoadScene(0);
    }


    private void Subscribelisteners(TrainModel model)
    {
        model.TrainFinished += ShowStatistics;
    }

    private void ShowStatistics(int numErrors)
    {

        errorCountText.text = numErrors.ToString() ;
        panelRool.SetActive(true);
    }

    public void SetTotalTimeText(string totaltime)
    {
        timeText.text = totaltime;
    }
}
