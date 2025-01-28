using System;
using ProjectFiles.Core.Services;
using UnityEngine;

namespace ProjectFiles.Core.Base
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemBase:MonoBehaviour,IItem
    {
        public Rigidbody ItemRigidbody { get; private set; }
        public bool Grabbed { get;private set; }
        public void Grab()
        {
            Grabbed = true;
            ItemRigidbody.isKinematic = true;
        }
        public void Drop()
        {
            Grabbed = false;
            ItemRigidbody.isKinematic = false;
        }
        private void Awake()
        {
            Init();
        }
        public void Init()
        {
            ItemRigidbody = GetComponent<Rigidbody>();
        }
        public void OnGrab(Vector3 grabPoint,bool isGrab)
        {
            if(!isGrab||ItemRigidbody == null)return;
            ItemRigidbody.transform.position = grabPoint;
        }
    }
}