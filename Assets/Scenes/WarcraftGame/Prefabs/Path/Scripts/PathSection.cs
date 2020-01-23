using UnityEngine;

public class PathSection : MonoBehaviour
{
    private Vector2[] waypoints;
    private Vector2 gizmosPosition;

    private void OnDrawGizmos()
    {
        waypoints = GetWaypoints();

        for (float t = 0; t <= 1; t+=0.05f)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                int k = waypoints.Length - 1;
                int j = k - i;

                float binomialСoefficient = PathMath.BinomialСoefficient(k, i);

                gizmosPosition += binomialСoefficient *
                    Mathf.Pow(1 - t, j) * Mathf.Pow(t, i) * (Vector2)waypoints[i];
            }

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
            gizmosPosition = Vector2.zero;
        }
    }

    public Vector2[] GetWaypoints()
    {
        Vector2[] calculatedWaypoints = new Vector2[transform.childCount];
        int i = 0;

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child != transform)
            {
                calculatedWaypoints[i] = child.position;
                i++;
            }
        }

        return calculatedWaypoints;
    }
}
