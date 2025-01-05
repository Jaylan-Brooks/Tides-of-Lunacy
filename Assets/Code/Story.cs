using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject startButton;

    [Header ("Attributes")]
    [SerializeField] private Sprite[] storyFrames;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        index = 0;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
           Next(); 
        }
    }

    public void Next(){
        index++;
        if (index >= storyFrames.Length-1){
            index = storyFrames.Length-1;
            sr.sprite = storyFrames[index];
            skipButton.SetActive(false);
            nextButton.SetActive(false);
            startButton.SetActive(true);
        }
        else {
            sr.sprite = storyFrames[index];
        }
    }
}
