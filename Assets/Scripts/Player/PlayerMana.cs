using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{

    [Header("Config")]
    [SerializeField] private PlayerStats stats;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ConsumeMana(1f);
        }
    }

    public void ConsumeMana(float amount)
    {
        stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);


    }
}
