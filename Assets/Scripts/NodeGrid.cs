using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    [SerializeField]
    Vector2 minimumBoardSize;
    [SerializeField]
    protected Vector2 boardSize;
 
    public List<List<Node>> board = new();

    public List<Node> edgeNodes = new();

    [SerializeField]
    Node nodePrefab;

    protected void InitializeGrid()
    {
        InputChanges();
        SpawnNodes();
        LinkNodes();
        GetEdges();
    }
    void InputChanges()
    {
        // enforce minimum board size
        boardSize.x = boardSize.x < minimumBoardSize.x ? minimumBoardSize.x : boardSize.x;
        boardSize.y = boardSize.y < minimumBoardSize.y ? minimumBoardSize.y : boardSize.y;

        // enforce odd board dimensions
        boardSize.x += boardSize.x % 2 == 0 ? 1 : 0;
        boardSize.y += boardSize.y % 2 == 0 ? 1 : 0;
    }

    private void SpawnNodes()
    {
        for (int i = 0; i < boardSize.x; i++)
        {
            board.Add(new List<Node>());
            for (int j = 0; j < boardSize.y; j++)
            {
                Node temp = Instantiate(nodePrefab, transform);
                board[i].Add(temp);
                temp.gameObject.name = $"x:{i},y:{j}";
                temp.spaceID = new(i, j);
                temp.transform.position = new(i * 2, 0, j * 2);
            }
        }
    }

    void LinkNodes()
    {
        for (int i = 0; i < boardSize.x; i++)
        {
            for (int j = 0; j < boardSize.y; j++)
            {
                Node temp = board[i][j];
                if (j != boardSize.y-1)
                {
                    temp.n_Node = board[i][j + 1];
                    temp.nearNodes.Add(temp.n_Node);
                }
                if (i != boardSize.x - 1 && j != boardSize.y - 1)
                {
                    temp.ne_Node = board[i+1][j + 1];
                    temp.nearNodes.Add(temp.ne_Node);
                }
                if (i != boardSize.x - 1)
                {
                    temp.e_Node = board[i + 1][j];
                    temp.nearNodes.Add(temp.e_Node);
                }
                if (i != boardSize.x - 1 && j != 0)
                {
                    temp.se_Node = board[i + 1][j-1];
                    temp.nearNodes.Add(temp.se_Node);
                }
                if (j != 0)
                {
                    temp.s_Node = board[i][j - 1];
                    temp.nearNodes.Add(temp.s_Node);
                }
                if (i!=0 && j != 0)
                {
                    temp.sw_Node = board[i-1][j - 1];
                    temp.nearNodes.Add(temp.sw_Node);
                }
                if (i != 0)
                {
                    temp.w_Node = board[i - 1][j];
                    temp.nearNodes.Add(temp.w_Node);
                }
                if (i != 0 && j != boardSize.y - 1)
                {
                    temp.nw_Node = board[i - 1][j+1];
                    temp.nearNodes.Add(temp.nw_Node);
                }
            }
        }
    }

    void GetEdges()
    {
        for (int i = 0; i < boardSize.x; i++)
        {
            for (int j = 0; j < boardSize.y; j++)
            {
                if (board[i][j].nearNodes.Count != 8)
                    edgeNodes.Add(board[i][j]);
            }
        }
    }
}
