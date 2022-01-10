using System.ComponentModel.DataAnnotations;

namespace HotelsApp.Dtos
{
    public class NamedEntityDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
    }
}
