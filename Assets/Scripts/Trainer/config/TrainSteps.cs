using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cyraxchel.trainer.utils;
using cyraxchel.trainer;


namespace cyraxchel.trainer.config
{
    /// <summary>
    /// Training steps configurator
    /// </summary>
    public class TrainSteps : MonoBehaviour
    {
        public static Action<TrainModel> TrainConfigurationComplete = delegate { };

        [Header("Конфигурация выполняемых действий:")]

        [SerializeField]
        List<Step> steps;

        TrainModel model;

        public List<Step> Steps { get => steps; set => steps = value; }


        private void Awake()
        {
            model = new TrainModel(Steps);
            TrainModel.Instance = model;
            //Allow all interested subscribe to model
            //Prepare GO's
            InitElements();
        }

        private void OnDestroy()
        {
            TrainModel.Instance = null;
            TrainConfigurationComplete = delegate { };
        }

        private void Start()
        {
            TrainConfigurationComplete?.Invoke(model);
            model.StartTrain();
        }


        private void InitElements()
        {
            for (int i = 0; i < steps.Count; i++)
            {
                Step item = steps[i];
                ColliderEvent cevent = item.Go.GetComponent<ColliderEvent>();
                if (cevent == null)
                {
                    cevent = ColliderEvent.AddColliderEvent(item.Go);
                    GameObject go = item.Go;
                    cevent.OnClick += delegate { model.OnElementClick(go); };
                    cevent.OnPress += delegate { model.OnElementPress(go); };
                    Debug.Log("add events for " + go.name);
                }

            }
        }
    }
}