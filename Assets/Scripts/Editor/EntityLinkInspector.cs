using System.Linq;
using Entitas.Unity.VisualDebugging;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityLink))]
public class EntityLinkInspector : Editor {

    void Awake() {
        EntityDrawer.Initialize();
    }

    public override void OnInspectorGUI() {
        var link = (EntityLink)target;
        EditorGUILayout.LabelField(link.entity.ToString());

        if(GUILayout.Button("Show entity")) {
            Selection.activeGameObject = FindObjectsOfType<EntityBehaviour>()
                .Single(e => e.entity == link.entity).gameObject;
        }

        EditorGUILayout.Space();

        EntityDrawer.DrawEntity(link.context, link.entity);
    }
}
