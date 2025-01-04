using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

[Table("Uzytkownik")]
public partial class Uzytkownik
{
    [Key]
    [Column("id_uzytkownika")]
    public int IdUzytkownika { get; set; }

    [Column("imie")]
    [StringLength(50)]
    [Unicode(false)]
    public string Imie { get; set; } = null!;

    [Column("nazwisko")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nazwisko { get; set; } = null!;

    [InverseProperty("IdUzytkownikaNavigation")]
    public virtual ICollection<Adopcja> Adopcjas { get; set; } = new List<Adopcja>();
}
