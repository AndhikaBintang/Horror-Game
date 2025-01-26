using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Heatlh_UI : MonoBehaviour
{
    
    private float health;
    
    [Header("health bar")]
    public float maxHeatlh = 100f;
    public float chipSpeed = 2f;
    public Image frontHeatlhBar;
    public Image backHeatlhBar;
    public TextMeshProUGUI healthText;
    private float lerpTimer;

    [Header("demage overlay")]
    public Image overlay;
    public float duration;
    public float fadespeed;

    private float durationtimer;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHeatlh;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHeatlh);
        UpdateHealthUI();

        // Handle the overlay fading logic
        if (overlay.color.a > 0)
        {
            durationtimer += Time.deltaTime;

            if (durationtimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadespeed; // Gradually reduce the alpha
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, Mathf.Clamp01(tempAlpha));
            }
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHeatlhBar.fillAmount;
        float fillB = backHeatlhBar.fillAmount;
        float hFraction = health / maxHeatlh;

        // Update the front bar immediately to match the current health
        frontHeatlhBar.fillAmount = hFraction;

        if (fillB > hFraction) // Back bar lags behind for a "chip" effect
        {
            backHeatlhBar.color = Color.red; // Change color for visual feedback
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHeatlhBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        else 
        {
            // Reset lerpTimer if no damage is being taken
            lerpTimer = 0f;
            backHeatlhBar.fillAmount = hFraction;
        }
        if(fillF < hFraction)
        {
            backHeatlhBar.color = Color.green;
            backHeatlhBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer/chipSpeed;
            backHeatlhBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
            frontHeatlhBar.fillAmount=Mathf.Lerp(fillF,backHeatlhBar.fillAmount,percentComplete);

        }
        else
        {
            // Reset lerpTimer if no damage is being taken
            lerpTimer = 0f;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;

        // Reset the duration timer and set the overlay alpha to fully visible
        durationtimer = 0f; // Reset the duration timer for the fade effect
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);
    }


    public void restoreHealth(float healAmmount)
    {
        health += healAmmount;
        lerpTimer=0f;
    }
}
