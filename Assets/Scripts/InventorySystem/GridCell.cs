using UnityEngine;

public class GridCell : MonoBehaviour
{
    [field: SerializeField] public bool IsOccupied { get; private set; }

    public void SetOccupied(bool occupied)
    {
        IsOccupied = occupied;
    }

    [field: SerializeField] public GridCell TopNeighbor { get; private set; }
    [field: SerializeField] public GridCell BottomNeighbor { get; private set; }
    [field: SerializeField] public GridCell LeftNeighbor { get; private set; }
    [field: SerializeField] public GridCell RightNeighbor { get; private set; }

    public void SetNeighbors(GridCell top, GridCell bottom, GridCell left, GridCell right)
    {
        TopNeighbor = top;
        BottomNeighbor = bottom;
        LeftNeighbor = left;
        RightNeighbor = right;
    }
}
