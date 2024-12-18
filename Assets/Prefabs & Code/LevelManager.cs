using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header ("References")]
    [SerializeField] private TextMeshProUGUI bluerayText;
    [SerializeField] private Button StarbrightButton;
    [SerializeField] private Button HermittButton;

    private float loopTime = 0f;
    public static int bluerays = 200;

    private void Awake(){
        main = this;
    }

    void Start(){
        loopTime = 0f;
        bluerays = 100;
    }

    void FixedUpdate(){
        loopTime += Time.deltaTime;
        if (loopTime > 15f){
            loopTime = 0f;
            int deposit = RandomizeDeposit();
            IncreaseBluerays(deposit);
        }
        if (bluerays > 9999){
            bluerays = 9999;
        }
        ActivateButtons();
        bluerayText.text = bluerays.ToString("0");
    }

    private int RandomizeDeposit(){
        float random = Random.value;
        int deposit = 10;
        if (random <= 0.05f){
            deposit = 5;
        }
        if (random > 0.05f && random <= 0.45f){
            deposit = 10;
        }
        if (random > 0.45f && random <= 0.75f){
            deposit = 15;
        }
        if (random > 0.75f && random <= 0.95f){
            deposit = 20;
        }
        if (random > 0.95f){
            deposit = 25;
        }
        return deposit;
    }

    private void ActivateButtons(){
        if (bluerays >= 25){
            StarbrightButton.interactable = true;
        }
        else {
            StarbrightButton.interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 0){
                BuildManager.main.Done();
            }
        }

        if (bluerays >= 50){
            HermittButton.interactable = true;
        }
        else {
            HermittButton.interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 1){
                BuildManager.main.Done();
            }
        }
    }

    public void IncreaseBluerays(int deposit){
        bluerays += deposit;
    }

    public void DecreaseBluerays(int withdrawl){
        bluerays -= withdrawl;
    }

}
