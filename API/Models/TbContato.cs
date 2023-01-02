using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("tb_contato")]
public partial class TbContato
{
    [Key]
    [Column("PK_ID")]
    public int PkId { get; set; }

    [Column("DS_NOME")]
    [StringLength(80)]
    public string DsNome { get; set; } = null!;

    [Column("DS_EMAIL")]
    [StringLength(160)]
    public string DsEmail { get; set; } = null!;

    [Column("NR_TELEFONE", TypeName = "mediumtext")]
    public string NrTelefone { get; set; } = null!;

    [Column("DT_NASCIMENTO")]
    public DateOnly DtNascimento { get; set; }
}
