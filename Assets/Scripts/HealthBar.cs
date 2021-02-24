using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health){
        healthBar.maxValue = health;
        healthBar.value = health;
        fill.color = gradient.Evaluate(1.0f);
    }
    public void SetHealth(int health){
        healthBar.value = health;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
