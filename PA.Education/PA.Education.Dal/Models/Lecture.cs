using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PA.Education.Dal.Models.Base;

namespace PA.Education.Dal.Models; 

public class Lecture : BaseEntity {

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(32)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(32)]
    public string Description { get; set; }

}