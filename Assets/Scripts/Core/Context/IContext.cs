using System;
using MN.Core.Controller.Commands;

namespace MN.Core.Context
{
    /// <summary>
    /// See <see cref="Context"/>
    /// </summary>
    public interface IContext : IDisposable
    {
        ModelLocator ModelLocator { get; }
        ICommandManager CommandManager { get; }
    }
}