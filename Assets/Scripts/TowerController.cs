using UnityEngine;
using System.Collections.Generic;

public class TowerController : MonoBehaviour {

    public GameObject block;
    public Vector3 offset = new Vector3(0, 1, 0);
    public int height = 0;

	// Use this for initialization
	void Start () {
        CreateBlocks();
    }

    // Update is called once per frame
    void Update () {
	    if (transform.childCount != height)
        {
            DestroyBlocks();
            CreateBlocks();
        }
    }

    void CreateBlocks()
    {
        Vector3 position = transform.position;
        for (int i = 0; i < height; i++)
        {
            GameObject b = (GameObject)Instantiate(block, position, Quaternion.identity);
            b.transform.SetParent(transform);
            position += offset;
        }
    }

    void DestroyBlocks()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

}
