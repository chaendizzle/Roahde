using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pathfinder
{
    AStarNode[,] grid;
    int parity;
    public Pathfinder(bool[,] grid, bool parity)
    {
        this.parity = parity ? 0 : 1;
        this.grid = new AStarNode[grid.GetLength(0), grid.GetLength(1)];
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                this.grid[i, j] = new AStarNode() {
                    pos = new Vector2Int(i, j),
                    wall = grid[i, j]
                };
            }
        }
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int end)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j].Reset();
            }
        }
        var openSet = new SimplePriorityQueue<AStarNode>();
        AStarNode startNode = GetNode(start);
        if (startNode == null || GetNode(end) == null)
        {
            return null;
        }
        startNode.g = 0;
        startNode.h = Heuristic(startNode.pos, end);
        openSet.Enqueue(startNode, startNode.f);
        startNode.open = true;
        while (openSet.Count > 0)
        {
            AStarNode current = openSet.Dequeue();
            if (current.pos == end)
            {
                return FindPath(end);
            }
            current.closed = true;

            foreach (AStarNode neighbor in GetNeighbors(current.pos))
            {
                if (neighbor == null || neighbor.closed)
                {
                    continue;
                }
                float tentativeG = current.g + Heuristic(current.pos, neighbor.pos);
                if (!neighbor.open)
                {
                    neighbor.previous = current;
                    neighbor.g = tentativeG;
                    neighbor.h = Heuristic(neighbor.pos, end);
                    openSet.Enqueue(neighbor, neighbor.f);
                    neighbor.open = true;
                }
                else if (tentativeG < neighbor.g)
                {
                    neighbor.previous = current;
                    neighbor.g = tentativeG;
                    openSet.UpdatePriority(neighbor, neighbor.f);
                }
            }
        }
        return null;
    }

    List<Vector2Int> FindPath(Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        AStarNode current = GetNode(end);
        while (current != null)
        {
            path.Add(current.pos);
            current = current.previous;
        }
        path.Reverse();
        return path;
    }

    AStarNode[] GetNeighbors(Vector2Int pos)
    {
        if (pos.y % 2 == parity)
        {
            return new AStarNode[]{
                GetNode(pos + Vector2Int.right),
                GetNode(pos + Vector2Int.down),
                GetNode(pos + Vector2Int.up),
                GetNode(pos + Vector2Int.left + Vector2Int.up),
                GetNode(pos + Vector2Int.left),
                GetNode(pos + Vector2Int.left + Vector2Int.down),
            };
        }
        else
        {
            return new AStarNode[]{
                GetNode(pos + Vector2Int.left),
                GetNode(pos + Vector2Int.down),
                GetNode(pos + Vector2Int.up),
                GetNode(pos + Vector2Int.right + Vector2Int.up),
                GetNode(pos + Vector2Int.right),
                GetNode(pos + Vector2Int.right + Vector2Int.down),
            };
        }
    }

    AStarNode GetNode(Vector2Int pos)
    {
        if (BoundsCheck(pos))
        {
            return grid[pos.x, pos.y].wall ? null : grid[pos.x, pos.y];
        }
        return null;
    }

    bool BoundsCheck(Vector2Int pos)
    {
        return pos.x >= 0 && pos.y >= 0 && pos.x < grid.GetLength(0) && pos.y < grid.GetLength(1);
    }

    float Heuristic(Vector2Int start, Vector2Int end)
    {
        Vector2 startPos = new Vector2(start.y, start.y % 2 == parity ? start.x : start.x + 0.5f);
        Vector2 endPos = new Vector2(end.y, end.y % 2 == parity ? end.x : end.x + 0.5f);
        return Vector2.Distance(startPos, endPos);
    }

    class AStarNode
    {
        public Vector2Int pos;
        public AStarNode previous;
        public bool open = false;
        public bool closed = false;
        public float f => g + h;
        public float g = 10000;
        public float h = 0;
        public bool wall = false;
        public void Reset()
        {
            previous = null;
            open = false;
            closed = false;
            g = 10000;
            h = 0;
        }
    }
}