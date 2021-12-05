using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementParticle : MonoBehaviour
{
    private ParticleSystem.MainModule flameMain;
    private ParticleSystem.MainModule glowMain;
    private ParticleSystem.MainModule sparkMain;
    public ParticleSystem flame;
    public ParticleSystem glow;
    public ParticleSystem spark;
    private CheckElement elementCheck;
    
    
    private bool none;
    private bool fire;
    private bool ice;
    private bool thunder;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        
        elementCheck = GameObject.Find("XR Rig Advanced").GetComponent<CheckElement>();
        
        none = elementCheck.none;
        fire = elementCheck.fire;
        ice = elementCheck.ice;
        thunder = elementCheck.thunder;
        flameMain = flame.main;
        glowMain = glow.main;
        sparkMain = spark.main;
        Explosion();
    }

    void Start()
    {


        elementCheck = GameObject.Find("XR Rig Advanced").GetComponent<CheckElement>();

        none = elementCheck.none;
        fire = elementCheck.fire;
        ice = elementCheck.ice;
        thunder = elementCheck.thunder;
        flameMain = flame.main;
        glowMain = glow.main;
        sparkMain = spark.main;
        Explosion();
    }
    // Update is called once per frame
    public void Explosion()
    {

        if (none)
        {
            flameMain.startColor = new Color(255, 255, 255);
            glowMain.startColor = new Color(255, 255, 255);
            sparkMain.startColor = new Color(255, 255, 255);
        }

        if (fire)
        {
            flameMain.startColor = new Color(255, 0, 0);
            glowMain.startColor = new Color(255, 0, 0);
            sparkMain.startColor = new Color(255, 0, 0);
        }

        if (ice)
        {
            flameMain.startColor = new Color(0, 113, 255);
            glowMain.startColor = new Color(0, 113, 255);
            sparkMain.startColor = new Color(0, 113, 255);
        }

        if (thunder)
        {
            flameMain.startColor = new Color(255, 206, 0);
            glowMain.startColor = new Color(255, 206, 0);
            sparkMain.startColor = new Color(255, 206, 0);
        }
    }
    void Update()
    {

        

    }
}
