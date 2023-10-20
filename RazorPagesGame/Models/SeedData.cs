using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Data;

namespace RazorPagesGame.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesGameContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesGameContext>>()))
        {
            if (context == null || context.Game == null)
            {
                throw new ArgumentNullException("Null RazorPagesGameContext");
            }

            // Look for any movies.
            if (context.Game.Any())
            {
                return;   // DB has been seeded
            }

            context.Game.AddRange(
                new Game
                {
                    Title = "Wizard101",
                    ReleaseDate = DateTime.Parse("2008-9-2"),
                    Genre = "MMORPG",
                    Platform = "PC",
                    Price = 0
                },

                new Game
                {
                    Title = "Animal Crossing: New Horizons",
                    ReleaseDate = DateTime.Parse("2020-3-20"),
                    Genre = "Social simulation",
                    Platform = "Nintendo Switch",
                    Price = 60
                },

                new Game
                {
                    Title = "Animal Crossing: New Leaf",
                    ReleaseDate = DateTime.Parse("2013-6-9"),
                    Genre = "Social simulation",
                    Platform = "Nintendo 3DS",
                    Price = 20
                },

                new Game
                {
                    Title = "Haven & Hearth",
                    ReleaseDate = DateTime.Parse("2015-8-21"),
                    Genre = "MMORPG",
                    Platform = "PC",
                    Price = 0
                }
            );
            context.SaveChanges();
        }
    }
}