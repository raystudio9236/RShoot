using Entitas;
using RFramework.Common.Event;

namespace Components.Event
{
    public sealed class EventComp : IComponent
    {
        public EventDispatcher Dispatcher;
    }
}