using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;

    [Header("Config")]
    [SerializeField] private DamageText dmgTextPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamageText dmgText = Instantiate(dmgTextPrefab, parent);
        dmgText.transform.position += Vector3.up * 0.1f;
        dmgText.SetDamageText(damageAmount);
    }

}
