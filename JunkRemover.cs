using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reptile;
using UnityEngine;

namespace SmootherTraversal
{
    internal class JunkRemover
    {
        private List<GameObject> _forceDisable = new List<GameObject>();
        public JunkRemover()
        {
            StageManager.OnStagePostInitialization += StageManager_OnStagePostInitialization;
        }

        public void OnUpdate()
        {
            foreach(var obj in _forceDisable)
            {
                if (obj == null)
                    continue;
                if (obj.activeSelf)
                    obj.SetActive(false);
            }
        }

        void StageManager_OnStagePostInitialization()
        {
            _forceDisable.Clear();
            var transforms = GameObject.FindObjectsOfType<Transform>(true);
            foreach(var transform in transforms)
            {
                if (JunkDisposalSettings.RemoveGroundPoles && (
                    transform.gameObject.name.ToLowerInvariant().StartsWith("groundpole") ||
                    transform.gameObject.name.ToLowerInvariant().StartsWith("firehydrant")
                    ))
                {
                    GameObject.Destroy(transform.gameObject);
                    continue;
                }
                
                if (JunkDisposalSettings.RemoveJunk && transform.gameObject.layer == 21)
                {
                    _forceDisable.Add(transform.gameObject);
                    transform.gameObject.SetActive(false);
                    continue;
                }

                if (JunkDisposalSettings.RemovePeople)
                {
                    var streetLife = transform.gameObject.GetComponent<StreetLifeCluster>();
                    if (streetLife)
                    {
                        _forceDisable.Add(transform.gameObject);
                        streetLife.gameObject.SetActive(false);
                        continue;
                    }
                }

                if (JunkDisposalSettings.LightObstacles && transform.gameObject.layer == 21)
                {
                    /*
                    var junk = transform.gameObject.GetComponent<Junk>();
                    if (junk)
                        junk.FallApart(true);*/
                    var rb = transform.gameObject.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.isKinematic = false;
                    }
                }

                if (JunkDisposalSettings.RemoveCars)
                {
                    var car = transform.gameObject.GetComponent<Car>();
                    if (car)
                    {
                        _forceDisable.Add(transform.gameObject);
                        transform.gameObject.SetActive(false);
                        continue;
                    }
                }
            }
        }
    }
}
