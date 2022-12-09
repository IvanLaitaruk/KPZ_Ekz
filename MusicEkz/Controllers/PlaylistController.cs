using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicEkz.Models;

namespace MusicEkz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly MusicDbContext _MusicContext;

        public PlaylistController(MusicDbContext musicDbContext)
        {
            _MusicContext = musicDbContext;
        }

        [HttpPost]
        public IActionResult PostTracks(List<MusicTrack> items)
        {
            if (items.IsNullOrEmpty())
            {
                return NotFound();
            }
            int indexId = _MusicContext.Playlists.Count() + 1;
            foreach(var item in items)
            {
                if (item != null)
                {
                    Playlist playlist = new Playlist();
                    playlist.Id = indexId;
                    playlist.TrackId = item.Id;
                    _MusicContext.Playlists.Add(playlist);
                    ++indexId;
                }
                else
                {
                    return NotFound();
                }
            }
           
            _MusicContext.SaveChanges();
            return Ok(items);
        }
    }
}
