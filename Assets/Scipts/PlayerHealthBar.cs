using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    private Text healthText;
    public static int healthCurrent;
    public static int healthMax;

    private Image healthBar;

    void Start()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        healthBar = GetComponent<Image>();
    }


    void Update()
    {
        healthBar.fillAmount = (float)healthCurrent/(float)healthMax;
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
