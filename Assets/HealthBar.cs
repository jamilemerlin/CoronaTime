using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public AudioSource audiocorona;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        audiocorona.volume = 0.001f;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;

        audiocorona.volume = 0.2f - (slider.normalizedValue * 0.2f);

        if (audiocorona.volume < 0.001f)
        {
            audiocorona.volume = 0.001f;
        }   
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
