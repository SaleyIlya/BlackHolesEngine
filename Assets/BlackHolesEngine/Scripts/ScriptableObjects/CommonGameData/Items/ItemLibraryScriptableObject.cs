using BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.ScriptableLibrary;
using UnityEngine;

namespace BlackHoles.BlackHolesEngine.Scripts.ScriptableObjects.CommonGameData.Items
{
    [CreateAssetMenu(fileName = "ItemLibrary", menuName = "BlackHolesEngine/CommonObjects/Items/Library", order = 0)]
    public class ItemLibraryScriptableObject : ScriptableLibrary<ItemLibraryNode, string, ItemScriptableObject>
    {
        [ContextMenu("Fill Items Keys")]
        public void FillItemKeys()
        {
            foreach (var item in library)
            {
                item.Key = item.Value.GetItem().ItemId.ToString();
            }
        }
    }
}