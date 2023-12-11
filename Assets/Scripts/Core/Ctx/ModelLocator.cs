namespace MN.Core.Ctx
{
	using MN.Core.Model;

	/// <summary>
	/// This Locator manages the storage, lookup, and retrieval of <see cref="IModel"/> objects.
	///
	/// The primary use case within <see cref="IMVC"/> is to allow any <see cref="IConcern"/> to access any <see cref="IModel"/>.
	/// </summary>
	public class ModelLocator : Locator<IModel>
	{
	}
}