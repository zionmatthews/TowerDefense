using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarBehaviourScript : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        if (slider.value == 0)
        {
            GameOver();
        }
    }

    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth (int health)
    {
        slider.value = health;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
