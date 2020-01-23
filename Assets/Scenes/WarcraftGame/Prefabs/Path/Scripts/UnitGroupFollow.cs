using System.Collections;
using UnityEngine;

public class UnitGroupFollow : MonoBehaviour
{
    [SerializeField] private float speedModifier = 0.5f;

    private PathSection[] pathSections;

    private int sectionToGo = 0;

    private bool coroutineAllowed;

    public enum UnitGroupSide
    {
        player,
        enemy,
    }

    [SerializeField] private UnitGroupSide unitGroupSide = UnitGroupSide.player;

    private void Start()
    {
        pathSections = PathChooser.GetPath().pathSections;
        if (unitGroupSide == UnitGroupSide.player) sectionToGo = 0;
        if (unitGroupSide == UnitGroupSide.enemy) sectionToGo = pathSections.Length - 1;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (coroutineAllowed)
        {
            if (unitGroupSide == UnitGroupSide.player) StartCoroutine(GoByTheSection(sectionToGo));
            if (unitGroupSide == UnitGroupSide.enemy) StartCoroutine(GoByTheSectionBackwards(sectionToGo));
        }
    }

    private IEnumerator GoByTheSection(int sectionNumber)
    {
        coroutineAllowed = false;

        float tParam = 0f;

        Vector2[] sectionPositions = pathSections[sectionNumber].GetWaypoints();

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            Vector2 unitPosition = Vector2.zero;
            int i = 0;
            foreach (Vector2 position in sectionPositions)
            {
                int k = sectionPositions.Length - 1;
                int j = k - i;

                float binomialСoefficient = PathMath.BinomialСoefficient(k, i);

                unitPosition += binomialСoefficient * Mathf.Pow(1 - tParam, j) * Mathf.Pow(tParam, i) * position;
                i++;
            }

            transform.position = unitPosition;
            yield return new WaitForEndOfFrame();
        }

        sectionToGo++;

        if (sectionToGo > pathSections.Length - 1)
        {
            // this mean that unit group reaches base and must hit
            this.enabled = false;
        }
        coroutineAllowed = true;
    }

    private IEnumerator GoByTheSectionBackwards(int sectionNumber)
    {
        coroutineAllowed = false;

        float tParam = 1f;

        Vector2[] sectionPositions = pathSections[sectionNumber].GetWaypoints();

        while (tParam > 0)
        {
            tParam -= Time.deltaTime * speedModifier;
            Vector2 unitPosition = Vector2.zero;
            int i = 0;
            foreach (Vector2 position in sectionPositions)
            {
                int k = sectionPositions.Length - 1;
                int j = k - i;

                float binomialСoefficient = PathMath.BinomialСoefficient(k, i);

                unitPosition += binomialСoefficient * Mathf.Pow(1 - tParam, j) * Mathf.Pow(tParam, i) * position;
                i++;
            }

            transform.position = unitPosition;
            yield return new WaitForEndOfFrame();
        }

        sectionToGo--;

        if (sectionToGo < 0)
        {
            // this mean that unit group reaches base and must hit
            this.enabled = false;
        }
        coroutineAllowed = true;
    }
}
