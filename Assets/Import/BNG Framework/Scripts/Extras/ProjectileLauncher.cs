﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG {
    public class ProjectileLauncher : MonoBehaviour {

        /// <summary>
        /// Launch this from the 
        /// </summary>
        public GameObject ProjectileObject;
        public GameObject ProjectileAuto;

        public float ProjectileForce = 15f;

        public AudioClip LaunchSound;

        public ParticleSystem LaunchParticles;
        public Transform hinge;
        private bool fireReady;
        public float reloadTime;
        private GameObject _bullet;
        

        /// <summary>
        /// Where the projectile will launch from
        /// </summary>
        public Transform MuzzleTransform;

        private float _initialProjectileForce;

        // Start is called before the first frame update
        void Start() {
            // Setup initial velocity for launcher so we can modify it later
            _initialProjectileForce = ProjectileForce;
            fireReady = true;
        }

        /// <summary>
        /// Returns the object that was shot
        /// </summary>
        /// <returns>The object that was shot</returns>
        public GameObject ShootProjectile(float projectileForce) {
            
            if (MuzzleTransform && ProjectileObject) {
                GameObject launched = Instantiate(ProjectileObject, MuzzleTransform.transform.position, MuzzleTransform.transform.rotation) as GameObject;
                launched.transform.position = MuzzleTransform.transform.position;
                launched.transform.rotation = MuzzleTransform.transform.rotation;

                launched.GetComponentInChildren<Rigidbody>().AddForce(MuzzleTransform.forward * projectileForce, ForceMode.VelocityChange);

                VRUtils.Instance.PlaySpatialClipAt(LaunchSound, launched.transform.position, 1f);

                if(LaunchParticles) {
                    LaunchParticles.Play();
                }

                return launched;
            }

            return null;
        }

        public void ShootProjectile() {
            if (fireReady)
            {
                fireReady = false;
                ShootProjectile(ProjectileForce);
                Invoke("FireReadyTrue", reloadTime);
                

            }
        }

        public GameObject AutoShootProjectile(float projectileForce)
        {

            if (MuzzleTransform && ProjectileAuto)
            {
                GameObject launched = Instantiate(ProjectileAuto, MuzzleTransform.transform.position, MuzzleTransform.transform.rotation) as GameObject;
                launched.transform.position = MuzzleTransform.transform.position;
                launched.transform.rotation = MuzzleTransform.transform.rotation;

                launched.GetComponentInChildren<Rigidbody>().AddForce(MuzzleTransform.forward * projectileForce, ForceMode.VelocityChange);

                VRUtils.Instance.PlaySpatialClipAt(LaunchSound, launched.transform.position, 1f);

                if (LaunchParticles)
                {
                    LaunchParticles.Play();
                }

                return launched;
            }

            return null;

        }
            public void AutoShootProjectile(GameObject target)
        {

            
            _bullet = AutoShootProjectile(ProjectileForce);
            
            _bullet.GetComponent<BulletForTurret>().target = target;
            
            

        }

        public void SetForce(float force) {
            ProjectileForce = force;
        }

        public float GetInitialProjectileForce() {
            return _initialProjectileForce;
        }
        public void FireReadyTrue() {
            fireReady = true;
        }
    }
}

