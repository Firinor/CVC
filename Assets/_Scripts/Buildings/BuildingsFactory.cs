using FirUnityEditor;
using UnityEngine;
using Zenject;

public class BuildingsFactory : MonoBehaviour, IFactory<BuildingParams, Building>
{
    [Inject]
    private GameManager gameManager;
    [Inject]
    private DiContainer container;
    [SerializeField, NullCheck]
    private Grid grid;

    public Building Create(BuildingParams param)
    {
        GameObject newBuilding = container.InstantiatePrefab(
            param.Building,
            grid.CellToWorld(param.Position),
            Quaternion.identity,
            grid.transform);

        return newBuilding.GetComponent<Building>();
    }

    public void BulidDefault()
    {
        foreach (BuildingPosition buildingPosition in gameManager.DefaultBuildings)
        {
            var pos = new Vector3Int(buildingPosition.X, buildingPosition.Y);
            var param = new BuildingParams() { Building = buildingPosition.Building, Position = pos };
            Create(param);
        }
    }

}
public class BuildingParams
{
    public Vector3Int Position;
    public GameObject Building;
}
