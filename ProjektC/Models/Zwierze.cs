using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

[Table("Zwierze")]
public partial class Zwierze
{
    [Key]
    [Column("id_zwierzecia")]
    public int IdZwierzecia { get; set; }

    [Column("gatunek")]
    [StringLength(50)]
    [Unicode(false)]
    public string Gatunek { get; set; } = null!;

    [Column("imie")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Imie { get; set; }

    [Column("rasa")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Rasa { get; set; }

    [Column("wiek")]
    public int? Wiek { get; set; }

    [Column("waga", TypeName = "float")]
    public double? Waga { get; set; }



    [Column("id_lokacji")]
    public int? IdLokacji { get; set; }

    [InverseProperty("IdZwierzeciaNavigation")]
    public virtual ICollection<Adopcja> Adopcjas { get; set; } = new List<Adopcja>();

    [ForeignKey("IdLokacji")]
    [InverseProperty("Zwierzes")]
    public virtual Lokacja? IdLokacjiNavigation { get; set; }
}
