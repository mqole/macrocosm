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

        SubscribeLocalEvent<CardComponent, GetVerbsEvent<InteractionVerb>>(OnCardVerb);
        SubscribeLocalEvent<CardComponent, GetVerbsEvent<AlternativeVerb>>(OnCardAltVerb);
        SubscribeLocalEvent<CardComponent, ExaminedEvent>(OnCardExamine);

        SubscribeLocalEvent<CardStackComponent, GetVerbsEvent<InteractionVerb>>(OnStackVerb);
        SubscribeLocalEvent<CardStackComponent, GetVerbsEvent<AlternativeVerb>>(OnStackAltVerb);
        SubscribeLocalEvent<CardStackComponent, ExaminedEvent>(OnStackExamine);
    }

    /// <summary>
    ///     Interaction verb will stack the held card onto a <see
    ///     cref="CardComponent"> entity or a <see
    ///     cref="CardStackComponent"/> entity.
    /// </summary>
    private void OnCardVerb(Entity<CardComponent> ent, ref GetVerbsEvent<InteractionVerb> args)
    {
        if (!args.CanInteract || !args.CanAccess)
            return;

        var target = args.Target;
        var comp = ent.Comp;
        var verb = new InteractionVerb();

        if (TryComp<CardStackComponent>(target, out var targetStack))
        {
            var isHand = targetStack.IsHand;

            verb.Text = isHand ?
                comp.AddHandText : comp.AddDeckText;
            verb.Message = isHand ?
                comp.AddHandMessage : comp.AddDeckMessage;
            verb.Act = () => AddCardToStack(ent, (target, targetStack));
        }

        else if (TryComp<CardComponent>(target, out var targetCard))
        {
            verb.Text = comp.AddDeckText;
            verb.Message = comp.AddDeckMessage;
            verb.Act = () => AddCardToStack(ent, (target, targetCard));
        }

        else
        {
            return;
        }

        args.Verbs.Add(verb);
    }

    /// <summary>
    ///     Alt verb flips this card.
    /// </summary>
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

    private void AddCardToStack(Entity<CardComponent> card, Entity<CardStackComponent> stack)
    {

    }

    private void AddCardToStack(Entity<CardComponent> card, Entity<CardComponent> stack)
    {

    }
}
