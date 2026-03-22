using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; 

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
     public ColorPicker ColorPicker;
     public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void ExitGame()
    {
        // this will quit the application when the exit button is clicked
        Application.Quit();

        // this line stops the play mode in the editor when the exit button is clicked
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }
   

}
