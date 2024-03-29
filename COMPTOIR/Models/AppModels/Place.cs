﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPTOIR.Models.AppModels
{

    public class PlaceCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Place Type Name")]
        public string? Name { get; set; }
        public bool IsCook { get; set; } = false;
        public bool IsAmountIgnored { get; set; } = false;
        public bool IsSend { get; set; } = false;
        public bool IsReceive { get; set; } = false;
        public virtual ICollection<Place>? Places { get; set; }
        public bool IsDeleted { get; set; }
    }


    public class Place
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 6)]
        // [RegularExpression(@"^[^\.]+$",ErrorMessage ="Character . is not allowed")]
        [Display(Name = "Place Name")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public string? IpAddress { get; set; }
        public string? LogoUrl { get; set; }
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please Choose Place Type")]
        public int CategoryId { get; set; }
        public virtual PlaceCategory? Category { get; set; }
        public virtual ICollection<Recipe>? Recipes { get; set; }
        public virtual ICollection<Place>? Suppliers { get; set; }
        public virtual ICollection<Place>? Clients { get; set; }
        public virtual ICollection<ChannelCategory>? ChannelCategories { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class PlaceViewModel
    {
        public PlaceViewModel()
        {

        }

        public PlaceViewModel(Place model,string hostpath)
        {
            Id = model.Id;
            Name = model.Name;
            Address = model.Address;
            PhoneNumber = model.PhoneNumber;
            IpAddress = model.IpAddress;
            LogoUrl = !string.IsNullOrEmpty(model.LogoUrl) ? hostpath + model.LogoUrl : "";
            CategoryId = model.CategoryId;
            CategoryName = model.Category?.Name;
            IsCook = model.Category.IsCook;
            IsAmountIgnored = model.Category.IsAmountIgnored;
            IsSend = model.Category.IsSend;
            IsReceive = model.Category.IsReceive;

    }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IpAddress { get; set; }
        public string? LogoUrl { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsCook { get; set; }
        public bool IsAmountIgnored { get; set; }
        public bool IsSend { get; set; }
        public bool IsReceive { get; set; }
    }
}
