using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : NodeGrid
{
    public static Board instance;

    public Material ghostMat,rootMat;

    public GameObject tree, connectingRoot;

    public GroundNode selectedNode;

    public int availableNodes, usedNodes;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InitializeGrid();
        Camera.main.gameObject.transform.position = new(boardSize.x - 1, 10, boardSize.y - 1);
        PlaceTree();
    }

    private void PlaceTree()
    {
        tree.SetActive(true);
        tree.transform.position = new(boardSize.x - 1, 0, boardSize.y - 1);

        selectedNode = board[(int)boardSize.x / 2][(int)boardSize.y / 2].GetComponent<GroundNode>();
        availableNodes++;
        usedNodes--;
        selectedNode.GrowRoot();
        selectedNode.nodeVisual.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
