﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
#if SOAR_HAS_VFX
using UnityEditor.Experimental.Rendering;

namespace VolumeMixerUtility.Editor
{
    [VolumeComponentEditor(typeof(VolumeMixer))]
    public class VolumeMixerEditor : VolumeComponentEditor
    {
        SerializedDataParameter[] m_CustomFloatParameters;
        SerializedDataParameter[] m_CustomVectorParameters;
        SerializedDataParameter[] m_CustomColorParameters;

        public override void OnEnable()
        {
            base.OnEnable();
            var o = new PropertyFetcher<VolumeMixer>(serializedObject);

            m_CustomFloatParameters = new SerializedDataParameter[8]
            {
            Unpack(o.Find(x => x.CustomFloatParameter1)),
            Unpack(o.Find(x => x.CustomFloatParameter2)),
            Unpack(o.Find(x => x.CustomFloatParameter3)),
            Unpack(o.Find(x => x.CustomFloatParameter4)),
            Unpack(o.Find(x => x.CustomFloatParameter5)),
            Unpack(o.Find(x => x.CustomFloatParameter6)),
            Unpack(o.Find(x => x.CustomFloatParameter7)),
            Unpack(o.Find(x => x.CustomFloatParameter8))
            };

            m_CustomVectorParameters = new SerializedDataParameter[8]
            {
            Unpack(o.Find(x => x.CustomVector3Parameter1)),
            Unpack(o.Find(x => x.CustomVector3Parameter2)),
            Unpack(o.Find(x => x.CustomVector3Parameter3)),
            Unpack(o.Find(x => x.CustomVector3Parameter4)),
            Unpack(o.Find(x => x.CustomVector3Parameter5)),
            Unpack(o.Find(x => x.CustomVector3Parameter6)),
            Unpack(o.Find(x => x.CustomVector3Parameter7)),
            Unpack(o.Find(x => x.CustomVector3Parameter8))
            };

            m_CustomColorParameters = new SerializedDataParameter[8]
            {
            Unpack(o.Find(x => x.CustomColorParameter1)),
            Unpack(o.Find(x => x.CustomColorParameter2)),
            Unpack(o.Find(x => x.CustomColorParameter3)),
            Unpack(o.Find(x => x.CustomColorParameter4)),
            Unpack(o.Find(x => x.CustomColorParameter5)),
            Unpack(o.Find(x => x.CustomColorParameter6)),
            Unpack(o.Find(x => x.CustomColorParameter7)),
            Unpack(o.Find(x => x.CustomColorParameter8))
            };
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Float Properties", EditorStyles.boldLabel);
            for (int i = 0; i < VolumeMixerSettings.floatPropertyCount; i++)
            {
                NamedPropertyField(m_CustomFloatParameters[i], VolumeMixerSettings.floatPropertyNames[i]);
            }
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Vector Properties", EditorStyles.boldLabel);
            for (int i = 0; i < VolumeMixerSettings.vectorPropertyCount; i++)
            {
                NamedPropertyField(m_CustomVectorParameters[i], VolumeMixerSettings.vectorPropertyNames[i]);
            }
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Color Properties", EditorStyles.boldLabel);
            for (int i = 0; i < VolumeMixerSettings.colorPropertyCount; i++)
            {
                NamedPropertyField(m_CustomColorParameters[i], VolumeMixerSettings.colorPropertyNames[i]);
            }
        }

        void NamedPropertyField(SerializedDataParameter parameter, string label)
        {
            PropertyField(parameter, new GUIContent(label));
        }
    }
}
#endif
