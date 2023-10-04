using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartBuildingState", menuName = "GameBalance/StartBuildingState")]
public class SOStartBuilding : ScriptableObject
{
    public List<BuildingPosition> buildings;
}
