using System;
using UnityEngine;
using HivaGames.UnityUI.UITweene.AnimationOrTween;
using UnityEngine.Events;

namespace HivaGames.UnityUI.UITweene
{
    public class UIPlayTween : MonoBehaviour
    {
        static public UIPlayTween current;
        public GameObject tweenTarget;
        public int tweenGroup = 0;
        public Direction playDirection = Direction.Forward;
        public bool resetOnPlay = false;
        public bool resetIfDisabled = false;
        public EnableCondition ifDisabledOnPlay = EnableCondition.DoNothing;
        public DisableCondition disableWhenFinished = DisableCondition.DoNotDisable;
        public bool includeChildren = false;
        public UnityEvent onFinished = new UnityEvent();

        UITweener[] mTweens;
        bool mStarted = false;
        int mActive = 0;
        bool mActivated = false;


        void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            if (disableWhenFinished != DisableCondition.DoNotDisable && mTweens != null)
            {
                bool isFinished = true;
                bool properDirection = true;

                for (int i = 0, imax = mTweens.Length; i < imax; ++i)
                {
                    UITweener tw = mTweens[i];
                    if (tw.tweenGroup != tweenGroup) continue;

                    if (tw.enabled)
                    {
                        isFinished = false;
                        break;
                    }
                    else if ((int)tw.direction != (int)disableWhenFinished)
                    {
                        properDirection = false;
                    }
                }

                if (isFinished)
                {
                    if (properDirection) tweenTarget.SetActive(false);
                    mTweens = null;
                }
            }
        }

        [ContextMenu("PlayForward")]
        public void PlayForward() { Play(true); }
        [ContextMenu("PlayReverse")]
        public void PlayReverse() { Play(false); }

        public void Play(bool forward)
        {
            mActive = 0;
            GameObject go = (tweenTarget == null) ? gameObject : tweenTarget;

            if (!(go && go.activeInHierarchy))
            {
                // If the object is disabled, don't do anything
                if (ifDisabledOnPlay != EnableCondition.EnableThenPlay) return;

                // Enable the game object before tweening it
                go.SetActive(true);
            }

            // Gather the tweening components
            mTweens = includeChildren ? go.GetComponentsInChildren<UITweener>() : go.GetComponents<UITweener>();

            if (mTweens.Length == 0)
            {
                // No tweeners found -- should we disable the object?
                if (disableWhenFinished != DisableCondition.DoNotDisable)
                    tweenTarget.SetActive(false);
            }
            else
            {
                bool activated = false;
                if (playDirection == Direction.Reverse) forward = !forward;

                // Run through all located tween components
                for (int i = 0, imax = mTweens.Length; i < imax; ++i)
                {
                    UITweener tw = mTweens[i];

                    // If the tweener's group matches, we can work with it
                    if (tw.tweenGroup == tweenGroup)
                    {
                        // Ensure that the game objects are enabled
                        if (!activated && !(go && go.activeInHierarchy))
                        {
                            activated = true;
                            go.SetActive(true);
                        }

                        ++mActive;

                        // Toggle or activate the tween component
                        if (playDirection == Direction.Toggle)
                        {
                            // Listen for tween finished messages
                            tw.onFinished.AddListener(OnFinished);
                            tw.Toggle();
                        }
                        else
                        {
                            if (resetOnPlay || (resetIfDisabled && !tw.enabled))
                            {
                                tw.Play(forward);
                                tw.ResetToBeginning();
                            }
                            // Listen for tween finished messages
                            tw.onFinished.AddListener(OnFinished);
                            tw.Play(forward);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Callback triggered when each tween executed by this script finishes.
        /// </summary>

        void OnFinished()
        {
            if (--mActive == 0 && current == null)
            {
                current = this;
                onFinished.Invoke();
            }
        }
    }
}
