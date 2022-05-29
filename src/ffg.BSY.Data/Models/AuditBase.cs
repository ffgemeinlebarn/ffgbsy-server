using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public abstract class AuditBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime AuditCreated { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime AuditEdited { get; set; }
}