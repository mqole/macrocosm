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

    public LocId HandOpenText = "card-hand-open-text";

    public LocId HandShuffleText = "card-hand-shuffle-text";
    public LocId HandShuffleMessage = "card-hand-shuffle-message";

    public LocId DeckDrawText = "card-deck-draw-text";
    public LocId DeckDrawMessage = "card-deck-draw-message";

    public LocId DeckShuffleText = "card-deck-shuffle-text";
    public LocId DeckShuffleMessage = "card-deck-shuffle-message";

    public LocId DeckToHandText = "card-deck-convert-text";
    public LocId DeckToHandMessage = "card-deck-convert-message";
    public LocId HandToDeckText = "card-hand-convert-text";
    public LocId HandToDeckMessage = "card-hand-convert-message";
}
