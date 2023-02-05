using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject nodeVisual;

    public Vector2 spaceID;

    public Node n_Node, ne_Node, e_Node, se_Node, s_Node, sw_Node, w_Node, nw_Node;

    public List<Node> nearNodes;
}