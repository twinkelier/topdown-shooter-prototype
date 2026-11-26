using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerController player;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text textXp;
    [SerializeField] private TMP_Text textAmmo;
    [SerializeField] private TMP_Text textHealth;

    void Update()
    {
        textXp.text = "level " + gameManager.currentLevel;
        textAmmo.text = player.currentAmmo + " / " + player.maxAmmo;
        textHealth.text = playerHealth.CurrentHealth + " hp";
    }
}
