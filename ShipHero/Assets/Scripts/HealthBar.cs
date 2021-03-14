﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private void Start() {
      slider = GetComponent<Slider>();  
    }
    public void SetMaxHealth(float health){
        slider.maxValue = health;
    }

    public void SetHealth(float health){
        slider.value = health;
    }

    public void ChangeHealth(float health){
        slider.value += health;
    }
}
