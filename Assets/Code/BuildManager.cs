using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header ("References")]
    [SerializeField] private GameObject[] buildingPrefabs;
    [SerializeField] private GameObject plots;

    private int selectedTidepal = 0;

    private void Awake(){
        main = this;
    }

    public GameObject GetTidepal(){
        return buildingPrefabs[selectedTidepal];
    }

    public int GetTidepalNumber(){
        return selectedTidepal;
    }

    public void Done(){
        PlotsOff();
        SkyPlotsOff();
    }

    public void Starbright(){
        selectedTidepal = 0;
        PlotsOn();
        SkyPlotsOff();
    }

    public void Hermitt(){
        selectedTidepal = 1;
        PlotsOn();
        SkyPlotsOff();
    }

    public void Quickclaw(){
        selectedTidepal = 2;
        PlotsOn();
        SkyPlotsOff();
    }

    public void Mussels(){
        selectedTidepal = 3;
        PlotsOn();
        SkyPlotsOff();
    }

    public void CorralReef(){
        selectedTidepal = 4;
        PlotsOn();
        SkyPlotsOff();
    }

    public void LunarJelly(){
        selectedTidepal = 5;
        SkyPlotsOn();
        PlotsOff();
    }

    public void Copterpus(){
        selectedTidepal = 6;
        SkyPlotsOn();
        PlotsOff();
    }

    public void Shellshock(){
        selectedTidepal = 7;
        PlotsOn();
        SkyPlotsOff();
    }

    public void PlotsOn(){
        for (int i = 0; i < plots.transform.childCount; i++){
            GameObject plot = plots.transform.GetChild(i).gameObject;
            if (plot.tag == "Sand"){
                plot.GetComponent<Plot>().SetOn(true);
            }
        }
    }

    public void PlotsOff(){
        for (int i = 0; i < plots.transform.childCount; i++){
            GameObject plot = plots.transform.GetChild(i).gameObject;
            if (plot.tag == "Sand"){
                plot.GetComponent<Plot>().SetOn(false);
            }
        }
    }

    public void SkyPlotsOn(){
        for (int i = 0; i < plots.transform.childCount; i++){
            GameObject plot = plots.transform.GetChild(i).gameObject;
            if (plot.tag == "Sky"){
                plot.GetComponent<Plot>().SetOn(true);
            }
        }
    }

    public void SkyPlotsOff(){
        for (int i = 0; i < plots.transform.childCount; i++){
            GameObject plot = plots.transform.GetChild(i).gameObject;
            if (plot.tag == "Sky"){
                plot.GetComponent<Plot>().SetOn(false);
            }
        }
    }
}
