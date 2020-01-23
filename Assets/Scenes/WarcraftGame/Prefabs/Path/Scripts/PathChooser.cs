using UnityEngine;

public class PathChooser : MonoBehaviour
{
    private static Path[] pathWays;

    private void OnEnable()
    {
        pathWays = FindObjectsOfType<Path>();
    }

    public static Path GetPath()
    {
        var pathNumber = Random.Range(0, pathWays.Length);
        return pathWays[pathNumber];
    }
}
