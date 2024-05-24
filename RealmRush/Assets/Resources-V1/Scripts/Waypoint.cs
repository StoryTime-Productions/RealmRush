using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject pauseMenu;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable && !PauseMenu.gameIsPaused)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
