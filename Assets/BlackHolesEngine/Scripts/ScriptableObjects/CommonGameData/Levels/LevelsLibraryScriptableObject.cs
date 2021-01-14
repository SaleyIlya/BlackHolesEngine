using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.ScriptableLibrary;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Levels
{
    [CreateAssetMenu(fileName = "LevelsLibrary", menuName = "BlackHolesEngine/CommonObjects/Levels/Library", order = 0)]
    public class LevelsLibraryScriptableObject : ScriptableLibrary<LevelLibraryNode, int, LevelScriptableObject> { }
} 