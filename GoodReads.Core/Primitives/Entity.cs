namespace GoodReads.Core.Primitives;

/// <summary>
/// Primitive responsible for representing a core entity.
/// </summary>
public abstract class Entity
{
    public int Id { get; protected set; }
}