using UnityEngine;
using UnityEngine.Assertions;

public class PuzzleController : MonoBehaviour {

    public TowerGridController preGrid;
    public TowerGridController inputGrid;
    public TowerGridController postGrid;
    public TowerGridController outputGrid;

    public Vector2 playerLocation = new Vector2(0, 0);

    void Start()
    {
        preGrid.heights = new int[,]{
            { 2, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };

        inputGrid.heights = new int[,]{
            { 2, 1, 0 },
            { 0, 1, 4 },
            { 3, 0, 1 }
        };

        postGrid.heights = new int[,]{
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };
    }

    // Update is called once per frame
    void Update()
    {
        outputGrid.heights = MultiplyMatrix(MultiplyMatrix(preGrid.heights, inputGrid.heights), postGrid.heights);
    }

    int[,] MultiplyMatrix(int[,] a, int[,] b)
    {
        if (a == null || b == null) return null;
        int ar = a.GetLength(0);
        int ac = a.GetLength(1);
        int br = b.GetLength(0);
        int bc = b.GetLength(1);
        Assert.AreEqual(ac, br);
        int[,] o = new int[ar, bc];
        for (int row = 0; row < ar; row++)
        {
            for (int col = 0; col < bc; col++)
            {
                int sum = 0;
                for (int i = 0; i < ac; i++)
                {
                    sum += a[row, i] * b[i, col];
                }
                o[row, col] = sum;
            }
        }
        return o;
    }
}