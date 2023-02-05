//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PoolManager : MonoBehaviour
//{
//    [SerializeField]
//    GhostNode ghostPrefab;

//    [SerializeField]
//    GroundNode rootPrefab;

//    [SerializeField]
//    Enemy enemyPrefab;

//    [SerializeField]
//    List<GhostNode> ghostPool;

//    [SerializeField]
//    List<GroundNode> rootPool;

//    [SerializeField]
//    List<Enemy> enemyPool;

//    public void spawnItem(ItemType itemType, Vector3 position)
//    {
//        switch (itemType)
//        {
//            // ghost node
//            case ItemType.ghost:
//                if (ghostPool.Count == 0)
//                {
//                    createItem(itemType);
//                }
//                ghostPool[0].transform.position = position;
//                ghostPool[0].gameObject.SetActive(true);
//                ghostPool.Remove(ghostPool[0]);
//                break;
//            // root node
//            case ItemType.root:
//                if (rootPool.Count == 0)
//                {
//                    createItem(itemType);
//                }
//                rootPool[0].transform.position = position;
//                rootPool[0].gameObject.SetActive(true);
//                rootPool.Remove(rootPool[0]);
//                break;
//            // enemy
//            case ItemType.enemy:
//                if (enemyPool.Count == 0)
//                {
//                    createItem(itemType);
//                }
//                enemyPool[0].transform.position = position;
//                enemyPool[0].gameObject.SetActive(true);
//                enemyPool.Remove(enemyPool[0]);
//                break;
//        }
//    }

//    public void createItem(ItemType itemType)
//    {
//        switch (itemType)
//        {
//            // ghost node
//            case ItemType.ghost:
//                despawnItem(Instantiate(ghostPrefab, transform).gameObject,itemType);

//                break;
//            // root node
//            case ItemType.root:
//                despawnItem(Instantiate(rootPrefab, transform).gameObject, itemType);
//                break;
//            // enemy
//            case ItemType.enemy:
//                despawnItem(Instantiate(enemyPrefab, transform).gameObject, itemType);
//                break;
//        }
//    }

//    public void despawnItem(GameObject item, ItemType itemType)
//    {
//        item.SetActive(false);
//        switch (itemType)
//        {
//            // ghost node
//            case ItemType.ghost:
//                ghostPool.Add(item.GetComponent<GhostNode>());
//                break;
//            // root node
//            case ItemType.root:
//                rootPool.Add(item.GetComponent<GroundNode>());
//                break;
//            // enemy
//            case ItemType.enemy:
//                enemyPool.Add(item.GetComponent<Enemy>());
//                break;
//        }
//    }

//}
