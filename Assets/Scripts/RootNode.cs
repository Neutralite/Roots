using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : MonoBehaviour
{
    ItemType itemType = ItemType.root;

    [SerializeField]
    bool permanentRoot, selected;


    void Update()
    {
        if (Input.GetMouseButtonUp(1) && selected)
        {
            UnSelectRoot();
        }
    }


    public void SelectRoot()
    {
        selected = true;
        for (int i = 0; i < 8; i++)
        {
            GameManager.instance.poolManager.spawnItem(ItemType.ghost, transform.position);
        }
    }

    public void UnSelectRoot()
    {
        if (selected)
        {
            selected = false;
            Debug.Log("doo");
        }
        else
        {
            Remove();
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
