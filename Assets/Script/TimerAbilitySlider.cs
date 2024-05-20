using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerAbilitySlider : MonoBehaviour
{
    public Image timer_img;
    float timeRemaining;
    public float fullTime = 100f;
    public CharacterAbility CharacterAbility;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = fullTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            
            timer_img.fillAmount = CharacterAbility.TimerMana / fullTime;
        }

        
    }
}
