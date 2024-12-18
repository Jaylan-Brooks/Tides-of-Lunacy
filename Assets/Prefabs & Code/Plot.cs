using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tidepal;
    private Color startColor;

    private bool on;

    private void Start(){
        startColor = sr.color;
    }

    private void OnMouseEnter(){
        if (on){
            sr.color = hoverColor;
        }
    }

    private void OnMouseExit(){
        sr.color = startColor;
    }

    private void OnMouseDown(){
        if (on){
            if (tidepal != null) return;

            GameObject tidepalToSummon = BuildManager.main.GetTidepal();
            tidepal = Instantiate(tidepalToSummon, transform.position, Quaternion.identity);
            Charge();
        }
    }

    private void Charge(){
        if (BuildManager.main.GetTidepalNumber() == 0){
            LevelManager.main.DecreaseBluerays(25);
        }
        if (BuildManager.main.GetTidepalNumber() == 1){
            LevelManager.main.DecreaseBluerays(50);
        }
    }

    public void SetOn(bool onOrOff){
        on = onOrOff;
    }
}
