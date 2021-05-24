using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cyraxchel.trainer.config;
using System;

namespace cyraxchel.trainer.controllers
{

    public class StepInfo : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI infoField;
        [SerializeField]
        GameObject rootPanel;

        // Start is called before the first frame update
        void Awake()
        {
            TrainSteps.TrainConfigurationComplete += Subscribelisteners;
            infoField.text = "";
        }

        private void Subscribelisteners(TrainModel model)
        {
            model.StepChanged += OnStepChanged;
            model.TrainFinished += OnFinishTraining;
        }

        private void OnFinishTraining(int err)
        {
            rootPanel.SetActive(false);
        }

        private void OnStepChanged(Step step)
        {
            infoField.text = step.Label;
        }

        
    }
}