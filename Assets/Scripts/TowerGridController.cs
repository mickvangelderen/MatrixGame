using UnityEngine;
using System.Collections.Generic;

public class TowerGridController : MonoBehaviour
{

    public GameObject tower;
    public float margin;
    public int[,] heights;

    private TowerController[,] towers;

    // Update is called once per frame
    void Update()
    {
        if (DimensionsChanged()) RecreateTowers();
        if (towers != null && heights != null) UpdateTowers();
    }
    
    bool DimensionsChanged()
    {
        if (heights == null && towers == null) return false;
        if (heights == null && towers != null) return true;
        if (heights != null && towers == null) return true;
        if (heights.Rank != towers.Rank) return true;
        for (int dim = 0; dim < heights.Rank; dim++)
        {
            if (heights.GetLength(dim) != towers.GetLength(dim)) return true;
        }
        return false;
    }

    void RecreateTowers()
    {
        if (towers != null)
        {
            foreach (TowerController t in towers) GameObject.Destroy(t);
            towers = null;
        }
        if (heights == null) return;
        int nrows = heights.GetLength(0);
        int ncols = heights.GetLength(1);
        towers = new TowerController[nrows, ncols];
        for (int row = 0; row < nrows; row++)
        {
            for (int col = 0; col < ncols; col++)
            {
                Vector3 position = transform.position + new Vector3((col - (ncols - 1)/2f)*margin, 0, -(row - (nrows - 1)/2f)*margin);
                GameObject t = (GameObject) Instantiate(tower, position, Quaternion.identity);
                t.transform.SetParent(transform);
                TowerController c = t.GetComponent<TowerController>();
                if (c != null) c.height = heights[row, col];
                towers[row, col] = c;
            }
        }
    }

    void UpdateTowers()
    {
        for (int row = 0; row < towers.GetLength(0); row++)
        {
            for (int col = 0; col < towers.GetLength(1); col++)
            {
                Debug.Log(towers[row, col]);
                towers[row, col].height = heights[row, col];
            }
        }
    }
}
