namespace MN.Core.Ctx
{
    using System;
    using MN.Core.Controller.Commands;

    /// <summary>
    ///  See <see cref="Context"/>
    /// </summary>
    public interface IContext : IDisposable
    {
        ModelLocator ModelLocator { get; }
        ICommandManager CommandManager { get; }
    }
}