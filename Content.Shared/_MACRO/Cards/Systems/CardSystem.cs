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
    card (defined as a deck with a single member)
    z =
    alt = flip
    click on card = form new deck with this card on top
    click on hand = add this card to top of hand
    click on deck = add this card to top of deck
    */

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CardComponent, GetVerbsEvent<AlternativeVerb>>(OnCardAltVerb);
        SubscribeLocalEvent<CardComponent, ExaminedEvent>(OnCardExamine);

        SubscribeLocalEvent<CardStackComponent, GetVerbsEvent<InteractionVerb>>(OnStackVerb);
        SubscribeLocalEvent<CardStackComponent, GetVerbsEvent<AlternativeVerb>>(OnStackAltVerb);
        SubscribeLocalEvent<CardStackComponent, ExaminedEvent>(OnStackExamine);
    }

    private void OnCardAltVerb(Entity<CardComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanInteract || !args.CanAccess)
            return;

        var verb = new AlternativeVerb
        {
            Text = Loc.GetString(ent.Comp.AltVerbText),
            Act = () => FlipCard(ent),
        };

        args.Verbs.Add(verb);
    }

    private void OnCardExamine(Entity<CardComponent> ent, ref ExaminedEvent args)
    {

    }

    private void FlipCard(Entity<CardComponent> ent)
    {
        ent.Comp.FaceVisible = !ent.Comp.FaceVisible;
    }
}
