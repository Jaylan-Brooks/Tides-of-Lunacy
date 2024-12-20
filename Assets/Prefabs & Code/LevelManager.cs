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
    [SerializeField] private Button[] TidepalButtons;

    private float loopTime;
    private int bluerays;
    private bool bossTime;

    private void Awake(){
        main = this;
    }

    void Start(){
        loopTime = 0f;
        bluerays = 150;
        bossTime = false;
    }

    void FixedUpdate(){
        loopTime += Time.deltaTime;
        if (bossTime){
            bluerays = 9999;
        }
        else if (loopTime > 10f){
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
            TidepalButtons[0].interactable = true;
        }
        else {
            TidepalButtons[0].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 0){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 50){
            TidepalButtons[1].interactable = true;
        }
        else {
            TidepalButtons[1].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 1){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 100){
            TidepalButtons[2].interactable = true;
        }
        else {
            TidepalButtons[2].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 2){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 150){
            TidepalButtons[5].interactable = true;
        }
        else {
            TidepalButtons[5].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 5){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 200){
            TidepalButtons[3].interactable = true;
            TidepalButtons[6].interactable = true;
        }
        else {
            TidepalButtons[3].interactable = false;
            TidepalButtons[6].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 3 || BuildManager.main.GetTidepalNumber() == 6){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 250){
            TidepalButtons[4].interactable = true;
        }
        else {
            TidepalButtons[4].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 4){
                BuildManager.main.Done();
            }
        }
        if (bluerays >= 500){
            TidepalButtons[7].interactable = true;
        }
        else {
            TidepalButtons[7].interactable = false;
            if (BuildManager.main.GetTidepalNumber() == 7){
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

    public void MakeBossTime(){
		bossTime = true;
	}

    public bool IsBossTime(){
		return bossTime;
	}

}
