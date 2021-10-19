using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents singleton;
    void Awake()
    {
        singleton = this;
    }

    public event Action<int> onGemCollected;
    public void GemCollected(int gemType) {
        if (onGemCollected != null) {
            onGemCollected(gemType);
        }
    }
    public event Action triggerHealPlayer;
    public void HealPlayer() {
        if (triggerHealPlayer != null) {
            triggerHealPlayer();
        }
    }

    public event Action triggerSpawnTower;
    public void SpawnTower()
    {
        if (triggerSpawnTower != null)
        {
            triggerSpawnTower();
        }
    }
    public event Action <float> triggerIceBoost;
    public void IceBoost(float seconds)
    {
        if (triggerIceBoost != null)
        {
            triggerIceBoost(seconds);
        }
    }

    public event Action<float> triggerFireBoost;
    public void FireBoost(float seconds)
    {
        if (triggerFireBoost != null)
        {
            triggerFireBoost(seconds);
        }
    }

    public event Action<float> triggerThunderBoost;
    public void ThunderBoost(float seconds)
    {
        if (triggerThunderBoost != null)
        {
            triggerThunderBoost(seconds);
        }
    }
}
