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

        private SerializedProperty _allowedAmountOfExceptions, _timeToWaitBeforeChangingColor, _cube, _colorNameTMP, _endpoint, _query;
        private const string DocumentationURL = "https://graphql.org/learn/";

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
            SetupAllowedAmountOfExceptions();
            SetupTimeToWaitBeforeChangingColor();
            SetupCube();
            SetupColorNameTMP();
            SetupQuery();
            SetupEndpoint();
        }
        private void Show()
        {
            EditorGUILayout.LabelField(new GUIContent("Base Settings", "Settings related to the logic itself."), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            ShowAllowedAmountOfExceptions();
            ShowTimeToWaitBeforeChangingColor();
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("In-Game Settings", "Settings related to the scene objects."), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            ShowCube();
            ShowColorNameTMP();
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("GraphQL Settings", "Settings related to the backend."), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            ShowEndpoint();
            ShowQuery();
            EditorGUI.indentLevel--;
        }
        
        private void SetupAllowedAmountOfExceptions()
        {
            _allowedAmountOfExceptions = serializedObject.FindProperty("allowedAmountOfExceptions");
        }
        private void ShowAllowedAmountOfExceptions()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Allowed amount of exceptions", "The amount of exceptions that are allowed to be thrown before the coroutine stops.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.9f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.PropertyField(_allowedAmountOfExceptions, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        private void SetupTimeToWaitBeforeChangingColor()
        {
            _timeToWaitBeforeChangingColor = serializedObject.FindProperty("timeToWaitBeforeChangingColor");
        }
        private void ShowTimeToWaitBeforeChangingColor()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Time to wait before changing color", "The time to wait before changing the color of the cube.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.9f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.PropertyField(_timeToWaitBeforeChangingColor, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        private void SetupCube()
        {
            _cube = serializedObject.FindProperty("cube");
        }
        private void ShowCube()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Cube", "Reference for the cube that is going to have it's color changed.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.9f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.PropertyField(_cube, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        private void SetupColorNameTMP()
        {
            _colorNameTMP = serializedObject.FindProperty("colorNameTMP");
        }
        private void ShowColorNameTMP()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Color name", "Reference for the TextMeshPro object that is going to have it's text changed.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.9f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.PropertyField(_colorNameTMP, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        private void SetupEndpoint()
        {
            _endpoint = serializedObject.FindProperty("endpoint");
        }
        private void ShowEndpoint()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Endpoint", "The endpoint of the GraphQL server.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.9f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.PropertyField(_endpoint, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        private void SetupQuery()
        {
            _query = serializedObject.FindProperty("query");
        }
        private void ShowQuery()
        {
            EditorGUILayout.BeginHorizontal();
            {
                var guiContent = new GUIContent("Query", "The query to be sent to the GraphQL server.");
                var recalculatedLabelWidth = GUILayout.Width(EditorGUIUtility.labelWidth * 0.885f);
                
                EditorGUILayout.LabelField(guiContent, recalculatedLabelWidth);
                EditorGUILayout.BeginVertical();
                {
                    var areaStyle = new GUIStyle(EditorStyles.textArea)
                    {
                        wordWrap = true,
                        stretchHeight = true
                    };
                    _query.stringValue = EditorGUILayout.TextArea(_query.stringValue, areaStyle);
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(17.05f);
                        if (GUILayout.Button("Open Documentation"))
                            Application.OpenURL(DocumentationURL);
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
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