using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    public PlaceBuildingInteraction pb;
    public void LoadMain()
    {
        if (pb.BuildingPlaced != false)
            pb.BuildingPlaced = false;
        // loadingImage.SetActive(true);
        //PlayerPrefs.SetInt("Level", level);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
}
