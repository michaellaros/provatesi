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
}
