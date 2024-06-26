using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HivaGames.UnityUI.UITweene
{
    [RequireComponent(typeof(UnityEngine.UI.Graphic))]
    public class UITweenAlpha : UITweener
    {
        [Range(0, 1)]
        public float From;
        [Range(0, 1)]
        public float To;

        private UnityEngine.UI.Graphic myGraphic;

        private void Reset()
        {
            myGraphic = null;
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = Mathf.Lerp(From, To, factor);
        }

        private void CacheGraphic()
        {
            if (myGraphic == null)
                myGraphic = GetComponent<UnityEngine.UI.Graphic>();
        }

        public float value
        {
            get
            {
                CacheGraphic();
                return myGraphic.color.a;
            }
            set
            {
                CacheGraphic();
                var tempColor = myGraphic.color;
                tempColor.a = value;
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
