namespace MN.Core.Ctx
{
    using System;
    using Controller.Commands;

    /// <summary>
    ///  See <see cref="Context"/>
    /// </summary>
    public interface IContext : IDisposable
    {
        ModelLocator ModelLocator { get; }
        ICommandManager CommandManager { get; }
    }
}