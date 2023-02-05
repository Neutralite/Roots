using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RootType
{
    solid, ghost, empty
}
public class GroundNode : Node
{
    public GroundNode source;

    public RootType rootType = RootType.empty;

    [SerializeField]
    bool permanentRoot, selected;

    void Update()
    {
        if (Input.GetMouseButtonUp(1) && selected)
        {
            UnSelectRoot();
        }
    }


    public void SelectNode()
    {

        if (rootType == RootType.solid)
        {
            Board.instance.selectedNode.UnSelectRoot();
            Board.instance.selectedNode = this;
            foreach (GroundNode item in nearNodes)
            {
                if (item.rootType == RootType.empty)
                {
                    item.rootType = RootType.ghost;
                    item.nodeVisual.SetActive(true);
                    item.source = this;
                }
            }
        }
        else if (rootType == RootType.ghost)
        {
            GrowRoot();
            GrowConnectingRoot();
            source.UnSelectRoot();
        }
    }

    public void GrowRoot()
    {
        rootType = RootType.solid;
        nodeVisual.GetComponent<MeshRenderer>().material = Board.instance.rootMat;
        Board.instance.availableNodes--;
        Board.instance.usedNodes++;
    }

    private void GrowConnectingRoot()
    {
        Vector3 temp = transform.position + new Vector3(0, -1) + ((source.transform.position - transform.position) / 2);
        Instantiate(Board.instance.connectingRoot, temp, Quaternion.identity, transform);
    }

    public void UnSelectRoot()
    {
        foreach (GroundNode item in nearNodes)
        {
            if (item.rootType == RootType.ghost)
            {
                item.rootType = RootType.empty;
                item.nodeVisual.SetActive(false);
            }
        }
    }
    public void DeleteRoot()
    {
        if (!permanentRoot)
        {
            Debug.Log("roo");
        }
    }

    public void Remove()
    {
        if (!permanentRoot)
        {
            Debug.Log("roo");
        }
    }
}
