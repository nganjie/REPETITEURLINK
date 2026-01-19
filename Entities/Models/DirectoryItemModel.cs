using REPETITEURLINK.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Entities.Models;

public class DirectoryItemModel
{
    public required DirectoryKinds Kind { get; set; }
    public required string Value { get; set; }
    public required string DisplayName { get; set; }
    public string? Symbol { get; set; }

}