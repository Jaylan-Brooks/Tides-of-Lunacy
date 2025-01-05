using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Beastiary : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI attributesText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [Header ("Attributes")]
    [SerializeField] private BeastiaryEntry[] entries;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.RightArrow)){
           Next();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
           Back(); 
        }
    }

    public void Next(){
        index++;
        if (index > entries.Length-1){
            index = 0;
            entries[entries.Length-1].creature.SetActive(false);
        }
        else{
            entries[index-1].creature.SetActive(false);    
        }
        nameText.text = entries[index].name;
        attributesText.text = entries[index].attributes;
        descriptionText.text = entries[index].description;
        entries[index].creature.SetActive(true);
    }

    public void Back(){
        index--;
        if (index < 0){
            index = entries.Length-1;
            entries[0].creature.SetActive(false);
        }
        else{
            entries[index+1].creature.SetActive(false);    
        }
        nameText.text = entries[index].name;
        attributesText.text = entries[index].attributes;
        descriptionText.text = entries[index].description;
        entries[index].creature.SetActive(true);
    }
}
