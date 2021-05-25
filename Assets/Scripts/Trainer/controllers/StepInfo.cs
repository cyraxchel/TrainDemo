using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cyraxchel.trainer.config;
using System;

namespace cyraxchel.trainer.controllers
{

    public class StepInfo : BaseElement
    {
        [SerializeField]
        TextMeshProUGUI infoField;
        [SerializeField]
        GameObject rootPanel;

        // Start is called before the first frame update
        protected override void OnAwake()
        {
            base.OnAwake();
            infoField.text = "";
        }

        protected override void OnStepChanged(Step currentStep)
        {
            base.OnStepChanged(currentStep);
            infoField.text = currentStep.Label;
        }

        protected override void OnTrainingFinish(int numberOfErrors)
        {
            base.OnTrainingFinish(numberOfErrors);
            rootPanel.SetActive(false);
        }

        
    }
}