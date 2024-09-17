using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimation animations;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimation>();
    }
    public PlayerStats Stats => stats;

    public void OnInit()
    {
        stats.OnInit();
        animations.OnInit();
    }
}
