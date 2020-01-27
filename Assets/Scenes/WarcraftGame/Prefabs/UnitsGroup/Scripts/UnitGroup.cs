using UnityEngine;
using UnityEditor;
using System.Collections;

public class UnitGroup : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    private HealthBar healthBar;
    private Unit[] units;
    private int unitsNumber;
    public int unitsHP;
    private int unitsDamage;

    private void OnEnable()
    {
        healthBarPrefab = Resources.Load("CanvasWorldspaceHealthBar") as GameObject;

        units = GetComponentsInChildren<Unit>();
        unitsNumber = units.Length;
        foreach (Unit unit in units)
        {
            unitsHP += unit.hp;
            unitsDamage += unit.damage;

        }
    }

    public void SetupHealthBar()
    {
        var offset = new Vector3();
        if (GetComponent<UnitsGroupFightDetector>().GetSide() == BaseInfo.BaseSide.player)
            offset = new Vector3(0f, -2f);
        else offset = new Vector3(0f, 2f);
        
        var healthBarGameObject = Instantiate(healthBarPrefab, transform.position + offset, Quaternion.identity, transform);
        healthBar = healthBarGameObject.GetComponent<HealthBar>();
        healthBar.SetOneUnitHealth(units[0].hp);
        healthBar.SetHealth(unitsHP);
    }

    public void SetDamage(int damage)
    {
        unitsHP -= damage;
        healthBar.SetDamage(damage);
    }

    public void StartAttack(UnitGroup target)
    {
        SetupHealthBar();
        StartCoroutine(Attack(target));
    }

    private IEnumerator Attack(UnitGroup target)
    {
        yield return null;

        while (target.unitsHP > 0)
        {
            target.SetDamage(unitsDamage);
            yield return new WaitForSeconds(1f);
        }
    }
}