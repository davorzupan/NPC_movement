using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordinates
{
    public GameObject Point;
    public movementType Path;
    public bool currentTarget;
}

public enum movementType
{
    Straight_Line = 1,
    Grid_Horizontal_First = 2,
    Grid_Vertical_First = 3,
}
