using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TrilleLille.Web.Models.GroupViewModels
{
    public class CreateGroupViewModel
    {
        [Display(Name = "Gruppens navn")]
        public string Name { get; set; }

        [Display(Name = "En kort beskrivelse om gruppen")]
        public string GroupIntro { get; set; }

        [Display(Name = "Ditt navn")]
        public string CreatorName { get; set; }

        [Display(Name = "Fortell oss litt om deg selv")]
        public string CreatorBio { get; set; }

        [Display(Name = "Jeg er")]
        public int ParentTypeId { get; set; }

        [EmailAddress]
        [Display(Name = "E-post")]
        public string CreatorEmail { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekreft passord")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ProfileImageUrl { get; set; }

        [Display(Name = "Søker andre")]
        public Gender SeekingGender { get; set; }
        [Display(Name = "For (barnets navn)")]
        public string ChildName { get; set; }
        public int ChildAgeGroupId { get; set; }
        public AgeGroup AgeGroup { get; set; }

        public int SeekingAgeGroupId { get; set; }

        [Display(Name = "Søker andre på postnummer")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Ugyldig filtype")]
        [DataType(DataType.Upload)]
        [Display(Name = "Last opp profilbilde")]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp")]
        public IFormFile ProfileImage { get; set; }
    }
}