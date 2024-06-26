using System;
using UnityEngine;
using UnityEngine.UI;


namespace HivaGames.UnityUI.UITweene
{
    [RequireComponent(typeof(AspectRatioFitter))]
    public class UITweenAspectFitter : UITweener
    {
        public float From;
        public float To;

        private AspectRatioFitter myAspectRatioFitter;

        private void Reset()
        {
            myAspectRatioFitter = null;
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = Mathf.Lerp(From, To, factor);
        }

        private void CacheAspectRatioFitter()
        {
            if (myAspectRatioFitter == null)
                myAspectRatioFitter = GetComponent<AspectRatioFitter>();
        }

        public float value
        {
            get
            {
                CacheAspectRatioFitter();
                return myAspectRatioFitter.aspectRatio;
            }
            set
            {
                CacheAspectRatioFitter();
                myAspectRatioFitter.aspectRatio = value;
            }
        }

        [ContextMenu("Set 'From' to current value")]
        public override void SetStartToCurrentValue() { From = value; }
        [ContextMenu("Set 'To' to current value")]
        public override void SetEndToCurrentValue() { To = value; }
        [ContextMenu("Assume value of 'From'")]
        void SetCurrentValueToStart() { value = From; }
        [ContextMenu("Assume value of 'To'")]
        void SetCurrentValueToEnd() { value = To; }

    }
}
