﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteHaven.Domain.Entities;

public class Amenity
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    [ForeignKey(nameof(Villa))]
    [Display(Name = "Villa Name")]
    public int VillaId { get; set; }
    [ValidateNever]
    public Villa? Villa { get; set; }
}
