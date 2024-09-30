using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static event Action<EnemyBrain> OnEnemySelectedEvent;
    public static event Action OnNullSelectedEvent;

    [Header("Config")]
    [SerializeField] private LayerMask enemeyMask;

    private Camera mainCam;
    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        SelectEnemy();
    }
    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit =
                Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero, Mathf.Infinity, enemeyMask);
                
            if(hit.collider != null)
            {
                EnemyBrain enemy = hit.collider.GetComponent<EnemyBrain>();
                if(enemy != null)
                {
                    OnEnemySelectedEvent?.Invoke(enemy);
                }
            }
            else
            {
                OnNullSelectedEvent?.Invoke();
            }
        }
        
    }
}
