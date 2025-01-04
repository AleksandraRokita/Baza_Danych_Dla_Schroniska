using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

[Table("Lokacja")]
public partial class Lokacja
{
    [Key]
    [Column("id_lokacji")]
    public int IdLokacji { get; set; }

    [Column("lokacja")]
    [StringLength(50)]
    [Unicode(false)]
    public string Lokacja1 { get; set; } = null!;

    [InverseProperty("IdLokacjiNavigation")]
    public virtual ICollection<Zwierze> Zwierzes { get; set; } = new List<Zwierze>();
}
