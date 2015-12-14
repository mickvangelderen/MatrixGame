using UnityEngine;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

    public TowerGridController towerGrid;

    void Start ()
    {
        towerGrid.heights = new int[,]{
            { 1, 2 },
            { 4, 2 }
        };
    }
    // Update is called once per frame
    void Update () {
        if (towerGrid != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                for (int row = 0; row < towerGrid.heights.GetLength(0); row++)
                {
                    for (int col = 0; col < towerGrid.heights.GetLength(1); col++)
                    {
                        towerGrid.heights[row, col]++;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                for (int row = 0; row < towerGrid.heights.GetLength(0); row++)
                {
                    for (int col = 0; col < towerGrid.heights.GetLength(1); col++)
                    {
                        towerGrid.heights[row, col]--;
                    }
                }
            }
        }
    }
    
}
