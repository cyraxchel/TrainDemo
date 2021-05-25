using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class ErrorPanel : BaseElement
    {
        [SerializeField]
        GameObject panelRool;
        [SerializeField]
        Button continueButton;
        [SerializeField]
        Button restartButton;

        protected override void OnAwake()
        {
            continueButton.onClick.AddListener(ContinueAction);
            restartButton.onClick.AddListener(RestartAction);
            panelRool.SetActive(false);
        }

        protected override void OnErrorAction(int numberOfErrors)
        {
            base.OnErrorAction(numberOfErrors);
            panelRool.SetActive(true);
        }

        private void RestartAction()
        {
            SceneManager.LoadScene(0);
        }

        private void ContinueAction()
        {
            panelRool.SetActive(false);
        }


    }
}