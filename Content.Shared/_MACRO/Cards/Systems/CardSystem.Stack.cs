using Content.Shared._MACRO.Cards.Components;
using Content.Shared.Examine;
using Content.Shared.Verbs;

namespace Content.Shared._MACRO.Cards.Systems;

public sealed partial class CardSystem : EntitySystem
{
    /*
    Cards should:
    - be stackable with each other
    - form a 'hand' (where specific cards can be removed),
    - or a 'deck' (where they may not)
    - be flippable, face down or face up

    VERB INTERACTIONS
    hand
    z = open radial menu to see individual cards
    alt = shuffle
    click on card = form new deck with this hand on top
    click on hand = add this hand to top of clicked hand
    click on deck = add this hand to top of deck

    deck
    z = draw top card
    alt = shuffle
    click on card = add deck to card
    click on hand = add deck to hand
    click on deck = add deck to deck
    */
    private void OnStackVerb(Entity<CardStackComponent> ent, ref GetVerbsEvent<InteractionVerb> args)
    {
        if (!args.CanInteract || !args.CanAccess)
            return;

        var target = args.Target;
    }

    private void OnStackAltVerb(Entity<CardStackComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanInteract || !args.CanAccess)
            return;
    }

    private void OnStackExamine(Entity<CardStackComponent> ent, ref ExaminedEvent args)
    {

    }
}
