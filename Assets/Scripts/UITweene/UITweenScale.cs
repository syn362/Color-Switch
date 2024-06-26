using System;
using UnityEngine;

namespace HivaGames.UnityUI.UITweene
{
    public class UITweenScale : UITweener
    {
        public Vector3 From;
        public Vector3 To;

        protected override void OnUpdate(float factor, bool isFinished)
        {
            transform.localScale = Vector3.Lerp(From, To, factor);
        }

        public Vector3 value
        {
            get => transform.localScale;
            set => transform.localScale = value;
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