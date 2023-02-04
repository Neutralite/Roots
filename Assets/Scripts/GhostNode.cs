using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNode : MonoBehaviour
{
    ItemType itemType = ItemType.ghost;
    public void GrowRoot()
    {
        GameManager.instance.poolManager.spawnItem(itemType, transform.position);
        GameManager.instance.poolManager.despawnItem(gameObject, itemType);
    }
}
