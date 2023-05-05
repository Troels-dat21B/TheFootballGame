using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
   public TMP_Text LevelTextUI;
    void Start()
    {
        Debug.Log("LevelText: " + SceneManager.GetActiveScene().name);
        LevelTextUI.text = "Level: " + SceneManager.GetActiveScene().name;
    }


}
