using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektC.Models;

[Table("Adopcja")]
public partial class Adopcja
{
    [Key]
    [Column("id_adopcji")]
    public int IdAdopcji { get; set; }

    [Column("id_zwierzecia")]
    public int IdZwierzecia { get; set; }

    [Column("id_uzytkownika")]
    public int IdUzytkownika { get; set; }

    [Column("id_pracownika")]
    public int IdPracownika { get; set; }

    [Column("status_adopcji")]
    [StringLength(20)]
    [Unicode(false)]
    public string? StatusAdopcji { get; set; }



    [Column("data_rozpoczecia_adopcji")]
    public DateTime DataRozpoczeciaAdopcji { get; set; }

    [Column("data_zakonczenia_adopcji")]
    public DateTime? DataZakonczeniaAdopcji { get; set; }


    [ForeignKey("IdPracownika")]
    [InverseProperty("Adopcjas")]
    public virtual Pracownik? IdPracownikaNavigation { get; set; } = null!;

    [ForeignKey("IdUzytkownika")]
    [InverseProperty("Adopcjas")]
    public virtual Uzytkownik? IdUzytkownikaNavigation { get; set; } = null!;

    [ForeignKey("IdZwierzecia")]
    [InverseProperty("Adopcjas")]
    public virtual Zwierze? IdZwierzeciaNavigation { get; set; } = null!;
}
