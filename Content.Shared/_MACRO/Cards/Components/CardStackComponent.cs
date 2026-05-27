using Content.Shared._MACRO.Cards.Systems;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._MACRO.Cards.Components;

/// <summary>
///     A container stack of <see cref="CardComponent"/> entities,
///     visualised as either a hand or a deck, which can be drawn
///     from to remove entities in the container.
/// </summary>
[RegisterComponent, Access(typeof(CardSystem))]
[NetworkedComponent, AutoGenerateComponentState]
public sealed partial class CardStackComponent : Component
{
    /// <summary>
    ///     If true, this entity is considered a 'hand' of cards.
    ///     This affects interaction behaviour and sprite appearance.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool IsHand;

    /// <summary>
    ///     The cards in this stack.
    /// </summary>
    [DataField, AutoNetworkedField]
    public Container Cards = default;

    /// <summary>
    ///     Used to define in YML the cards this should start stacked with.
    /// </summary>
    [DataField]
    public EntProtoId<CardDeckComponent>? Deck;
}
