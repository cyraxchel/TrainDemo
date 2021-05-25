using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class TrainerTimer : BaseElement
    {

        float trainerStartTime = 0;
        float trainerEndTime = 0;

        public TimeValue TotalTimeInstance;

        protected override void OnTrainingStart()
        {
            base.OnTrainingStart();
            trainerStartTime = Time.timeSinceLevelLoad;
        }
        protected override void OnTrainingFinish(int numberOfErrors)
        {
            base.OnTrainingFinish(numberOfErrors);
            trainerEndTime = Time.timeSinceLevelLoad;
            TotalTimeInstance.TotalTime = trainerEndTime - trainerStartTime;
        }
    }
}