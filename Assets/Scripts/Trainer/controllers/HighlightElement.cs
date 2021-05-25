using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class HighlightElement : BaseElement
    {
        bool isSelected = false;
        List<Outline> outline;

        protected override void OnAwake()
        {
            base.OnAwake();
            AddOutline();
            DisableStepState();
        }

        private void AddOutline()
        {
            outline = new List<Outline>();
            Renderer[] rnds = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var item in rnds)
            {
                outline.Add(item.gameObject.AddComponent<Outline>());
            }
        }

        protected override void OnStepChanged(Step currentStep)
        {
            base.OnStepChanged(currentStep);
            if (currentStep.Go == gameObject)
            {
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
            outline.ForEach(delegate (Outline item) { item.eraseRenderer = false; item.enabled = true; });
        }

        private void DisableStepState()
        {
            outline.ForEach(delegate (Outline item) { item.eraseRenderer = true; item.enabled = false; });
        }

    }
}