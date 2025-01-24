using Unity.VisualScripting;
using UnityEditor;

[CustomEditor(typeof(Interaksi), true)]
public class interactible_editor : Editor
{
    public override void OnInspectorGUI()
    {
        Interaksi interaksi = (Interaksi)target;
        if(target.GetType()== typeof(Eventonly_Interaksi))
        {
            interaksi.promptMassage=EditorGUILayout.TextField("Prompt Message",interaksi.promptMassage);
            EditorGUILayout.HelpBox("Eventonlyinteract can only use unity event ",MessageType.Info);
            if(interaksi.GetComponent<Interaction_Event>()==null)
            {
                interaksi.useEvents=true;
                interaksi.gameObject.AddComponent<Interaction_Event>();
            }
        }
        base.OnInspectorGUI();

        if (interaksi.useEvents)
        {
            if (interaksi.GetComponent<Interaction_Event>() == null)
            interaksi.gameObject.AddComponent<Interaction_Event>();
        }
         else
         {

             if (interaksi.GetComponent<Interaction_Event>() != null)
                 DestroyImmediate(interaksi.GetComponent<Interaction_Event>());
             }
         } 
    }

