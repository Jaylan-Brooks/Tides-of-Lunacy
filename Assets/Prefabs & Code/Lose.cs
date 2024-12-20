using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private void Lost (){
        SceneManager.LoadScene("Lose Screen");
    }
}
