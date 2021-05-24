using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class HighlightElement : MonoBehaviour
    {
        bool isSelected = false;
        Outline outline;

        // Start is called before the first frame update
        void Awake()
        {
            outline = gameObject.AddComponent<Outline>();
            DisableStepState();
            TrainSteps.TrainConfigurationComplete += Subscribelisteners;
        }

        private void Subscribelisteners(TrainModel model)
        {
            model.StepChanged += OnStepChnaged;
        }

        private void OnStepChnaged(Step currentstep)
        {
            if (currentstep.Go == gameObject)
            {
                //do action
                EnableStepState();
                isSelected = true;
            }
            else if (isSelected)
            {
                DisableStepState();
                isSelected = false;
            }
        }

        private void EnableStepState()
        {
            outline.eraseRenderer = false;
            outline.enabled = true;
        }

        private void DisableStepState()
        {
            outline.eraseRenderer = true;
            outline.enabled = false;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}