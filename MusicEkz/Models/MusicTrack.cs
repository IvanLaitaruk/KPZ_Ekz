using System;
using System.Collections.Generic;

namespace MusicEkz.Models;

public partial class MusicTrack
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public double? Length { get; set; }

    public string? Path { get; set; }
}
