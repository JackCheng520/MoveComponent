using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：JCamera3D  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/20 10:11:34
// ================================
namespace Assets.JackCheng.Track
{
    public class JCamera3DCtrl : MonoBehaviour
    {
        public MOVER mover;

        public TrackMovement shaker;

        public Transform root;

        public Transform focus;

        public Vector3 targetPos;

        void Awake() 
        {
            mover = new MOVER(root);
        }

        public void Update() {
            LookAt();
            if(mover != null)
                mover.Update();
        }

        private void LookAt() {
            if (focus != null && root != null) 
            {
                root.LookAt(focus, Vector3.up);
            }
        }

        private void ShakeCamera() {
            shaker.Launch();
        }

        void OnGUI() 
        {
            if (GUILayout.Button("相机抖动")) 
            {
                ShakeCamera();
            }

            if (GUILayout.Button("相机移动")) 
            {
                mover.MoveTo(targetPos);
            }
        }
    }
}
