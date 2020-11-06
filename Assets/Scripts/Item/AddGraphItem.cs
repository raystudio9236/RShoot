using Actions.Core;
using Manager;
using Other;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "AddGraphItem",
        menuName = "Item/AddGraphItem")]
    public class AddGraphItem : ItemData
    {
        public ActionGraph ActionGraph;

        protected override void OnPickUp(GameEntity entity)
        {
            ActionManager.Instance.AddGraph(entity, ActionGraph.name);
        }

        protected override void OnRemove(GameEntity entity)
        {
            ActionManager.Instance.RemoveGraph(entity, ActionGraph.name);
        }
    }
}