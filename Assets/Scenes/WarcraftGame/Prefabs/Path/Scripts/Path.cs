using UnityEngine;

public class Path : MonoBehaviour
{
    public PathSection[] pathSections { get; private set; }

    private void Awake()
    {
        pathSections = new PathSection[transform.childCount];

        int i = 0;
        foreach (PathSection child in GetComponentsInChildren<PathSection>())
        {
            pathSections[i] = child;
            i++;
        }
    }
}
