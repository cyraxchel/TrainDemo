using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cyraxchel.trainer.config;
using cyraxchel.trainer;
using System;

public class BaseElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    private void Awake()
    {
        TrainSteps.TrainConfigurationComplete += Subscribelisteners;
        OnAwake();
    }

    protected virtual void Subscribelisteners(TrainModel model)
    {
        TrainSteps.TrainConfigurationComplete -= Subscribelisteners;
        model.TrainStart += OnTrainingStart;
        model.TrainFinished += OnTrainingFinish;
        model.StepChanged += OnStepChanged;
        model.ErrorAction += OnErrorAction;
    }

    protected virtual void OnTrainingStart()
    {
        
    }

    protected virtual void OnTrainingFinish(int numberOfErrors)
    {
        
    }

    protected virtual void OnStepChanged(Step currentStep)
    {
        
    }

    protected virtual void OnErrorAction(int numberOfErrors)
    {
        
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnAwake()
    {

    }

}
