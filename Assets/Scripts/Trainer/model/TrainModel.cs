using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cyraxchel.trainer.config;

namespace cyraxchel.trainer
{
    public class TrainModel
    {


        public event Action TrainStart = delegate { };
        /// <summary>
        /// Event for finish training. Send number of train errors.
        /// </summary>
        public event Action<int> TrainFinished = delegate { };
        /// <summary>
        /// Dispatched when incorrect element selected.
        /// Send current error counts.
        /// </summary>
        public event Action<int> ErrorAction = delegate { };
        public event Action<Step> StepChanged = delegate { };

        Step curentStep = null;
        int errorCount = 0;
        Queue<Step> trainSteps = null;
        public static TrainModel Instance { get; internal set; }

        public TrainModel(List<Step> steps)
        {
            trainSteps = new Queue<Step>();
            foreach (Step item in steps)
            {
                trainSteps.Enqueue(item);
            }
        }

        internal void OnElementClick(GameObject go)
        {
            // Debug.Log("OnElementClick ");
            if (curentStep != null)
            {
                if (go == curentStep.Go)
                {
                    LoadNextStep();
                }
                else
                {
                    errorCount++;
                    ErrorAction?.Invoke(errorCount);
                }
            }
        }

        internal void OnElementPress(GameObject go)
        {
            //Debug.Log("OnElementPress ");
        }

        internal void StartTrain()
        {
            errorCount = 0;
            curentStep = null;
            TrainStart?.Invoke();
            LoadNextStep();
        }

        private void LoadNextStep()
        {
            if (trainSteps.Count > 0)
            {
                curentStep = trainSteps.Dequeue();
                StepChanged?.Invoke(curentStep);
                Debug.Log("Next step for " + curentStep.Go);
            }
            else
            {
                //finish
                TrainFinished?.Invoke(errorCount);
            }

        }
    }
}