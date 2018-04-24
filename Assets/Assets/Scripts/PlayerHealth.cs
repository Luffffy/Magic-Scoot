using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public PlayerController Player;
    public Image FillImage;


    void Update()
    {
        if (FillImage && Player)
        {
            FillImage.fillAmount = Player.currentHealth / Player.maxHealth;
        }
    }
}
