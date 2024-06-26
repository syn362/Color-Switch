using UnityEngine;
using UnityEngine.UI;

namespace HivaGames.UnityUI.UITweene
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Graphic))]
    public class UITweenAlphaCanvas : UITweener
    {
        [Range(0, 1)]
        public float From;
        [Range(0, 1)]
        public float To;

        private CanvasGroup canvasRenderer ;

        private void Reset()
        {
            canvasRenderer = null;
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = Mathf.Lerp(From, To, factor);
        }

        private void CacheCanvas()
        {
            if (canvasRenderer == null)
                canvasRenderer = GetComponent<CanvasGroup>();
        }

        public float value
        {
            get
            {
                CacheCanvas();
                return canvasRenderer.alpha;
            }
            set
            {
                CacheCanvas();
                canvasRenderer.alpha = value;
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
