using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class FinishPanel : BaseElement
    {

        [SerializeField]
        GameObject panelRool;

        [SerializeField]
        Button restartButton;
        [SerializeField]
        TextMeshProUGUI timeText;
        [SerializeField]
        TextMeshProUGUI errorCountText;
        [SerializeField]
        TimeValue totalTime;

        protected override void OnAwake()
        {
            base.OnAwake();
            restartButton.onClick.AddListener(RestartAction);
            panelRool.SetActive(false);
            timeText.text = "";
            errorCountText.text = "";
            panelRool.SetActive(false);
        }

        protected override void OnTrainingFinish(int numberOfErrors)
        {
            base.OnTrainingFinish(numberOfErrors);
            errorCountText.text = numberOfErrors.ToString();
            timeText.text = totalTime.TotalTimeText;
            panelRool.SetActive(true);
        }


        private void RestartAction()
        {
            SceneManager.LoadScene(0);
        }

    }
}