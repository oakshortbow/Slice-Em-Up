using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaController : MonoBehaviour {

    public int playerMaxStamina;
    public int playerCurrentStamina;
    public int oldStamina;


    // Use this for initialization
    void Start()
    {
        playerCurrentStamina = playerMaxStamina;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseStamina(int staminaToUse)
    {
        oldStamina = playerCurrentStamina;
        playerCurrentStamina-= staminaToUse;
    }

    public void SetMaxStamina()
    {
        playerCurrentStamina = playerMaxStamina;
    }


    }
