using UnityEngine;

namespace HivaGames.UnityUI.UITweene
{
    public class UITweenAnchoredPosition : UITweener
    {
        public Vector2 From;
        public Vector2 To;
        private RectTransform thisRect;

        private void OnEnable()
        {
            thisRect = GetComponent<RectTransform>();
        }
        protected override void OnUpdate(float factor, bool isFinished)
        {
            thisRect.anchoredPosition = Vector2.Lerp(From, To, factor);
        }


        public Vector2 value
        {
            get => thisRect.anchoredPosition;
            set => value = thisRect.anchoredPosition;
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