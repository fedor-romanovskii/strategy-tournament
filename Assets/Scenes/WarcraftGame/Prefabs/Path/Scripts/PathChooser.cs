using System.Collections.Generic;
using UnityEngine;

public class PathChooser : MonoBehaviour
{
    private static Path[] pathWays;

    private void OnEnable()
    {
        pathWays = FindObjectsOfType<Path>();
    }

    public static Path GetPath(BaseInfo.BaseSide sideOfGoingUnitsGroup)
    {
        var availablePathways = new List<Path>();

        foreach (Path path in pathWays)
        {
            bool thisPathNotOurSide = path.pathSide != sideOfGoingUnitsGroup;
            // Path will be balanced if path already has player and enemy units group on.
            bool thisPathNotEmptyOrBalanced = path.pathSide != BaseInfo.BaseSide.neutral;
            bool thisIsEnemyPath = thisPathNotOurSide && thisPathNotEmptyOrBalanced;

            if (thisIsEnemyPath)
            {
                path.pathSide = BaseInfo.BaseSide.neutral;
                return path;
            }
            if (thisPathNotOurSide) availablePathways.Add(path);
        }

        var pathNumber = Random.Range(0, availablePathways.Count);

        availablePathways[pathNumber].pathSide = sideOfGoingUnitsGroup;

        return availablePathways[pathNumber];
    }
}
