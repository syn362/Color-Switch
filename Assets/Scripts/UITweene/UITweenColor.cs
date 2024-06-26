using UnityEngine;
using UnityEngine.UI;

namespace HivaGames.UnityUI.UITweene
{
    public class UITweenColor : UITweener
    {
        public Color From;
        public Color To;

        private Graphic myGraphic;

        private void Reset()
        {
            myGraphic = null;
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = Color.Lerp(From, To, factor);
        }

        private void CacheGraphic()
        {
            if (myGraphic == null)
                myGraphic = GetComponent<Graphic>();
        }

        public Color value
        {
            get
            {
                CacheGraphic();
                return myGraphic.color;
            }
            set
            {
                CacheGraphic();
                var tempColor = myGraphic.color;
                tempColor = value;
                myGraphic.color = tempColor;
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