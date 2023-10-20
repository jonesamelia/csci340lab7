using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Data;
using RazorPagesGame.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace RazorPagesGame.Pages_Games
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGame.Data.RazorPagesGameContext _context;

        public IndexModel(RazorPagesGame.Data.RazorPagesGameContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? GameGenre { get; set; }

        public SelectList? Platforms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? GamePlatform { get; set; }

        public async Task OnGetAsync()
        {   
            IQueryable<string> genreQuery = from g in _context.Game
                                            orderby g.Genre
                                            select g.Genre;

            IQueryable<string> platformQuery = from g in _context.Game
                                            orderby g.Platform
                                            select g.Platform;

            var games = from g in _context.Game
                 select g;

            if (!string.IsNullOrEmpty(SearchString))
            {   
                games = games.Where(s => s.Title.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(GameGenre)){
                games = games.Where(x => x.Genre == GameGenre);
            }
            if(!string.IsNullOrEmpty(GamePlatform)){
                games = games.Where(p => p.Platform == GamePlatform);
            }
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Platforms = new SelectList(await platformQuery.Distinct().ToListAsync());
                Game = await games.ToListAsync();
            
        }
    }
}
