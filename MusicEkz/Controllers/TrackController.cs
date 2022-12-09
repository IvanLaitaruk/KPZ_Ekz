using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEkz.Models;

namespace MusicEkz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly MusicDbContext _MusicContext;

        public TrackController(MusicDbContext musicDbContext)
        {
            _MusicContext = musicDbContext;
        }

        [HttpGet]
        public IActionResult GetAllTracks()
        {
            return Ok(_MusicContext.MusicTracks.ToList());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetTrack(int id)
        {
            MusicTrack item = _MusicContext.MusicTracks.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult PostTrack(MusicTrack item)
        {
            int newId = _MusicContext.MusicTracks.Count() + 1;
            if (item == null)
            {
                return NotFound();
            }
            item.Id = newId;
            _MusicContext.MusicTracks.Add(item);
            _MusicContext.SaveChanges();
            return Ok(item);
        }
        
        [HttpDelete]
        public IActionResult DeleteTrack(int id)
        {
            MusicTrack item = _MusicContext.MusicTracks.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _MusicContext.MusicTracks.Remove(item);
            return Ok(item);
        }
        
        [HttpPut]
        public IActionResult PutTracka(MusicTrack track)
        {
            MusicTrack existingTrack = _MusicContext.MusicTracks.SingleOrDefault(x => x.Id == track.Id);
            if(existingTrack != null)
            {
                existingTrack.Name = track.Name;
                existingTrack.Length = track.Length;
                existingTrack.Path = track.Path;
                _MusicContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(existingTrack);
        }
    }
}
