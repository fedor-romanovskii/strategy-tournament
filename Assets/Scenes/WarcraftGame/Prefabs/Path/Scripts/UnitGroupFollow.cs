using System.Collections;
using UnityEngine;

public class UnitGroupFollow : MonoBehaviour
{
    [SerializeField] private float speedModifier = 0.5f;

    private PathSection[] pathSections;

    private int sectionToGo = 0;

    public bool isFighting;
    private bool coroutineAllowed;

    private BaseInfo.BaseSide unitGroupSide = BaseInfo.BaseSide.player;

    public void SetUnitGroupSide(BaseInfo.BaseSide _unitGroupSide) => unitGroupSide = _unitGroupSide;

    private void Start()
    {
        pathSections = PathChooser.GetPath(unitGroupSide).pathSections;
        if (unitGroupSide == BaseInfo.BaseSide.player) sectionToGo = 0;
        if (unitGroupSide == BaseInfo.BaseSide.enemy) sectionToGo = pathSections.Length - 1;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (coroutineAllowed)
        {
            if (unitGroupSide == BaseInfo.BaseSide.player) StartCoroutine(GoByTheSection(sectionToGo));
            if (unitGroupSide == BaseInfo.BaseSide.enemy) StartCoroutine(GoByTheSectionBackwards(sectionToGo));
        }
    }

    private IEnumerator GoByTheSection(int sectionNumber)
    {
        coroutineAllowed = false;

        float tParam = 0f;

        Vector2[] sectionPositions = pathSections[sectionNumber].GetWaypoints();

        while (tParam < 1)
        {
            if (!isFighting)
            {
                tParam += Time.deltaTime * speedModifier;
                Vector2 unitPosition = Vector2.zero;
                int i = 0;
                foreach (Vector2 position in sectionPositions)
                {
                    int k = sectionPositions.Length - 1;
                    int j = k - i;

                    float binomialСoefficient = PathMath.BinomialСoefficient(k, i);

                    unitPosition += binomialСoefficient * Mathf.Pow(1 - tParam, j)
                        * Mathf.Pow(tParam, i) * position;
                    i++;
                }

                transform.position = unitPosition;

            }
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
            if (!isFighting)
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
            }
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
