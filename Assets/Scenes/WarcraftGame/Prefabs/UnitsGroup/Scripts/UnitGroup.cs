using UnityEngine;
using UnityEditor;
using System.Collections;

public class UnitGroup : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBarGameObject;
    private HealthBar healthBar;
    public Unit[] units;
    private int unitsNumber;
    public int unitsHP;
    private int oneUnitHp = 5;
    private int unitsDamage;

    private void OnEnable()
    {
        healthBarPrefab = Resources.Load("CanvasWorldspaceHealthBar") as GameObject;
        units = GetComponentsInChildren<Unit>();
        unitsNumber = units.Length;
        print("units number is " + unitsNumber);
        
    }

    public void SetupHealthBar()
    {
        var offset = new Vector3();
        if (GetComponent<UnitsGroupFightDetector>().GetSide() == BaseInfo.BaseSide.player)
            offset = new Vector3(0f, -2f);
        else offset = new Vector3(0f, 2f);
        
        healthBarGameObject = Instantiate(healthBarPrefab, transform.position + offset, Quaternion.identity, transform);
        healthBar = healthBarGameObject.GetComponent<HealthBar>();
        healthBar.SetOneUnitHealth(units[0].hp);
        healthBar.SetHealth(unitsHP);
    }

    public void SetDamage(int damage)
    {
        unitsHP -= damage;
        healthBar.SetDamage(damage);
        CheckForUnitKill();
    }

    private void CheckForUnitKill()
    {
        if (unitsHP <= (unitsNumber - 1) * oneUnitHp)
        {
            print(unitsNumber - 1);
            Destroy(units[unitsNumber - 1].gameObject);
            unitsNumber--;
            GetComponentInParent<UnitSpawner>().DestroyUnit();
            if (unitsNumber <= 0)
            {
                Destroy(gameObject);
                return;
            }
            CheckForUnitKill();
        }
    }

    public void StartAttack(UnitGroup target)
    {
        SetupUnitGroupHpAndDamage();
        SetupHealthBar();
        StartCoroutine(Attack(target));
    }

    public void SetupUnitGroupHpAndDamage()
    {
        units = GetComponentsInChildren<Unit>();
        unitsHP = 0;
        unitsDamage = 0;
        foreach (Unit unit in units)
        {
            unitsHP += unit.hp;
            unitsDamage += unit.damage;
        }
    }

    private IEnumerator Attack(UnitGroup target)
    {
        yield return new WaitForSeconds(Random.Range(0.1f,0.5f));

        while (target != null)
        {
            yield return new WaitForSeconds(1f);
            target.SetDamage(unitsDamage);
            yield return null;
        }
        Destroy(healthBarGameObject);
        GetComponent<UnitsGroupFightDetector>().SetAsFighting(false);
        foreach (Unit unit in units)
        {
            if (unit != null)
                unit.transform.localPosition = new Vector2(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        }
    }

    //DEBUG
    public void MinusHp(int value)
    {
        unitsHP -= value;
        CheckForUnitKill();
    }
}