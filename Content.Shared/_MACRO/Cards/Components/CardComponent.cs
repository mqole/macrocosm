using Content.Shared._MACRO.Cards.Systems;
using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Cards.Components;

/// <summary>
///     A single card that can be flipped, and merged into a <see
///     cref="CardStackComponent"/> entity.
/// </summary>
[RegisterComponent, Access(typeof(CardSystem))]
[NetworkedComponent, AutoGenerateComponentState]
public sealed partial class CardComponent : Component
{
    [DataField, AutoNetworkedField]
    public bool FaceVisible;

    public LocId AddDeckText = "card-single-add-to-deck-text";
    public LocId AddDeckMessage = "card-single-add-to-deck-message";

    public LocId AddHandText = "card-single-add-to-hand-text";
    public LocId AddHandMessage = "card-single-add-to-hand-message";

    public LocId AltVerbText = "card-single-flip-text";
}
