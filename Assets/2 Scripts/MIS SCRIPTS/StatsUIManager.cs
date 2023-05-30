using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


//El script que tiene las funcionalides del UI del stats manager
public class StatsUIManager : MonoBehaviour
{
    [SerializeField] public StatsManager _statsManager;
    [SerializeField] public Slider _hungerMeter, _thirstMeter, _staminaMeter;


    private void Update()
    {
        _hungerMeter.value = StatsManager.singleton.HungerPercent;
        _thirstMeter.value = StatsManager.singleton.ThirstPercent;
        _staminaMeter.value = StatsManager.singleton.StaminaPercent;

    }

}
