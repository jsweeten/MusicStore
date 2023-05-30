using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Guitar
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Strings { get; set; }
        public int NumFrets { get; set; }
        public float Price { get; set; }
        public string? ImagePath { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GuitarTypeId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public GuitarType GuitarType { get; set; }
        public bool Used { get; set; }
    }
}