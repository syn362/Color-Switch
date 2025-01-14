﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace HivaGames.UnityUI.UITweene
{
    public static class NGUIEditorTools
    {
        /// <summary>
        /// Begin drawing the content area.
        /// </summary>

        static public void BeginContents() { BeginContents(true); }

        static bool mEndHorizontal = false;

        /// <summary>
        /// Begin drawing the content area.
        /// </summary>

        static public void BeginContents(bool minimalistic)
        {
            if (!minimalistic)
            {
                mEndHorizontal = true;
                GUILayout.BeginHorizontal();
                EditorGUILayout.BeginHorizontal("TextArea", GUILayout.MinHeight(10f));
            }
            else
            {
                mEndHorizontal = false;
                EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(10f));
                GUILayout.Space(10f);
            }
            GUILayout.BeginVertical();
            GUILayout.Space(2f);
        }

        static public void SetLabelWidth(float width)
        {
            EditorGUIUtility.labelWidth = width;
        }

        static public bool DrawMinimalisticHeader(string text) { return DrawHeader(text, text, false, true); }

        /// <summary>
        /// Draw a distinctly different looking header label
        /// </summary>

        static public bool DrawHeader(string text) { return DrawHeader(text, text, false, true); }

        /// <summary>
        /// Draw a distinctly different looking header label
        /// </summary>

        static public bool DrawHeader(string text, string key) { return DrawHeader(text, key, false, true); }

        /// <summary>
        /// Draw a distinctly different looking header label
        /// </summary>

        static public bool DrawHeader(string text, bool detailed) { return DrawHeader(text, text, detailed, !detailed); }

        /// <summary>
        /// Draw a distinctly different looking header label
        /// </summary>

        static public bool DrawHeader(string text, string key, bool forceOn, bool minimalistic)
        {
            bool state = EditorPrefs.GetBool(key, true);

            if (!minimalistic) GUILayout.Space(3f);
            if (!forceOn && !state) GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
            GUILayout.BeginHorizontal();
            GUI.changed = false;

            if (minimalistic)
            {
                if (state) text = "\u25BC" + (char)0x200a + text;
                else text = "\u25BA" + (char)0x200a + text;

                GUILayout.BeginHorizontal();
                GUI.contentColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.7f) : new Color(0f, 0f, 0f, 0.7f);
                if (!GUILayout.Toggle(true, text, "PreToolbar2", GUILayout.MinWidth(20f))) state = !state;
                GUI.contentColor = Color.white;
                GUILayout.EndHorizontal();
            }
            else
            {
                text = "<b><size=11>" + text + "</size></b>";
                if (state) text = "\u25BC " + text;
                else text = "\u25BA " + text;
                if (!GUILayout.Toggle(true, text, "dragtab", GUILayout.MinWidth(20f))) state = !state;
            }

            if (GUI.changed) EditorPrefs.SetBool(key, state);

            if (!minimalistic) GUILayout.Space(2f);
            GUILayout.EndHorizontal();
            GUI.backgroundColor = Color.white;
            if (!forceOn && !state) GUILayout.Space(3f);
            return state;
        }

        static public void EndContents()
        {
            GUILayout.Space(3f);
            GUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            if (mEndHorizontal)
            {
                GUILayout.Space(3f);
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(3f);
        }

        static public void RegisterUndo(string name, params UnityEngine.Object[] objects)
        {
            if (objects != null && objects.Length > 0)
            {
                UnityEditor.Undo.RecordObjects(objects, name);

                foreach (UnityEngine.Object obj in objects)
                {
                    if (obj == null) continue;
                    EditorUtility.SetDirty(obj);
                }
            }
        }
    }
}
