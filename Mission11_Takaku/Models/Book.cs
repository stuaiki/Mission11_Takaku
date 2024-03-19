using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission11_Takaku.Models;
//THis is Book class which store the types of data and getter and setter
public partial class Book
{
    [Key]
    [Required]
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public string Classification { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int PageCount { get; set; }

    public double Price { get; set; }
}
