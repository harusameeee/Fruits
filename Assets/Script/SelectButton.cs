using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public static int SelectedDifficulty { get; private set; }
    public void SelectDifficulty(int difficulty)
    {
        SelectedDifficulty = difficulty;
        PlayOnlyData.DataSetting(difficulty);
    }
}
