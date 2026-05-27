using Content.Shared._MACRO.Cards.Systems;

namespace Content.Shared._MACRO.Cards.Components;

/// <summary>
///     Empty component used to declare an entity as a card deck
///     which can fill a <see cref="CardStackComponent"/> entity with
///     <see cref="CardComponent"/> entities.
/// </summary>
[RegisterComponent, Access(typeof(CardSystem))]
public sealed partial class CardDeckComponent : Component { }
