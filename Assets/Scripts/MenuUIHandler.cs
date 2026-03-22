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
     public static Color SelectedColor;
     public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        ColorPicker.CurrentColor = color;
        SelectedColor = color;

        // save the color, so it stays on the computer even after the game is closed
        PlayerPrefs.SetFloat("SavedColorR", color.r);
        PlayerPrefs.SetFloat("SavedColorG", color.g);
        PlayerPrefs.SetFloat("SavedColorB", color.b);
        PlayerPrefs.Save();
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        // load the saved color, if it exists
        if (PlayerPrefs.HasKey("SavedColorR"))
        {
            float r = PlayerPrefs.GetFloat("SavedColorR");
            float g = PlayerPrefs.GetFloat("SavedColorG");
            float b = PlayerPrefs.GetFloat("SavedColorB");
            Color savedColor = new Color(r, g, b);
            ColorPicker.SelectColor(savedColor);
        }
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
