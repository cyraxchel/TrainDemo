using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Step 
{
    [SerializeField, Tooltip("Описание выполняемой операции"), TextArea(2, 5)]
    string label;
    [SerializeField, Tooltip("Используемый GO")]
    GameObject go;

    public string Label { get => label; set => label = value; }
    public GameObject Go { get => go; set => go = value; }
}
