namespace Project.Features.ColorRandomizer.Editor
{
    using UnityEngine;
    using UnityEditor;
    using Runtime;
    
    [CustomEditor(typeof(ColorRandomizerSceneController))]
    public class ColorRandomizerSceneControllerEditor : Editor
    {
        #region Variables

        #region Private Variables

        private SerializedProperty _cube;

        #endregion

        #endregion

        #region Methods

        #region Private Methods

        private void OnEnable()
        {
            Setup();
        }

        private void Setup()
        {
            SetupCube();
        }
        private void Show()
        {
            EditorGUILayout.LabelField(new GUIContent("Base Settings", "Base settings for the ColorRandomizerSceneController."), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            ShowCube();
            EditorGUI.indentLevel--;
        }

        private void SetupCube()
        {
            _cube = serializedObject.FindProperty("cube");
        }
        private void ShowCube()
        {
            EditorGUILayout.PropertyField(_cube, new GUIContent("Cube", "Reference for the cube that is going to have it's color changed."));
        }

        #endregion
        
        #region Public Methods

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            Show();
            serializedObject.ApplyModifiedProperties();
        }
        
        #endregion
        
        #endregion
    }
}