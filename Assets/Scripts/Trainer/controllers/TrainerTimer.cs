using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer.controllers
{
    public class TrainerTimer : MonoBehaviour
    {
        public TimeReadyEvent TrainTimeReady;

        float trainerStartTime = 0;
        float trainerEndTime = 0;
        public float TotalTime { get { return trainerEndTime - trainerStartTime; } }
        public string TotalTimeFormat
        {
            get
            {
                TimeSpan ts = TimeSpan.FromSeconds(TotalTime);
                return string.Format("{0:D2}h:{1:D2}m:{2:D2}s", ts.Hours, ts.Minutes, ts.Seconds);
            }
        }
        // Start is called before the first frame update
        void Awake()
        {
            TrainSteps.TrainConfigurationComplete += Subscribelisteners;
        }

        private void Subscribelisteners(TrainModel model)
        {
            model.TrainStart += FixStartTime;
            model.TrainFinished += FixEndTime;
        }

        private void FixEndTime(int totaltime)
        {
            trainerEndTime = Time.timeSinceLevelLoad;

            Debug.Log(trainerStartTime);
            Debug.Log(trainerEndTime);

            TrainTimeReady?.Invoke(TotalTimeFormat);
        }

        private void FixStartTime()
        {
            trainerStartTime = Time.timeSinceLevelLoad;
        }

        // Update is called once per frame
        void Update()
        {

        }

        [Serializable]
        public class TimeReadyEvent : UnityEvent<string> { }
    }
}