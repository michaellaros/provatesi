using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;
using UnityEngine.Profiling;
using UnityEngine.UI;

namespace BNG {

    /// <summary>
    /// A simple script to display FPS onto a Text label
    /// </summary>
    public class FPSText : MonoBehaviour {
        Text text;
        float deltaTime = 0.0f;
        private long framecount = 0;

        //void Start() {
        //    
        //}

        //void Update() {
        //    deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        //}

        
        void Start()
        {

            text = GetComponent<Text>();
        }

        void Update()
        {
            framecount++;
            CountFps();

        }
        public void CountFps()
        {

            float current = (1f / Time.unscaledDeltaTime);
            text.text = "" + current;
        }
        
    }
}



