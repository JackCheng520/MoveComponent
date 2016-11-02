using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// ================================
//* 功能描述：TrackColor  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/7/19 16:45:54
// ================================
namespace Assets.JackCheng.Track
{
    public class TrackColor : MonoBehaviour
    {
        public float r;
        public AnimationCurve curveR;

        public float g;
        public AnimationCurve curveG;

        public float b;
        public AnimationCurve curveB;

        public float a;
        public AnimationCurve curveA;

        public float timeScale = 1.0f;

        public Graphic graphic;

        public bool bForward = false;

        private float fTime = 0;

        private Color resultColor;

        private bool bAction = false;
        
        private float dir = 1;

        public void Launch()
        {
            if (bForward)
            {
                fTime = 0;
                dir = 1;
            }
            else
            {
                fTime = 1;
                dir = -1;
            }
        }

        private void CheckR()
        {
            float fTemp = curveR.Evaluate(fTime);
            resultColor.r = fTemp * r * timeScale;
        }

        private void CheckG()
        {
            float fTemp = curveG.Evaluate(fTime);
            resultColor.g = fTemp * g * timeScale;
        }

        private void CheckB()
        {
            float fTemp = curveB.Evaluate(fTime);
            resultColor.b = fTemp * b * timeScale;
        }

        private void CheckA()
        {
            float fTemp = curveA.Evaluate(fTime);
            resultColor.a = fTemp * a * timeScale;
        }
        private void CheckTime()
        {
            CheckR();
            CheckG();
            CheckB();
            CheckA();

            graphic.color = resultColor;
        }

        private bool Process()
        {

            fTime += Time.deltaTime * timeScale * dir;
            if (fTime >= 1)
            {
                fTime = 1;
                CheckTime();
                return false;
            }
            else if (fTime <= 0)
            {
                fTime = 0;
                CheckTime();
                return false;
            }

            CheckTime();
            return true;
        }

        public bool bTest = false;
        private float _time = 0;
        void Update()
        {
            if (bTest)
            {
                bTest = false;
                Launch();
                bAction = true;
            }
            if (bAction)
            {
                bAction = Process();
            }

        }

    }
}
