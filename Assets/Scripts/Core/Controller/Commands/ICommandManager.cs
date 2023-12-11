namespace MN.Core.Controller.Commands
{
    /// <summary>
    ///   The CommandManager allows to observe and invoke <see cref="ICommand"/> instances.
    /// </summary>
    public interface ICommandManager
    {
        void AddCommandListener<TCommand>(CommandManager.InvokeCommandDelegate<TCommand> del) where TCommand : ICommand;
        
        void RemoveCommandListener<TCommand>(CommandManager.InvokeCommandDelegate<TCommand> del) where TCommand : ICommand;
        
        void InvokeCommand(ICommand command);
    }
}