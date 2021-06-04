// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Containers.Markdown;
using osu.Game.Graphics;
using osu.Game.Graphics.Containers;
using osu.Game.Graphics.Sprites;

namespace osu.Game.Overlays.Wiki
{
    public class WikiSidebar : OverlaySidebar
    {
        private FillFlowContainer tableOfContents;

        protected override Drawable CreateContent() => new FillFlowContainer
        {
            Direction = FillDirection.Vertical,
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            Children = new Drawable[]
            {
                new OsuSpriteText
                {
                    Text = "CONTENTS",
                    Font = OsuFont.GetFont(size: 12, weight: FontWeight.Bold),
                },
                tableOfContents = new FillFlowContainer
                {
                    Direction = FillDirection.Vertical,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                }
            },
        };

        public void AddToc(string title, MarkdownHeading heading, int level)
        {
            switch (level)
            {
                case 2:
                    tableOfContents.Add(new TocTitle(title));
                    break;
            }
        }

        private class TocTitle : OsuHoverContainer
        {
            private readonly OsuSpriteText spriteText;

            public TocTitle(string text)
            {
                RelativeSizeAxes = Axes.X;
                AutoSizeAxes = Axes.Y;
                Child = spriteText = new OsuSpriteText
                {
                    Text = text,
                    Font = OsuFont.GetFont(size: 15),
                };
            }

            protected override IEnumerable<Drawable> EffectTargets => new Drawable[] { spriteText };

            [BackgroundDependencyLoader]
            private void load(OverlayColourProvider colourProvider)
            {
                IdleColour = colourProvider.Light2;
                HoverColour = colourProvider.Light1;
            }
        }
    }
}
