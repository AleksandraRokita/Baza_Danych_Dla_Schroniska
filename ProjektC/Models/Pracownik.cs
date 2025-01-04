using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

[Table("Pracownik")]
public partial class Pracownik
{
    [Key]
    [Column("id_pracownika")]
    public int IdPracownika { get; set; }

    [Column("imie")]
    [StringLength(50)]
    public string Imie { get; set; } = null!;

    [Column("nazwisko")]
    [StringLength(50)]
    public string Nazwisko { get; set; } = null!;

  

    [InverseProperty("IdPracownikaNavigation")]
    public virtual ICollection<Adopcja> Adopcjas { get; set; } = new List<Adopcja>();
}
