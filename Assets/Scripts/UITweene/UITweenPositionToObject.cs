using UnityEngine;

namespace HivaGames.UnityUI.UITweene
{
    public class UITweenPositionToObject : UITweener
    {
        public UnityEngine.UI.Graphic From;
        public UnityEngine.UI.Graphic To;

        protected override void OnUpdate(float factor, bool isFinished)
        {
            transform.position = Vector3.Lerp(From.transform.position, To.transform.position, factor);
        }


        public Vector3 value
        {
            get => transform.position;
            set => value = transform.position;
        }


        [ContextMenu("Set 'From' to current value")]
        public override void SetStartToCurrentValue() { if(From != null) From.transform.position = value; }
        [ContextMenu("Set 'To' to current value")]
        public override void SetEndToCurrentValue() { if (To != null) To.transform.position = value; }
        [ContextMenu("Assume value of 'From'")]
        void SetCurrentValueToStart() { if (From != null) value = From.transform.position; }
        [ContextMenu("Assume value of 'To'")]
        void SetCurrentValueToEnd() { if (To != null) value = To.transform.position; }
    }
}